using System.Data.SqlClient;
using webapp.DB;
using webapp.Models;

namespace webapp.Repositories
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
    }

    public class ProductsRepository : IProductsRepository
    {
        private SqlConnection _connection;

        public ProductsRepository(IDBConnection connection)
        {
            _connection = connection.GetConnection();
        }

        public List<Product> GetAll()
        {
            try {
                List<Product> products = new List<Product>();

                string statement = "SELECT ProductID, ProductName, Quantity from Products";

                _connection.Open();

                SqlCommand command = new SqlCommand(statement, _connection);

                using (SqlDataReader _reader = command.ExecuteReader())
                {
                    while (_reader.Read())
                    {
                        Product _product = new Product()
                        {
                            ID = _reader.GetInt32(0),
                            Name = _reader.GetString(1),
                            Quantity = _reader.GetInt32(2)
                        };

                        products.Add(_product);
                    }
                }

                _connection.Close();

                return products;
            } finally {
                _connection.Close();
            }
        }
    }
}