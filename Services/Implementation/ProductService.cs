using Domain.ViewModel;
using Repository.Interface;
using Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts().Select(x => new ProductViewModel()
            {
                PID = x.PID,
                ProductCode = x.ProductCode,
                ProductName = x.ProductName,
                Barcode = x.Barcode,
                PurchaseUnit = x.PurchaseUnit
            }).ToList();
        }

        public decimal GetPurchasePriceByProductId(int pid)
        {
            return _productRepository.GetPurchasePriceByProductId(pid);
        }
    }
}
