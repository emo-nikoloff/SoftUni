using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

using Microsoft.EntityFrameworkCore;

using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using CarDealer.DTOs.Export;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        using CarDealerContext dbContext = new();

        /*
         * Part I. Import - разкоментирайте първия xmlFilePath, xmlFileContent и първия result и сменяйте само xmlFileName и името на метода Import...()
            Задача 1 - Suppliers, 2 - Parts, 3 - Cars, 4 - Customers, 5 - Sales
         * Part II. Export - разкоментирайте втория xmlFilePath, втория result и File.WriteAllText() и сменяйте само xmlFileName и името на метода Get...()
            Задача 6 - CarsWithDistance, 7 - CarsFromMakeBmw, 8 - LocalSuppliers, 9 - CarsWithTheirListOfParts, 10 - TotalSalesByCustomer, 11 - SalesWithAppliedDiscount
        */
        string xmlFileName = "customers-total-sales.xml";

        //string xmlFilePath = GetXmlFilePath(xmlFileName);
        string xmlFilePath = GetXmlResultFilePath(xmlFileName);

        //string xmlFileContent = File.ReadAllText(xmlFilePath);

        //string result = ImportSales(dbContext, xmlFileContent);
        string result = GetTotalSalesByCustomer(dbContext);

        File.WriteAllText(xmlFilePath, result);

        Console.WriteLine(result);
    }

    // Part I. Import
    // Задача 1
    public static string ImportSuppliers(CarDealerContext dbContext, string inputXml)
    {
        XmlRootAttribute xmlRoot = new("Suppliers");

        // NOTE: XmlSerializer класът се използва едновременно за сериализация и десериализация!
        // Способен е да парсне стринг към повечето типове данни, но при грешка ще се провали цялата сериализация/десериализация
        XmlSerializer xmlSerializer = new(typeof(ImportSupplierDto[]), xmlRoot);

        using StringReader stringReader = new(inputXml);

        IEnumerable<ImportSupplierDto>? supplierDtos = (IEnumerable<ImportSupplierDto>?)xmlSerializer.Deserialize(stringReader);
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

            bool isImporterPropertyValid = bool.TryParse(supplierDto.IsImporter, out bool isImporterValue);
            if (!isImporterPropertyValid)
            {
                // Пропускаме невалидните записи, които съдържат невалидни данни, които не могат да бъдат парснати към bool, за IsImporter пропъртито
                continue;
            }

            Supplier newSupplier = new()
            {
                Name = supplierDto.Name,
                IsImporter = isImporterValue,
            };

            suppliersToPersist.Add(newSupplier);
        }

        dbContext.Suppliers.AddRange(suppliersToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {suppliersToPersist.Count}";
    }

    // Задача 2
    public static string ImportParts(CarDealerContext dbContext, string inputXml)
    {
        // Създаваме си собствен Wrapper, който ни помага да избегнем постоянното писане на един и същ код за сериализация и десериализация, и работи по подобие на JsonConverter-a
        IEnumerable<ImportPartDto>? partDtos = XmlSerializerWrapper.Deserialize<ImportPartDto[]>(inputXml, "Parts");
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

            bool isPricePropertyValid = decimal.TryParse(partDto.Price, out decimal priceValue);
            if (!isPricePropertyValid)
            {
                continue;
            }

            if (!validSupplierIds.Contains(partDto.SupplierId))
            {
                // Пропускаме записа, защото има релация към несъществуващ Supplier
                continue;
            }

            Part newPart = new()
            {
                Name = partDto.Name,
                Price = priceValue,
                Quantity = partDto.Quantity,
                SupplierId = partDto.SupplierId,
            };

            partsToPersist.Add(newPart);
        }

        dbContext.Parts.AddRange(partsToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {partsToPersist.Count}";
    }

    // Задача 3
    public static string ImportCars(CarDealerContext dbContext, string inputXml)
    {
        IEnumerable<ImportCarDto>? carDtos = XmlSerializerWrapper.Deserialize<ImportCarDto[]>(inputXml, "Cars");
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

            IEnumerable<int> uniquePartIds = carDto.Parts
                .Select(p => p.Id)
                .Distinct()
                .ToArray();

            ICollection<PartCar> carParts = new List<PartCar>();
            foreach (int partId in uniquePartIds)
            {
                if (!validPartIds.Contains(partId))
                {
                    // Пропускаме САМО записите за Part
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

        return $"Successfully imported {carsToPersist.Count}";
    }

    // Задача 4
    public static string ImportCustomers(CarDealerContext dbContext, string inputXml)
    {
        IEnumerable<ImportCustomerDto>? customerDtos = XmlSerializerWrapper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");
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
                BirthDate = customerDto.BirthDate,
                IsYoungDriver = customerDto.IsYoungDriver,
            };

            customersToPersist.Add(newCustomer);
        }

        dbContext.Customers.AddRange(customersToPersist);
        dbContext.SaveChanges();

        return $"Successfully imported {customersToPersist.Count}";
    }

    // Задача 5
    public static string ImportSales(CarDealerContext dbContext, string inputXml)
    {
        IEnumerable<ImportSaleDto>? saleDtos = XmlSerializerWrapper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");
        if (saleDtos == null)
        {
            saleDtos = Array.Empty<ImportSaleDto>();
        }

        IEnumerable<int> validCarIds = dbContext.Cars
            .AsNoTracking()
            .Select(c => c.Id)
            .ToArray();

        ICollection<Sale> salesToPersist = new List<Sale>();
        foreach (ImportSaleDto saleDto in saleDtos)
        {
            if (!IsValid(saleDto))
            {
                continue;
            }

            if (!validCarIds.Contains(saleDto.CarId))
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

        return $"Successfully imported {salesToPersist.Count}";
    }


    // Part II. Export
    // Задача 6
    public static string GetCarsWithDistance(CarDealerContext dbContext)
    {
        StringBuilder result = new();

        IEnumerable<ExportCarWithDistanceDto> carsWithDistance = dbContext.Cars
            .AsNoTracking()
            .Select(c => new ExportCarWithDistanceDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
            })
            .Where(c => c.TraveledDistance > 2000000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ToArray();

        /* Премахва namespace-овете, които се намират в началото на файла. По подразбиране служат за информация за схемата, която се използва при сериализация на данните, за да може след това
           този, който десериализира, да намери схемата и да десериализира по нея*/
        XmlSerializerNamespaces xmlNamespaces = new();
        xmlNamespaces.Add(string.Empty, string.Empty);

        XmlRootAttribute xmlRoot = new("cars");

        XmlSerializer xmlSerializer = new(typeof(ExportCarWithDistanceDto[]), xmlRoot);

        using StringWriter stringWriter = new(result);

        xmlSerializer.Serialize(stringWriter, carsWithDistance, xmlNamespaces);

        return result.ToString().TrimEnd();
    }

    // Задача 7
    public static string GetCarsFromMakeBmw(CarDealerContext dbContext)
    {
        // Не използваме интерфейс за колекция, понеже нашият Serialize() се чупи
        ExportCarFromMakeBmwDto[] carsFromBmw = dbContext.Cars
            .AsNoTracking()
            .Where(c => c.Make == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .Select(c => new ExportCarFromMakeBmwDto()
            {
                Id = c.Id,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
            })
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(carsFromBmw, "cars");

        return result.TrimEnd();
    }

    // Задача 8
    public static string GetLocalSuppliers(CarDealerContext dbContext)
    {
        ExportLocalSupplierDto[] localSuppliers = dbContext.Suppliers
            .AsNoTracking()
            .Where(s => s.IsImporter == false)
            .Select(s => new ExportLocalSupplierDto()
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count,
            })
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(localSuppliers, "suppliers");

        return result.TrimEnd();
    }

    // Задача 9
    public static string GetCarsWithTheirListOfParts(CarDealerContext dbContext)
    {
        ExportCarPartsDto[] carsWithParts = dbContext.Cars
            .AsNoTracking()
            .Select(c => new ExportCarPartsDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                Parts = c.PartsCars.Select(pc => pc.Part)
                    .Select(p => new ExportPartCarDto()
                    {
                        Name = p.Name,
                        Price = p.Price,
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray(),
            })
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(carsWithParts, "cars");

        return result.TrimEnd();
    }

    // Задача 10
    public static string GetTotalSalesByCustomer(CarDealerContext dbContext)
    {
        ExportCustomerTotalSalesDto[] customerTotalSales = dbContext.Customers
            .AsNoTracking()
            .Where(c => c.Sales.Any())
            .Select(c => new ExportCustomerTotalSalesDto()
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.IsYoungDriver
                    ? c.Sales.SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => Math.Round(pc.Part.Price * (1 - 5 / 100.0m), 2))
                    : c.Sales.SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => Math.Round(pc.Part.Price, 2)),
            })
            .OrderByDescending(c => c.SpentMoney)
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(customerTotalSales, "customers");

        return result.TrimEnd();
    }

    // Задача 11
    public static string GetSalesWithAppliedDiscount(CarDealerContext dbContext)
    {
        ExportSaleDiscountDto[] salesWithDiscount = dbContext.Sales
            .AsNoTracking()
            .Select(s => new ExportSaleDiscountDto()
            {
                Car = new ExportSaleDiscountsCarDto()
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance.ToString(),
                },
                Discount = ((int)s.Discount).ToString(),
                CustomerName = s.Customer.Name,
                Price = s.Car.PartsCars
                    .Sum(pc => pc.Part.Price)
                    .ToString("0.####"),
                DiscountedPrice = (s.Car.PartsCars
                    .Sum(pc => pc.Part.Price) * (1 - s.Discount / 100.0m))
                    .ToString("0.####"),
            })
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(salesWithDiscount, "sales");

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

    private static bool IsValid(object obj)
    {
        ValidationContext validationContext = new(obj);
        ICollection<ValidationResult> validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults);

        return isValid;
    }
}