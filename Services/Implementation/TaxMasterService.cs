using Domain.ViewModel;
using Repository.Interface;
using Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
{
    public class TaxMasterService : ITaxMasterService
    {

        private ITaxMasterRepository _taxMasterRepository;
        public TaxMasterService(ITaxMasterRepository taxMasterRepository)
        {
            _taxMasterRepository = taxMasterRepository;
        }

        public List<TaxMasterViewModel> GetAllTax()
        {
            return _taxMasterRepository.GetAllTax().Select(x => new TaxMasterViewModel()
            {
                TaxName = x.TaxName,
                Percentage = x.Percentage
            }).ToList();
        }
    }
}
