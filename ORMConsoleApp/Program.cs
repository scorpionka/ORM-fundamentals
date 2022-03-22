using ORM.Domain.Enums;
using ORM.Domain.Models;
using ORM.Domain.Repositories;
using ORM.Domain.Repositories.Interfaces;
using System;

namespace ORMConsoleApp
{
    internal class Program
    {
        private readonly IRepository<Product> productRepository = null;
        private readonly IRepository<Order> orderRepository = null;

        public Program()
        {
            this.productRepository = new Repository<Product>();
            this.orderRepository = new Repository<Order>();
        }

        public Program(IRepository<Product> productRepository, IRepository<Order> orderRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        static void Main(string[] args)
        {
            ProgramServicesProvider.RunServicesProvider(args);
        }

        public void Run()
        {
            //add products
            Product product1 = new Product
            {
                Name = "HP",
                Description = "Laptop",
                Weight = 2000,
                Height = 300,
                Width = 25,
                Length = 400
            };
            Product product2 = new Product
            {
                Name = "Lenovo",
                Description = "Laptop",
                Weight = 2100,
                Height = 310,
                Width = 30,
                Length = 390
            };

            productRepository.Insert(product1);
            productRepository.Insert(product2);
            productRepository.Save();

            //add orders
            Order order1 = new Order
            {
                OrderStatus = OrderStatus.InProgress,
                CreatedDate = new DateTime(2022, 1, 2),
                UpdatedDate = new DateTime(2022, 1, 3),
                ProductId = 1,
            };
            Order order2 = new Order
            {
                OrderStatus = OrderStatus.Done,
                CreatedDate = new DateTime(2022, 2, 14),
                UpdatedDate = new DateTime(2022, 3, 13),
                ProductId = 2,
            };

            orderRepository.Insert(order1);
            orderRepository.Insert(order2);
            orderRepository.Save();

            var product = productRepository.GetById(1);
            var order = orderRepository.GetById(2);

            //update product
            product1.Name = "Dell";
            product1.Description = "Laptop";
            product1.Weight = 1500;
            product1.Height = 250;
            product1.Width = 20;
            product1.Length = 350;

            productRepository.Update(product1);
            productRepository.Save();

            //update order
            order1.OrderStatus = OrderStatus.Cancelled;
            order1.CreatedDate = new DateTime(2022, 2, 17);
            order1.UpdatedDate = new DateTime(2022, 3, 21);
            order1.ProductId = 1;

            orderRepository.Update(order1);
            orderRepository.Save();

            //delete product
            productRepository.Delete(product2.Id);
            productRepository.Save();

            //delete order
            orderRepository.Delete(order1.Id);
            orderRepository.Save();

            //get all products
            var products = productRepository.GetAll();

            //get all orders
            var orders = orderRepository.GetAll();
        }
    }
}
