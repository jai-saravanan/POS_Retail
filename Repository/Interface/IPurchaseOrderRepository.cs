using Persistance;

namespace Repository.Interface
{
    public interface IPurchaseOrderRepository
    {
        int GetLastPONumber();

        bool SavePODetails(PurchaseOrder purchaseOrder);
    }
}
