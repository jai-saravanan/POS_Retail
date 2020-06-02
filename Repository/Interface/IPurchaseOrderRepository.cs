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

        bool SavePODetails(PurchaseOrder purchaseOrder);

        List<PurchaseOrderDetailList> GetPOList(PurchaseOrderFilter purchaseOrderFilter);

        decimal GetTotalAmtForAllPO();

    }
}
