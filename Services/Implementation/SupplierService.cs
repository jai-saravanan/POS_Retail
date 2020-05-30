using Domain.ViewModel;
using Repository.Interface;
using Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
{
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public List<SupplierViewModel> GetAllSubliers()
        {
            return _supplierRepository.GetAllSubliers().Select(x => new SupplierViewModel()
            {
                SupplierID = x.SupplierID,
                Address = x.Address,
                City = x.City,
                ContactNo = x.ContactNo,
                ID = x.ID,
                Name = x.Name,
                OpeningBalance = x.OpeningBalance
            }).ToList();
        }
    }
}
