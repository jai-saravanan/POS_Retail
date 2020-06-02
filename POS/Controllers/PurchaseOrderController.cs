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

        public ActionResult CreatePurchaseOrder()
        {
            return View(InitFormData());
        }

        private PurchaseOrderViewModel InitFormData()
        {
            PurchaseOrderViewModel purchaseOrderViewModel = new PurchaseOrderViewModel();
            purchaseOrderViewModel.Date = DateTime.Now;
            purchaseOrderViewModel.TaxData = _taxMasterService.GetAllTax();
            purchaseOrderViewModel.ProductData = _productService.GetProducts();
            purchaseOrderViewModel.SupplierData = _supplierService.GetAllSubliers();
            purchaseOrderViewModel.POId = _purchaseOrderService.GetLastPONumber() + 1;
            purchaseOrderViewModel.PONumber = "PO-" + (_purchaseOrderService.GetLastPONumber() + 1).ToString("0000");
            return purchaseOrderViewModel;
        }

        [HttpPost]
        public ActionResult CreatePurchaseOrder(PurchaseOrderViewModel purchaseOrderViewModel)
        {

            var isSaved = _purchaseOrderService.SavePODetails(purchaseOrderViewModel);
            return View(InitFormData());
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
                TotalAmt= _purchaseOrderService.GetTotalAmtForAllPO()
            });
        }

        [HttpGet]
        public JsonResult GetPOList(string supplierName, DateTime? fromDate, DateTime? toDate)
        {
            if (toDate.HasValue)
                toDate = toDate.Value.AddDays(1);
            return Json(new
            {
                data = _purchaseOrderService.GetPOList(new PurchaseOrderFilter()
                {
                    SupplierName = supplierName,
                    FromDate = fromDate,
                    ToDate = toDate
                })
            }, JsonRequestBehavior.AllowGet);
        }





    }
}