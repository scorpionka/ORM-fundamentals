using Moq;
using NUnit.Framework;
using ORM.Domain.Models;
using ORM.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace ORM.Tests
{
    public class ORM_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllProductsTest()
        {
            var products = new List<Product>();
            products.Add(new Product());

            IRepository<Product> productRepositoryStub = Mock.Of<IRepository<Product>>(x => x.GetAll() == products);

            var sequence = productRepositoryStub.GetAll();

            Assert.That(sequence, Is.EqualTo(products));
        }

        [Test]
        public void GetProductByIdTest()
        {
            var product = new Product();
            IRepository<Product> productRepositoryStub =
                Mock.Of<IRepository<Product>>(x => x.GetById(It.IsAny<int>()) == product);

            var actual = productRepositoryStub.GetById(5);

            Assert.That(actual, Is.EqualTo(product));
        }

        [Test]
        public void GetAllOrdersTest()
        {
            var orders = new List<Order>();
            orders.Add(new Order());

            IRepository<Order> orderRepositoryStub = Mock.Of<IRepository<Order>>(x => x.GetAll() == orders);

            var sequence = orderRepositoryStub.GetAll();

            Assert.That(sequence, Is.EqualTo(orders));
        }

        [Test]
        public void GetOrderByIdTest()
        {
            var order = new Order();
            IRepository<Order> orderRepositoryStub =
                Mock.Of<IRepository<Order>>(x => x.GetById(It.IsAny<int>()) == order);

            var actual = orderRepositoryStub.GetById(5);

            Assert.That(actual, Is.EqualTo(order));
        }

        [Test]
        public void GetAllOrdersWithFilterTest()
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order());

            var orderRepositoryStub = new Mock<IRepository<Order>>();

            orderRepositoryStub
                .Setup(x => x.GetAllWithFilter(It.IsAny<Func<Order, bool>>()))
                .Returns(orders);

            var orderRepository = orderRepositoryStub.Object;

            Assert.That(orderRepository.GetAllWithFilter(x => x.Id > 7), Is.EqualTo(orders));
        }

        [Test]
        public void DeleteOrdersInBulkWithFilterTest()
        {
            var orderRepositoryStub = new Mock<IRepository<Order>>();

            orderRepositoryStub
                .Setup(x => x.DeleteInBulkWithFilter(It.IsAny<Func<Order, bool>>()))
                .Returns(5);

            var orderRepository = orderRepositoryStub.Object;

            Assert.That(orderRepository.DeleteInBulkWithFilter(x => x.Id > 7), Is.EqualTo(5));
        }
    }
}