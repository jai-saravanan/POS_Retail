using Domain.ViewModel;
using Repository.Interface;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface ITaxMasterService
    {

        List<TaxMasterViewModel> GetAllTax();
    }
}
