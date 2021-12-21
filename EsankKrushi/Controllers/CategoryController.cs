using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsankKrushi.Models;

namespace EsankKrushi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult saveCategory(CategoryModel model)
        {
            try
            {
                return Json(new { message = (new CategoryModel().SaveCategory(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
   