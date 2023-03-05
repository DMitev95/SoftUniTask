using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();
            //Task 9
            //string xml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string result = ImportSuppliers(dbContext, xml);
            //Console.WriteLine(result);

            //Task 10
            //string xml = File.ReadAllText("../../../Datasets/parts.xml");
            //string result = ImportParts(dbContext, xml);
            //Console.WriteLine(result);

            //Task 11
            //string xml = File.ReadAllText("../../../Datasets/cars.xml");
            //string result = ImportCars(dbContext, xml);
            //Console.WriteLine(result);

            //Task 12
            //string xml = File.ReadAllText("../../../Datasets/customers.xml");
            //string result = ImportCustomers(dbContext, xml);
            //Console.WriteLine(result);

            //Task 13
            //string xml = File.ReadAllText("../../../Datasets/sales.xml");
            //string result = ImportSales(dbContext, xml);
            //Console.WriteLine(result);

            //Task 14
            //string result = GetCarsWithDistance(dbContext);
            //Console.WriteLine(result);

            //Task 15
            //string result = GetCarsFromMakeBmw(dbContext);
            //Console.WriteLine(result);

            //Task 16
            //string result = GetLocalSuppliers(dbContext);
            //Console.WriteLine(result);

            //Task 17
            //string result = GetCarsWithTheirListOfParts(dbContext);
            //Console.WriteLine(result);

            //Task 18
            //string result = GetTotalSalesByCustomer(dbContext);
            //Console.WriteLine(result);

            //Task 19
            string result = GetSalesWithAppliedDiscount(dbContext);
            Console.WriteLine(result);

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

        }

        //Import
        //Task 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);
            using StringReader reader = new StringReader(inputXml);
            ImportSupplierDto[] supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            Supplier[] suppliers = supplierDtos.Select(dto => new Supplier()
            {
                Name = dto.Name,
                IsImporter = dto.IsImporter,
            }).ToArray();
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Length}";
        }

        //Task 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);
            using StringReader reader = new StringReader(inputXml);
            ImportPartDto[] partDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader);
            ICollection<Part> parts = new List<Part>();
            foreach (var p in partDtos)
            {
                if (!context.Suppliers.Any(s => s.Id == p.SupplierId))
                {
                    continue;
                }

                Part part = new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId,
                };
                parts.Add(part);
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }

        //Task 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xmlRoot);
            using StringReader reader = new StringReader(inputXml);
            ImportCarDto[] carDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);
            ICollection<Car> cars = new List<Car>();
            foreach (var c in carDtos)
            {
                Car car = new Car()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance
                };
                ICollection<PartCar> partCars = new List<PartCar>();
                foreach (var d in c.Parts.Select(p => p.Id).Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == d))
                    {
                        continue;
                    }

                    partCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = d
                    });
                }
                car.PartCars = partCars;
                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}";
        }

        //Task 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ImportCustomerDto[] customerDtos = Deserialize<ImportCustomerDto[]>(inputXml, "Customers");
            Customer[] customer = customerDtos.Select(d => new Customer()
            {
                Name = d.Name,
                BirthDate = DateTime.Parse(d.BirthDate, CultureInfo.InvariantCulture),
                IsYoungDriver = d.IsYoungDriver,
            }).ToArray();
            context.Customers.AddRange(customer);
            context.SaveChanges();
            return $"Successfully imported {customer.Length}";
        }

        //Task 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            ImportSalesDto[] salesDto = Deserialize<ImportSalesDto[]>(inputXml, "Sales");
            ICollection<Sale> sales = new List<Sale>();
            foreach (var s in salesDto)
            {
                if (!context.Cars.Any(c => c.Id == s.CarId))
                {
                    continue;
                }
                Sale sale = new Sale()
                {
                    Discount = s.Discount,
                    CarId = s.CarId,
                    CustomerId = s.CustomerId
                };
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}";
        }

        //Export
        //Task 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            ExportCarsWithDto[] exportCar = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                }).ToArray();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDto[]), xmlRoot);
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, exportCar, namespaces);
            return sb.ToString().TrimEnd();
        }

        //Task 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            ExportCarsBMWDto[] exportCar = context.Cars
                .Where(c => c.Make == "BMW")               
                .Select(c => new ExportCarsBMWDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                }).OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance).ToArray();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsBMWDto[]), xmlRoot);
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, exportCar, namespaces);
            return sb.ToString().TrimEnd();
        }

        //Task 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportSuppliersDto[] exportSuppliers = context.Suppliers.Where(s => !s.IsImporter)
                .Select(s => new ExportSuppliersDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                }).ToArray();
            return Serialize(exportSuppliers, "suppliers");
        }

        //Task 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarsWithPartsDto[] carsWithPartsDtos = context.Cars
                .Select(s => new ExportCarsWithPartsDto()
                {
                    Make = s.Make,
                    Model = s.Model,
                    TraveledDistance = s.TravelledDistance,
                    Parts = s.PartCars.Select(cp => new ExportCarPartsDto
                    {
                        Name = cp.Part.Name,
                        Price = cp.Part.Price,
                    }).OrderByDescending(p => p.Price).ToArray()

                }).OrderByDescending(s => s.TraveledDistance)
                .ThenBy(s => s.Model).Take(5).ToArray();
            return Serialize(carsWithPartsDtos, "cars");
        }

        //Task 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportCustomersCarsDto[] customersCarsDtos = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new ExportCustomersCarsDto()
                {
                    Name = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.Select(s => s.Car).SelectMany(s => s.PartCars).Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();
            return Serialize(customersCarsDtos, "customers");
        }

        //Task 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //ExportSalesWithDiscountDto[] sales = context.Sales
            //.Select(x => new ExportSalesWithDiscountDto()
            //{
            //Car = new ExportCarsWithDto()
            //{
            // Make = x.Car.Make,
            //Model = x.Car.Model,
            //TravelledDistance = x.Car.TravelledDistance
            //},
            //Discount = x.Discount,
            //CustomerName = x.Customer.Name,
            //Price = x.Car.PartCars.Sum(c => c.Part.Price),
            //PriceWithtDiscount = x.Car.PartCars.Sum(c => c.Part.Price) - x.Car.PartCars.Sum(c => c.Part.Price) * x.Discount / 100m,

            //})
            //.ToArray();
            //return Serialize(sales, "sales");
            const string root = "sales";

            var sales = context.Sales
                .Select(x => new ExportSalesWithDiscountDto
                {
                    Car = new ExportCarsWithDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = (decimal)x.Car.PartCars.Sum(c => c.Part.Price),
                    PriceWithtDiscount = x.Car.PartCars.Sum(c => c.Part.Price) - x.Car.PartCars.Sum(c => c.Part.Price) * x.Discount / 100m,

                })
                .ToList();

            return Serialize(sales, "sales");
        }


        //Helper
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer.Deserialize(reader);

            return dtos;
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}