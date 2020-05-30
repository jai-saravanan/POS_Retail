using Persistance;
using System.Linq;

namespace Repository.Interface
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();

        Product GetProductsDetailById();

        decimal GetPurchasePriceByProductId(int pid);
    }
}
