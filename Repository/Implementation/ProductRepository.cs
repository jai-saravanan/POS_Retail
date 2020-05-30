using Persistance;
using Repository.Interface;
using System.Linq;

namespace Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private POSDbContext _dbContext;
        public ProductRepository(POSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> GetProducts()
        {
            return _dbContext.Products.Include("Purchase_Join").AsQueryable();
        }

        public Product GetProductsDetailById()
        {
            return _dbContext.Products.Include("Product_OpeningStock").FirstOrDefault();
        }

        public decimal GetPurchasePriceByProductId(int pid)
        {
            var price = _dbContext.Purchase_Join.Include("Purchase").Where(x => x.ProductID == pid)
                .OrderBy(x => x.Purchase.Date).Select(x => x.Price).FirstOrDefault();
            if (price == 0)
                price = _dbContext.Products.FirstOrDefault(x => x.PID == pid).PurchaseCost ?? 0;
            return price;
        }
    }
}
