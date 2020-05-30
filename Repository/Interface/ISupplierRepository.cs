using Persistance;
using System.Linq;

namespace Repository.Interface
{
    public interface ISupplierRepository
    {
        IQueryable<Supplier> GetAllSubliers();
    }
}
