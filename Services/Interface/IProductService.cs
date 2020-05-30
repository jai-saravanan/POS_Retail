using Domain.ViewModel;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IProductService
    {
        List<ProductViewModel> GetProducts();

        decimal GetPurchasePriceByProductId(int pid);
    }
}
