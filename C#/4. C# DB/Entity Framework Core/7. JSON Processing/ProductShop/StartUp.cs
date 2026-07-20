using System.ComponentModel.DataAnnotations;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new();

            /*
             * Part I. Import - разкоментирайте първия jsonFilePath, първия jsonFileContent и първия result и сменяйте само jsonFileName и името на метода Import...()
                Задача 1 - Users, 2 - Products, 3 - Categories, 4 - CategoryProducts
             * Part II. Export - разкоментирайте втория jsonFilePath, втория jsonFileContent и втория result + File.WriteAllText(...) и сменяйте само jsonFileName и името на метода Get...()
                Задача 5 - ProductsInRange, Задача 6 - SoldProducts, Задача 7 - CategoriesByProducts, Задача 8 - UsersWithProducts
            */
            string jsonFileName = "users-sold-products.json";

            //string jsonFilePath = GetJsonFilePath(jsonFileName);
            string jsonFilePath = GetJsonResultFilePath(jsonFileName);

            //string jsonFileContent = File.ReadAllText(jsonFilePath);

            //string result = ImportCategoryProducts(dbContext, jsonFileContent);
            string result = GetSoldProducts(dbContext);

            File.WriteAllText(jsonFilePath, result, Encoding.UTF8);

            Console.WriteLine(result);
        }

        // Part I. Import
        // Задача 1
        public static string ImportUsers(ProductShopContext dbContext, string inputJson)
        {
            IEnumerable<ImportUserDto>? userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);
            if (userDtos == null)
            {
                userDtos = Array.Empty<ImportUserDto>();
            }

            ICollection<User> usersToPersist = new List<User>();
            foreach (ImportUserDto userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    // Пропускаме невалидните DTO записи
                    continue;
                }

                // Manual Mapping - може да бъде пропуснато чрез AutoMapper/Mapperly
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
        public static string ImportProducts(ProductShopContext dbContext, string inputJson)
        {
            IEnumerable<ImportProductDto>? productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            if (productDtos == null)
            {
                productDtos = Array.Empty<ImportProductDto>();
            }

            /* Има два подхода на решение:
             * 1. Еднократно извличане на данните:
                Pros: Избягвате много заявки към базата за всяко Product DTO - (Network Congestion)
                Cons: Ако таблицата Users е много голяма, може да консумира повече памет
             * 2. Извличате User IDs, които съществуват за всяко Product DTO
                Pros: Избягваме предварителното зареждане на User IDs в паметта, което намалява memory consumption
                Cons: Много заявки към базата, което може да задръсти мрежата
            */

            IEnumerable<int> validUserIds = dbContext.Users // IDs на всички валидни потребители - застраховаме се, че базата няма да получи невалидни IDs от json файла и ще се изпълни заявката
                .AsNoTracking()
                .Select(u => u.Id)
                .ToArray();

            ICollection<Product> productsToPersist = new List<Product>();
            foreach (ImportProductDto productDto in productDtos)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }

                bool isSellerIdValid = validUserIds.Contains(productDto.SellerId);
                bool isBuyerIdValid = (!productDto.BuyerId.HasValue) ||
                                        validUserIds.Contains(productDto.BuyerId.Value);

                /* Judge няма валидни потребители заредени предварително. Следователно тази проверка ще провали тестовете
                if (!isBuyerIdValid || !isBuyerIdValid)
                {
                    // Пропускаме записите свързани с несъществуващи потребители
                    continue;
                }
                */

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
        public static string ImportCategories(ProductShopContext dbContext, string inputJson)
        {
            IEnumerable<ImportCategoryDto>? categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);
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
        public static string ImportCategoryProducts(ProductShopContext dbContext, string inputJson)
        {
            IEnumerable<ImportCategoryProductDto>? categoryProductsDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);
            if (categoryProductsDtos == null)
            {
                categoryProductsDtos = Array.Empty<ImportCategoryProductDto>();
            }

            ICollection<CategoryProduct> categoryProductsToPersist = new List<CategoryProduct>();
            foreach (ImportCategoryProductDto categoryProductDto in categoryProductsDtos)
            {
                // Няма валидационни атрибути -> може да се пропусне validation check.
                // Pros: Добавянето на validation check ще позволи бъдещи валидационни атрибути да бъдат използвани
                if (!IsValid(categoryProductDto))
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

            dbContext.CategoriesProducts.AddRange(categoryProductsToPersist);
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
                .Select(p => new ExportProductInRangeDto()
                {
                    ProductName = p.Name,
                    Price = p.Price,
                    SellerFullName = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .OrderBy(p => p.Price)
                .ToArray();

            string jsonResult = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return jsonResult;
        }

        // Задача 6
        public static string GetSoldProducts(ProductShopContext dbContext)
        {
            ExportUserWithSoldProducts[] usersSoldProducts = dbContext.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new ExportUserWithSoldProducts()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new ExportSoldProductDto()
                        {
                            ProductName = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer!.FirstName,
                            BuyerLastName = p.Buyer.LastName,
                        })
                        .ToArray(),
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            string jsonResult = JsonConvert.SerializeObject(usersSoldProducts, Formatting.Indented);

            return jsonResult;
        }

        // Задача 7
        public static string GetCategoriesByProductsCount(ProductShopContext dbContext)
        {
            /* Форматиране на decimal стойностите:
               I. DB Side -> може да използваме .Select(), за да форматираме стойностите към стринг с 2 числа след запетаята и да използваме DTO директно в този .Select()
               II. Client-side -> може да използваме .Select() с анонимен обект, за да извлечем проектираните данни от базата, и след това да използваме още един .Select(), за да форматираме
               стойностите и да свържем с DTO
            */
            ExportCategoryByProductsDto[] categoriesByProducts = dbContext.Categories
                .AsNoTracking()
                .Select(c => new ExportCategoryByProductsDto()
                {
                    CategoryName = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts
                        .Average(cp => cp.Product.Price)
                        .ToString("f2"),
                    TotalRevenue = c.CategoriesProducts
                        .Sum(cp => cp.Product.Price)
                        .ToString("f2"),
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToArray();

            // .SerializeObject() може да работи и с анонимни обекти
            string jsonResult = JsonConvert.SerializeObject(categoriesByProducts, Formatting.Indented);

            return jsonResult;
        }

        // Задача 8
        public static string GetUsersWithProducts(ProductShopContext dbContext)
        {
            // Когато работим с анонимни обекти - пропъртитата на анонимните обекти трябва да спазват имената на пропъртитата от json-a
            // NOTE: 
            var usersSoldProducts = dbContext.Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new // правим SoldProducts нов анонимен обект, а не го свързваме към навигационната колекция, защото това е изискването на json-a от задачата
                    {
                        Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                        Products = u.ProductsSold
                            .Where(p => p.BuyerId.HasValue)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price,
                            })
                            .ToArray()
                    },
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            var usersWithSoldProducts = new
            {
                UsersCount = usersSoldProducts.Length,
                Users = usersSoldProducts,
            };

            DefaultContractResolver camelCaseContractResolver = new()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseContractResolver,
                NullValueHandling = NullValueHandling.Ignore,
            });

            return jsonResult;
        }

        // Допълнителни методи:
        private static string GetJsonFilePath(string jsonFileName)
        {
            string jsonFolderPath = "../../../Datasets/";
            string jsonFilePath = Path.Combine(jsonFolderPath, jsonFileName);

            return Path.GetFullPath(jsonFilePath);
        }

        private static string GetJsonResultFilePath(string jsonFileName)
        {
            string jsonResultFolderPath = "../../../Results/";
            string jsonResultFilePath = Path.Combine(jsonResultFolderPath, jsonFileName);

            return Path.GetFullPath(jsonResultFilePath);
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
}