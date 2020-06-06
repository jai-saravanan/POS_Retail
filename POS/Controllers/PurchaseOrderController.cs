using Domain.Enum;
using Domain.Model;
using Domain.ViewModel;
using Newtonsoft.Json;
using Services.Interface;
using System;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private ITaxMasterService _taxMasterService;
        private IProductService _productService;
        private IPurchaseOrderService _purchaseOrderService;
        private ISupplierService _supplierService;

        public PurchaseOrderController(ITaxMasterService taxMasterService,
            IProductService productService,
            IPurchaseOrderService purchaseOrderService,
            ISupplierService supplierService)
        {
            _taxMasterService = taxMasterService;
            _productService = productService;
            _purchaseOrderService = purchaseOrderService;
            _supplierService = supplierService;
        }

        [Route("PurchaseOrder/ManagePurchaseOrder/{status?}/{purchaseOrderId?}")]
        public ActionResult CreatePurchaseOrder(Status status = Status.Create, int? purchaseOrderId = null)
        {
            return View(InitFormData(status, purchaseOrderId));
        }

        private PurchaseOrderViewModel InitFormData(Status formStatus, int? purchaseOrderId = null)
        {
            PurchaseOrderViewModel purchaseOrderViewModel = new PurchaseOrderViewModel();
            purchaseOrderViewModel.TaxData = _taxMasterService.GetAllTax();
            purchaseOrderViewModel.ProductData = _productService.GetProducts();
            purchaseOrderViewModel.SupplierData = _supplierService.GetAllSubliers();
            if (formStatus == Status.Create)
            {
                purchaseOrderViewModel.Date = DateTime.Now;
                purchaseOrderViewModel.POId = _purchaseOrderService.GetLastPONumber() + 1;
                purchaseOrderViewModel.PONumber = "PO-" + (_purchaseOrderService.GetLastPONumber() + 1).ToString("0000");
            }
            else
            {
                var data = _purchaseOrderService.GetPurchaseOrderById(purchaseOrderId.Value);
                purchaseOrderViewModel.Date = data.Date;
                purchaseOrderViewModel.GrandTotal = data.GrandTotal;
                purchaseOrderViewModel.POId = data.POId;
                purchaseOrderViewModel.PONumber = data.PONumber.Trim();
                purchaseOrderViewModel.ProductDetail = data.ProductDetail;
                purchaseOrderViewModel.SubTotal = data.SubTotal;
                purchaseOrderViewModel.Supplier_ID = data.Supplier_ID.Trim();
                purchaseOrderViewModel.TaxType = data.TaxType.Trim();
                purchaseOrderViewModel.Terms = data.Terms?.Trim();
                purchaseOrderViewModel.VATAmount = data.VATAmount;
                purchaseOrderViewModel.VATPer = data.VATPer;
            }
            purchaseOrderViewModel.FormStatus = formStatus;
            return purchaseOrderViewModel;
        }

        [HttpPost]
        [Route("PurchaseOrder/ManagePurchaseOrder")]
        public ActionResult CreatePurchaseOrder(PurchaseOrderViewModel purchaseOrderViewModel)
        {

            var isSaved = _purchaseOrderService.SavePODetails(purchaseOrderViewModel);
            return RedirectToAction("ManagePurchaseOrder");
        }

        [HttpGet]
        public JsonResult GetPurchasePriceByProductId(int pid)
        {
            return Json(_productService.GetPurchasePriceByProductId(pid), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PurchaseOrderList()
        {
            return View(new POCumulativeViewModel()
            {
                SupplierData = _supplierService.GetAllSubliers(),
                TotalAmt = _purchaseOrderService.GetTotalAmtForAllPO()
            });
        }

        [HttpGet]
        public JsonResult GetPOList(int? supplierId, DateTime? fromDate, DateTime? toDate)
        {
            if (toDate.HasValue)
                toDate = toDate.Value.AddDays(1);
            return Json(new
            {
                data = _purchaseOrderService.GetPOList(new PurchaseOrderFilter()
                {
                    SupplierId = supplierId,
                    FromDate = fromDate,
                    ToDate = toDate
                })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("PurchaseOrder/DeletePurchaseOrder/{purchaseOrderId}")]
        public JsonResult DeletePurchaseOrder(int purchaseOrderId)
        {
            _purchaseOrderService.DeletePurchaseOrderById(purchaseOrderId);
            return Json(true, JsonRequestBehavior.AllowGet);
        }





    }
}