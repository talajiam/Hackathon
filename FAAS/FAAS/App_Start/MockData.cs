using FAAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TescoFAAS.Entities;

namespace FAAS.App_Start
{
    public static class MockData
    {
        public static List<Tenat> Tenants { get; set; }

        public static List<Product> Products { get; set; }

        public static List<ProductTenat> ProductTenant { get; set; }

        public static List<User> Users { get; set; }

        public static List<DellyOrder> mockDellyOrder { get; set; }

        public static List<UserOrder> userOrders { get; set; }

        static MockData()
        {
            Tenants = new List<Tenat>();

            Products = new List<Product>();

            ProductTenant = new List<ProductTenat>();

            Users = new List<User>();

            mockDellyOrder = new List<DellyOrder>();

            userOrders = new List<UserOrder>();

            InitializeProducts();
            InitializeProductTenant();
            InitializeTenant();
            InitializeUsers();
            InitializeMockDellyOrders();
        }

        public static void InitializeMockDellyOrders()
        {
            mockDellyOrder.Add(new DellyOrder() { ProductId = 1, Name = "Bread", ImageUrl = "/Images/Products/bread.jpg", TotalOrder = 10, PendingOrder = 9, CompletedOrder = 1 });
            mockDellyOrder.Add(new DellyOrder() { ProductId = 2, Name = "Bangers and Mash", ImageUrl = "/Images/Products/Bangers and mash.jpg", TotalOrder = 20, PendingOrder = 19, CompletedOrder = 1 });
            mockDellyOrder.Add(new DellyOrder() { ProductId = 3, Name = "Product 3", TotalOrder = 30, PendingOrder = 20, CompletedOrder = 10 });
            mockDellyOrder.Add(new DellyOrder() { ProductId = 4, Name = "Product 4", TotalOrder = 5, PendingOrder = 5, CompletedOrder = 0 });

        }

        public static void InitializeTenant()
        {
            Tenants.Add(new Tenat() { Id = 1, Name = "Palatine Property Solutions", CSSUrl = "", LogoUrl = "/Images/Products/Client1.jpg", URL = "palatine.tesco-faas.com" });
            Tenants.Add(new Tenat() { Id = 2, Name = "Brilliant Technology", CSSUrl = "", LogoUrl = "/Images/Products/Client2.png", URL = "brilliant.tesco-faas.com" });
        }

        public static void InitializeProducts()
        {
            Products.Add(new Product() { ProductId = 1, Name = "Bread", Price = 4, ImageUrl = "/Images/Products/bread.jpg", Calories = 200 });
            Products.Add(new Product() { ProductId = 2, Name = "Fish and Chips", Price = 3, ImageUrl = "/Images/Products/fish and chips.jpg", Calories = 250 });
            Products.Add(new Product() { ProductId = 3, Name = "Bangers and Mash", Price = 4, ImageUrl = "/Images/Products/Bangers and mash.jpg", Calories = 180 });
            Products.Add(new Product() { ProductId = 4, Name = "Bluemoon Burger", Price = 2, ImageUrl = "/Images/Products/Bluemoon Burger.jpg", Calories = 210 });
            Products.Add(new Product() { ProductId = 5, Name = "Christmas Pudding", Price = 5, ImageUrl = "/Images/Products/Christmas pudding.JPG", Calories = 190 });
            Products.Add(new Product() { ProductId = 6, Name = "Bedfordshire Clanger", Price = 3, ImageUrl = "/Images/Products/Bedfordshire clanger.jpg", Calories = 260 });
            Products.Add(new Product() { ProductId = 7, Name = "Pasty", Price = 4, ImageUrl = "/Images/Products/pasty.jpeg", Calories = 160 });
            Products.Add(new Product() { ProductId = 8, Name = "Stottie Cake", Price = 2, ImageUrl = "/Images/Products/Stottie cake.JPG", Calories = 200 });
            Products.Add(new Product() { ProductId = 9, Name = "Salmon and Cream Cheese Sandwich", Price = 3, ImageUrl = "/Images/Products/Salmon and cream cheese sandwich.jpg", Calories = 280 });
        }

        public static void InitializeProductTenant()
        {
            ProductTenant.Add(new ProductTenat() { Id = 1, ProductId = 1, TenatId = 1, Price = 3.5 });
            ProductTenant.Add(new ProductTenat() { Id = 2, ProductId = 1, TenatId = 2, Price = 4 });
            ProductTenant.Add(new ProductTenat() { Id = 3, ProductId = 2, TenatId = 1, Price = 3 });
            ProductTenant.Add(new ProductTenat() { Id = 4, ProductId = 2, TenatId = 2, Price = 3 });
            ProductTenant.Add(new ProductTenat() { Id = 5, ProductId = 3, TenatId = 1, Price = 3.5 });
            ProductTenant.Add(new ProductTenat() { Id = 6, ProductId = 3, TenatId = 2, Price = 3.5 });
            ProductTenant.Add(new ProductTenat() { Id = 7, ProductId = 4, TenatId = 1, Price = 2 });
            ProductTenant.Add(new ProductTenat() { Id = 8, ProductId = 4, TenatId = 2, Price = 2 });
            ProductTenant.Add(new ProductTenat() { Id = 9, ProductId = 5, TenatId = 1, Price = 4 });
            //ProductTenant.Add(new ProductTenat() { Id = 10, ProductId = 5, TenatId = 2, Price = 2.4 });
            ProductTenant.Add(new ProductTenat() { Id = 11, ProductId = 6, TenatId = 1, Price = 2.5 });
            ProductTenant.Add(new ProductTenat() { Id = 12, ProductId = 6, TenatId = 2, Price = 2.4 });
            ProductTenant.Add(new ProductTenat() { Id = 13, ProductId = 7, TenatId = 1, Price = 4 });
            //ProductTenant.Add(new ProductTenat() { Id = 14, ProductId = 7, TenatId = 2, Price = 2.4 });
            ProductTenant.Add(new ProductTenat() { Id = 15, ProductId = 8, TenatId = 1, Price = 2 });
            ProductTenant.Add(new ProductTenat() { Id = 16, ProductId = 8, TenatId = 2, Price = 1.5 });
            ProductTenant.Add(new ProductTenat() { Id = 17, ProductId = 9, TenatId = 1, Price = 2.8 });
            ProductTenant.Add(new ProductTenat() { Id = 18, ProductId = 9, TenatId = 2, Price = 2.5 });

        }

        public static void InitializeUsers()
        {
            Users.Add(new User() { Id = 1, Name = "User1", Password = "123456789", TenantId = 1 });
            Users.Add(new User() { Id = 1, Name = "User2", Password = "123456789", TenantId = 1 });
            Users.Add(new User() { Id = 1, Name = "User3", Password = "123456789", TenantId = 2 });
            Users.Add(new User() { Id = 1, Name = "User4", Password = "123456789", TenantId = 2 });

        }
    }
}