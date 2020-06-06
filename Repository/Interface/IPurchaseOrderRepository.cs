using Domain.Enum;
using Domain.Model;
using Persistance;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Repository.Interface
{
    public interface IPurchaseOrderRepository
    {
        int GetLastPONumber();

        bool SavePODetails(PurchaseOrder purchaseOrder, Status formStatus);

        List<PurchaseOrderDetailList> GetPOList(PurchaseOrderFilter purchaseOrderFilter);

        decimal GetTotalAmtForAllPO();

        PurchaseOrder GetPurchaseOrderById(int purchaseOrderId);

        void DeletePurchaseOrderById(int purchaseOrderId);

    }
}
