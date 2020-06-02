using Domain.Model;
using Domain.ViewModel;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IPurchaseOrderService
    {
        int GetLastPONumber();

        bool SavePODetails(PurchaseOrderViewModel purchaseOrderViewModel);

        List<PurchaseOrderDetailList> GetPOList(PurchaseOrderFilter purchaseOrderFilter);

        decimal GetTotalAmtForAllPO();
    }
}
