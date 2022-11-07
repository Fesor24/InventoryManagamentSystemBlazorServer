using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _product;
        public ProductRepository()
        {
            _product = new List<Product>()
            {
                new Product
                {
                    ProductId= 1,
                    ProductName = "Bike",
                    Price= 130,
                    Quantity = 10
                    
                },

                new Product
                {
                      ProductId= 1,
                    ProductName = "Car",
                    Price= 1200,
                    Quantity = 5
                }

               
            };
        }
        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_product);

            return _product.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
