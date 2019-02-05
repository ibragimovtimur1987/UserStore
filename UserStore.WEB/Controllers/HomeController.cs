using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Interfaces;

namespace UserStore.Controllers
{
    public class HomeController : Controller
    {
        private IVideoService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IVideoService>();
            }
        }

        public ActionResult Index()
        {
            int? par = 1;
            return RedirectToAction("Index", "Video", par);
        }
        [Authorize(Roles="admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }
    }
}