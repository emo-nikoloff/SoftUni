using System.ComponentModel.DataAnnotations;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.DTOs.Export;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        using CarDealerContext dbContext = new();

        /* Part I. ProductShop
         * Part I.I. Import - разкоментирайте първия jsonFilePath, първия jsonFileContent и първия result и сменяйте само jsonFileName и името на метода Import...()
            Задача 1 - Users, 2 - Products, 3 - Categories, 4 - CategoryProducts
         * Part I.II. Export - разкоментирайте втория jsonFilePath, втория jsonFileContent и втория result + File.WriteAllText(...) и сменяйте само jsonFileName и името на метода Get...()
            Задача 5 - ProductsInRange, Задача 6 - SoldProducts, Задача 7 - CategoriesByProducts, Задача 8 - UsersWithProducts
        */
        string jsonFileName = "sales-discounts.json";

        //string jsonFilePath = GetJsonFilePath(jsonFileName);
        string jsonFilePath = GetJsonResultFilePath(jsonFileName);

        //string jsonFileContent = File.ReadAllText(jsonFilePath);

        //string result = ImportSales(dbContext, jsonFileContent);
        string result = GetSalesWithAppliedDiscount(dbContext);

        File.WriteAllText(jsonFilePath, result, Encoding.UTF8);

        Console.WriteLine(result);
    }

    // Part I.I. Import
    // Задача 1
    public static string ImportSuppliers(CarDealerContext dbContext, string inputJson)
    {
        IEnumerable<ImportSupplierDto>? supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);
        if (supplierDtos == null)
        {
            supplierDtos = Array.Empty<ImportSupplierDto>();
        }

        ICollection<Supplier> suppliersToPersist = new List<Supplier>();
        foreach (ImportSupplierDto supplierDto in supplierDtos)
        {
            if (!IsValid(supplierDto))
            {
                continue;
            }

            Supplier newSupplier = new()
            {
                Name = supplierDto.Name,
                IsImporter = supplierDto.IsImporter,
            };

            suppliersToPersist.Add(newSupplier);
        }

        dbContext.Suppliers.AddRange(suppliersToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {suppliersToPersist.Count}.";
    }

    // Задача 2
    public static string ImportParts(CarDealerContext dbContext, string inputJson)
    {
        IEnumerable<ImportPartDto>? partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);
        if (partDtos == null)
        {
            partDtos = Array.Empty<ImportPartDto>();
        }

        IEnumerable<int> validSupplierIds = dbContext.Suppliers
            .AsNoTracking()
            .Select(s => s.Id)
            .ToArray();

        ICollection<Part> partsToPersist = new List<Part>();
        foreach (ImportPartDto partDto in partDtos)
        {
            if (!IsValid(partDto))
            {
                continue;
            }

            bool isSupplierIdValid = validSupplierIds.Contains(partDto.SupplierId);
            if (!isSupplierIdValid)
            {
                continue;
            }

            Part newPart = new()
            {
                Name = partDto.Name,
                Price = partDto.Price,
                Quantity = partDto.Quantity,
                SupplierId = partDto.SupplierId,
            };

            partsToPersist.Add(newPart);
        }

        dbContext.Parts.AddRange(partsToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {partsToPersist.Count}.";
    }

    // Задача 3
    public static string ImportCars(CarDealerContext dbContext, string inputJson)
    {
        IEnumerable<ImportCarDto>? carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
        if (carDtos == null)
        {
            carDtos = Array.Empty<ImportCarDto>();
        }

        IEnumerable<int> validPartIds = dbContext.Parts
            .AsNoTracking()
            .Select(p => p.Id)
            .ToArray();

        ICollection<Car> carsToPersist = new List<Car>();
        foreach (ImportCarDto carDto in carDtos)
        {
            if (!IsValid(carDto))
            {
                continue;
            }

            Car newCar = new()
            {
                Make = carDto.Make,
                Model = carDto.Model,
                TraveledDistance = carDto.TraveledDistance,
            };

            IEnumerable<int> uniquePartIds = carDto.PartsIds
                .Distinct()
                .ToArray();

            ICollection<PartCar> carParts = new List<PartCar>();
            foreach (int partId in uniquePartIds)
            {
                if (!validPartIds.Contains(partId))
                {
                    continue;
                }

                PartCar newPartCar = new()
                {
                    PartId = partId,
                    Car = newCar,
                };

                carParts.Add(newPartCar);
            }

            newCar.PartsCars = carParts;

            carsToPersist.Add(newCar);
        }

        dbContext.Cars.AddRange(carsToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {carsToPersist.Count}.";
    }

    // Задача 4
    public static string ImportCustomers(CarDealerContext dbContext, string inputJson)
    {
        IEnumerable<ImportCustomerDto>? customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
        if (customerDtos == null)
        {
            customerDtos = Array.Empty<ImportCustomerDto>();
        }

        ICollection<Customer> customersToPersist = new List<Customer>();
        foreach (ImportCustomerDto customerDto in customerDtos)
        {
            if (!IsValid(customerDto))
            {
                continue;
            }

            Customer newCustomer = new()
            {
                Name = customerDto.Name,
                BirthDate = DateTime.Parse(customerDto.BirthDate),
                IsYoungDriver = customerDto.IsYoungDriver,
            };

            customersToPersist.Add(newCustomer);
        }

        dbContext.Customers.AddRange(customersToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {customersToPersist.Count}.";
    }

    // Задача 5
    public static string ImportSales(CarDealerContext dbContext, string inputJson)
    {
        IEnumerable<ImportSaleDto>? saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);
        if (saleDtos == null)
        {
            saleDtos = Array.Empty<ImportSaleDto>();
        }

        ICollection<Sale> salesToPersist = new List<Sale>();
        foreach (ImportSaleDto saleDto in saleDtos)
        {
            if (!IsValid(saleDto))
            {
                continue;
            }

            Sale newSale = new()
            {
                CarId = saleDto.CarId,
                CustomerId = saleDto.CustomerId,
                Discount = saleDto.Discount,
            };

            salesToPersist.Add(newSale);
        }

        dbContext.Sales.AddRange(salesToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {salesToPersist.Count}.";
    }

    // Part I.II. Export
    // Задача 6
    public static string GetOrderedCustomers(CarDealerContext dbContext)
    {
        IEnumerable<ExportOrderedCustomersDto> orderCustomers = dbContext.Customers
            .AsNoTracking()
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .Select(c => new ExportOrderedCustomersDto()
            {
                Name = c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                IsYoungDriver = c.IsYoungDriver,
            })
            .ToArray();

        string jsonResult = JsonConvert.SerializeObject(orderCustomers, Formatting.Indented);

        return jsonResult;
    }

    // Задача 7
    public static string GetCarsFromMakeToyota(CarDealerContext dbContext)
    {
        IEnumerable<ExportCarsFromMakeToyotaDto> carsFromToyota = dbContext.Cars
            .AsNoTracking()
            .Where(c => c.Make == "Toyota")
            .Select(c => new ExportCarsFromMakeToyotaDto()
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
            })
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ToArray();

        string jsonResult = JsonConvert.SerializeObject(carsFromToyota, Formatting.Indented);

        return jsonResult;
    }

    // Задача 8
    public static string GetLocalSuppliers(CarDealerContext dbContext)
    {
        IEnumerable<ExportLocalSuppliersDto> localSuppliers = dbContext.Suppliers
            .AsNoTracking()
            .Where(s => s.IsImporter == false)
            .Select(s => new ExportLocalSuppliersDto()
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count,
            })
            .ToArray();

        string jsonResult = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

        return jsonResult;
    }

    // Задача 9
    public static string GetCarsWithTheirListOfParts(CarDealerContext dbContext)
    {
        IEnumerable<ExportCarsWithTheirListOfPartsDto> carsWithTheirListOfParts = dbContext.Cars
            .AsNoTracking()
            .Select(c => new ExportCarsWithTheirListOfPartsDto()
            {
                Car = new ExportCarInfoDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                },
                Parts = c.PartsCars
                    .Select(pc => pc.Part)
                    .Select(p => new ExportPartInfoDto()
                    {
                        Name = p.Name,
                        Price = p.Price.ToString("f2"),
                    })
                    .ToArray(),
            })
            .ToArray();

        string jsonResult = JsonConvert.SerializeObject(carsWithTheirListOfParts, Formatting.Indented);

        return jsonResult;
    }

    // Задача 10
    public static string GetTotalSalesByCustomer(CarDealerContext dbContext)
    {
        var customerCars = dbContext.Customers
            .AsNoTracking()
            .Where(c => c.Sales.Any())
            .Select(c => new ExportTotalSalesByCustomerDto()
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.Sales.SelectMany(s => s.Car.PartsCars)
                                .Sum(pc => pc.Part.Price)
            })
            .OrderByDescending(c => c.SpentMoney)
            .ThenByDescending(c => c.BoughtCars)
            .ToArray();

        string jsonResult = JsonConvert.SerializeObject(customerCars, Formatting.Indented);

        return jsonResult;
    }

    // Задача 11
    public static string GetSalesWithAppliedDiscount(CarDealerContext dbContext)
    {
        IEnumerable<ExportSalesWithAppliedDiscountDto> salesWithAppliedDiscount = dbContext.Sales
            .AsNoTracking()
            .Select(s => new ExportSalesWithAppliedDiscountDto()
            {
                Car = new ExportCarInfoDto()
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance,
                },
                CustomerName = s.Customer.Name,
                Discount = s.Discount.ToString("f2"),
                Price = s.Car.PartsCars.Select(pc => pc.Part)
                    .Sum(p => p.Price)
                    .ToString("f2"),
                PriceWithDiscount = (s.Car.PartsCars.Select(pc => pc.Part)
                    .Sum(p => p.Price) * (1 - s.Discount / 100.0m))
                    .ToString("f2")
            })
            .Take(10)
            .ToArray();

        string jsonResult = JsonConvert.SerializeObject(salesWithAppliedDiscount, Formatting.Indented);

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

    private static bool IsValid(object obj)
    {
        ValidationContext validationContext = new(obj);
        ICollection<ValidationResult> validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults);

        return isValid;
    }
}