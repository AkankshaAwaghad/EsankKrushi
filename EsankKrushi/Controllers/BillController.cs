using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsankKrushi.Models;


namespace EsankKrushi.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveBill(BillModel model)
        {
            try
            {
                return Json(new { message = (new BillModel().SaveBill(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

public ActionResult GetBillList(string CustomerName)
{
    try
    {
        return Json(new { model = (new BillModel().GetBillList(CustomerName)) }, JsonRequestBehavior.AllowGet);
    }
    catch (Exception ex)
    {
        return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
    }
}
        public JsonResult SearchCustomer(string Prefix)
        {

            try
            {

               return Json(new CustomerModel().SearchCustomer(Prefix), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        //public ActionResult DeleteBill(int Id)
        //{
        //    try
        //    {
        //        return Json(new { model = (new BillModel().deleteBill(Id)) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public ActionResult GetEditData(int Id)
        //{

        //    try
        //    {
        //        return Json(new { model = (new BillModel().EditData(Id)) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //   }
    }
}


