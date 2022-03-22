using Microsoft.Data.SqlClient;
using ORM.Domain.Models;
using ORM.Domain.Repositories;
using ORM.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

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
            string storedProcedure = @"CREATE PROCEDURE [dbo].[sp_GetOrders]
                                            AS
                                                SELECT * FROM Orders
                                            GO";

            _ = AddStoredProcedure(storedProcedure);
        }

        private static async Task AddStoredProcedure(string storedProcedure)
        {
            using (SqlConnection connection =
                new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=ORMfundamentals;Trusted_Connection=True;"))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(storedProcedure, connection);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
