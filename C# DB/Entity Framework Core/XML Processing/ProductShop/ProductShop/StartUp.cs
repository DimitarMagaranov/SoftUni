using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            var usersXml = File.ReadAllText("../../../Datasets/users.xml");

            var productsXml = File.ReadAllText("../../../Datasets/products.xml");

            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");

            var result = ImportCategories(context, categoriesXml);

            Console.WriteLine(result);
        }

        //Reset Database
        public static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was succesfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Database was succesfully created!");
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";

            var usersResult = XmlConverter.Deserializer<ImportUserDTO>(inputXml, rootElement);

            var users = new List<User>();

            foreach (var userDto in usersResult)
            {
                User user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var productDtos = XmlConverter.Deserializer<ImportProductDTO>(inputXml, rootElement);

            var products = productDtos
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";

            var categoriesDtos = XmlConverter.Deserializer<ImportCategoryDTO>(inputXml, rootElement);

            var categories = categoriesDtos
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToList();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
    }
}