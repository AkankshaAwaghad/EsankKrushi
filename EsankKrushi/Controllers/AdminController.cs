using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Esankkrushi.Models;
using System.Web.Security;

namespace Esankkrushi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin(AdminModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "Admin" && model.Password == "Admin@123")
                {
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password.");
                }
            }
            return View("..\\Admin\\Index", model);
        }

        public ActionResult UserDashBoard()
        {
            return View("..\\Contact\\Index");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Admin\\Index");
        }
    }
}
   