using System.ComponentModel.DataAnnotations;
using System.Text;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        using ProductShopContext dbContext = new();

        /*
         * Part I. Import - разкоментирайте първия xmlFilePath, xmlFileContent и първия result и сменяйте само xmlFileName и името на метода Import...()
            Задача 1 - Users, 2 - Products, 3 - Categories, 4 - CategoryProducts
         * Part II. Export - разкоментирайте втория xmlFilePath, втория result и File.WriteAllText() и сменяйте само xmlFileName и името на метода Get...()
            Задача 5 - ProductsInRange, Задача 6 - SoldProducts, Задача 7 - CategoriesByProducts, Задача 8 - UsersWithProducts
        */
        string xmlFileName = "users-and-products.xml";

        //string xmlFilePath = GetXmlFilePath(xmlFileName);
        string xmlFilePath = GetXmlResultFilePath(xmlFileName);

        //string xmlFileContent = File.ReadAllText(xmlFilePath);

        //string result = ImportCategoryProducts(dbContext, xmlFileContent);
        string result = GetUsersWithProducts(dbContext);

        File.WriteAllText(xmlFilePath, result, Encoding.UTF8);

        Console.WriteLine(result);
    }

    // Part I. Import
    // Задача 1
    public static string ImportUsers(ProductShopContext dbContext, string inputXml)
    {
        IEnumerable<ImportUserDto>? userDtos = XmlSerializerWrapper.Deserialize<ImportUserDto[]>(inputXml, "Users");
        if (userDtos == null)
        {
            userDtos = Array.Empty<ImportUserDto>();
        }

        ICollection<User> usersToPersist = new List<User>();
        foreach (ImportUserDto userDto in userDtos)
        {
            if (!IsValid(userDto))
            {
                continue;
            }

            User newUser = new()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
            };

            usersToPersist.Add(newUser);
        }

        dbContext.Users.AddRange(usersToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {usersToPersist.Count}";
    }

    // Задача 2
    public static string ImportProducts(ProductShopContext dbContext, string inputXml)
    {
        IEnumerable<ImportProductDto>? productDtos = XmlSerializerWrapper.Deserialize<ImportProductDto[]>(inputXml, "Products");
        if (productDtos == null)
        {
            productDtos = Array.Empty<ImportProductDto>();
        }

        ICollection<Product> productsToPersist = new List<Product>();
        foreach (ImportProductDto productDto in productDtos)
        {
            if (!IsValid(productDto))
            {
                continue;
            }

            Product newProduct = new()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                SellerId = productDto.SellerId,
                BuyerId = productDto.BuyerId,
            };

            productsToPersist.Add(newProduct);
        }

        dbContext.Products.AddRange(productsToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {productsToPersist.Count}";
    }

    // Задача 3
    public static string ImportCategories(ProductShopContext dbContext, string inputXml)
    {
        IEnumerable<ImportCategoryDto>? categoryDtos = XmlSerializerWrapper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
        if (categoryDtos == null)
        {
            categoryDtos = Array.Empty<ImportCategoryDto>();
        }

        ICollection<Category> categoriesToPersist = new List<Category>();
        foreach (ImportCategoryDto categoryDto in categoryDtos)
        {
            if (!IsValid(categoryDto))
            {
                continue;
            }

            Category newCategory = new()
            {
                Name = categoryDto.Name,
            };

            categoriesToPersist.Add(newCategory);
        }

        dbContext.Categories.AddRange(categoriesToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {categoriesToPersist.Count}";
    }

    // Задача 4
    public static string ImportCategoryProducts(ProductShopContext dbContext, string inputXml)
    {
        IEnumerable<ImportCategoryProductsDto>? categoryProductDtos = XmlSerializerWrapper.Deserialize<ImportCategoryProductsDto[]>(inputXml, "CategoryProducts");
        if (categoryProductDtos == null)
        {
            categoryProductDtos = Array.Empty<ImportCategoryProductsDto>();
        }

        ICollection<int> validCategoryIds = dbContext.Categories
            .AsNoTracking()
            .Select(c => c.Id)
            .ToArray();
        ICollection<int> validProductIds = dbContext.Products
            .AsNoTracking()
            .Select(p => p.Id)
            .ToArray();

        ICollection<CategoryProduct> categoryProductsToPersist = new List<CategoryProduct>();
        foreach (ImportCategoryProductsDto categoryProductDto in categoryProductDtos)
        {
            if (!validCategoryIds.Contains(categoryProductDto.CategoryId) ||
                !validProductIds.Contains(categoryProductDto.ProductId))
            {
                continue;
            }

            CategoryProduct newCategoryProduct = new()
            {
                CategoryId = categoryProductDto.CategoryId,
                ProductId = categoryProductDto.ProductId,
            };

            categoryProductsToPersist.Add(newCategoryProduct);
        }

        dbContext.CategoryProducts.AddRange(categoryProductsToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {categoryProductsToPersist.Count}";
    }

    // Part II. Export
    // Задача 5
    public static string GetProductsInRange(ProductShopContext dbContext)
    {
        ExportProductInRangeDto[] productsInRange = dbContext.Products
            .AsNoTracking()
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Take(10)
            .Select(p => new ExportProductInRangeDto()
            {
                ProductName = p.Name,
                Price = p.Price,
                BuyerFullName = p.Buyer != null
                    ? $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                    : " ",
            })
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(productsInRange, "Products");

        return result.TrimEnd();
    }

    // Задача 6
    public static string GetSoldProducts(ProductShopContext dbContext)
    {
        ExportUserSoldProductsDto[] userSoldProducts = dbContext.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Take(5)
            .Select(u => new ExportUserSoldProductsDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                SoldProducts = u.ProductsSold
                    .Select(p => new ExportProductUserDto()
                    {
                        Name = p.Name,
                        Price = p.Price,
                    })
                    .ToArray(),
            })
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(userSoldProducts, "Users");

        return result.TrimEnd();
    }

    // Задача 7
    public static string GetCategoriesByProductsCount(ProductShopContext dbContext)
    {
        ExportCategoryProductsDto[] categoryProducts = dbContext.Categories
            .AsNoTracking()
            .Select(c => new ExportCategoryProductsDto()
            {
                Name = c.Name,
                Count = c.CategoriesProducts.Count,
                AveragePrice = c.CategoriesProducts.Select(cp => cp.Product)
                    .Average(p => p.Price),
                TotalRevenue = c.CategoriesProducts.Select(cp => cp.Product)
                    .Sum(p => p.Price),
            })
            .OrderByDescending(c => c.Count)
            .ThenBy(c => c.TotalRevenue)
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(categoryProducts, "Categories");

        return result.TrimEnd();
    }

    // Задача 8
    public static string GetUsersWithProducts(ProductShopContext dbContext)
    {
        ExportUserWithProductsDto[] usersWithProducts = dbContext.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .Select(u => new ExportUserWithProductsDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                SoldProducts = new ExportSoldProductsCountDto()
                {
                    Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                    Products = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new ExportProductUserDto()
                        {
                            Name = p.Name,
                            Price = p.Price,
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray(),
                },
            })
            .OrderByDescending(u => u.SoldProducts.Count)
            .Take(10)
            .ToArray();

        int totalUsersCount = dbContext.Users
            .Count(u => u.ProductsSold.Any(p => p.BuyerId.HasValue));

        ExportUsersWithProductsCountDto userWithProductsCount = new()
        {
            Count = totalUsersCount,
            Users = usersWithProducts,
        };

        string result = XmlSerializerWrapper.Serialize(userWithProductsCount, "Users");

        return result.TrimEnd();
    }

    // Допълнителни методи:
    private static string GetXmlFilePath(string xmlFileName)
    {
        string xmlFolderPath = "../../../Datasets/";
        string xmlFilePath = Path.Combine(xmlFolderPath, xmlFileName);

        return Path.GetFullPath(xmlFilePath);
    }

    private static string GetXmlResultFilePath(string xmlFileName)
    {
        string xmlResultFolderPath = "../../../Results/";
        string xmlResultFilePath = Path.Combine(xmlResultFolderPath, xmlFileName);

        return Path.GetFullPath(xmlResultFilePath);
    }

    private static bool IsValid(object obj) // извиква object validator, който минава през валидационните атрибути върху обекта, и проверява дали тези атрибути са валидни или не
    {
        // Boilerplate code - ако не го разбирате, не е проблем - може да се запомни наизуст

        ValidationContext validationContext = new(obj);
        ICollection<ValidationResult> validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults);

        return isValid;
    }
}