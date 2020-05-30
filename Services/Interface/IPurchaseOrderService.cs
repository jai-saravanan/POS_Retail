using Domain.ViewModel;

namespace Services.Interface
{
    public interface IPurchaseOrderService
    {
        int GetLastPONumber();

        bool SavePODetails(PurchaseOrderViewModel purchaseOrderViewModel);
    }
}
