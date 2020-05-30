using Domain.ViewModel;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface ISupplierService
    {
        List<SupplierViewModel> GetAllSubliers();
    }
}
