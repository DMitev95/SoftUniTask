using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.Categories_Products;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string filePath;
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext dbContext = new ProductShopContext();
            //Task 1 JSON
            //string inputJson = File.ReadAllText("../../../Datasets/users.json");

            //Task 2 JSON
            //string inputJson = File.ReadAllText("../../../Datasets/products.json");

            //Task 3 JSON
            //string inputJson = File.ReadAllText("../../../Datasets/categories.json");

            //Task 4 JSON
            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine();

            //Task 5
            //InitializeOutputFilePath("products-in-range.json");
            //string json = GetProductsInRange(dbContext);
            //File.WriteAllText(filePath, json);

            //Task 6
            InitializeOutputFilePath("users-and-products.json");
            string json = GetUsersWithProducts(dbContext);
            File.WriteAllText(filePath, json);

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            //Console.WriteLine("EVALA!!!!");
        }

        //1.Import Data
        //Task 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] userDto = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);
            ICollection<User> users = new List<User>();
            foreach (ImportUserDto item in userDto)
            {
                User user = Mapper.Map<User>(item);
                users.Add(user);
            }
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Task 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDto[] productDto = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            ICollection<Product> products = new List<Product>();
            foreach (ImportProductDto item in productDto)
            {
                if (!IsValid(item))
                {
                    continue;
                }
                Product product = Mapper.Map<Product>(item);
                products.Add(product);
            }
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Task 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoriesDto[] cateryDto = JsonConvert.DeserializeObject<ImportCategoriesDto[]>(inputJson);
            ICollection<Category> categories = new List<Category>();
            foreach (ImportCategoriesDto item in cateryDto)
            {
                if (!IsValid(item))
                {
                    continue;
                }
                Category category = Mapper.Map<Category>(item);
                categories.Add(category);
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Task 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoriesProductsDto[] cateryProductDto = JsonConvert.DeserializeObject<ImportCategoriesProductsDto[]>(inputJson);
            ICollection<CategoryProduct> categories = new List<CategoryProduct>();
            foreach (ImportCategoriesProductsDto item in cateryProductDto)
            {
                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(item);
                categories.Add(categoryProduct);
            }
            context.CategoryProducts.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //2.Export Data
        //Task 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p=>p.Price)
                .ProjectTo<ExportProductsDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        //Task 6 
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUsersWithSoldProductDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }

        //Task 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
                .ProjectTo<ExportUsersWithFullProductInfoDto>()
                .ToArray();

            var serDto = new ExportUsersInfoDto()
            { 
               UsersCount = users.Length,
               Users = users
            };
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };
            string json = JsonConvert.SerializeObject(serDto, Formatting.Indented, settings);
            return json;

        }


        //Validation Property
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult);
            return isValid;
        }


        //Path Initialization
        private static void InitializeOutputFilePath(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/", fileName);
        }
    }
}