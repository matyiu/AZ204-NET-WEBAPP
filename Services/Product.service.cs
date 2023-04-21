using webapp.Models;
using webapp.Repositories;

namespace webapp.Services
{
    public interface IProductService
    {
        public List<Product> GetAll();
    }

    public class ProductService : IProductService
    {
        private IProductsRepository _repository;

        public ProductService(IProductsRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }
    }
}