using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Products
{
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductRepository _productrepo;

        public ViewProductsByNameUseCase(IProductRepository productRepo)
        {
            _productrepo = productRepo;
        }

        public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
        {
            return await _productrepo.GetProductsByNameAsync(name);
        }
    }
}
