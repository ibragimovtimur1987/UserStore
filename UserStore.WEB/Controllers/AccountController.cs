using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using UserStore.Models;
using UserStore.BLL.DTO;
using System.Security.Claims;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Infrastructure;

namespace UserStore.Controllers
{
    public class AccountController : Controller
    {
        private IVideoService VideoService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IVideoService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
          //  await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password};
                ClaimsIdentity claim = await VideoService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    int? par = 1;
                    return RedirectToAction("Index", "Video", par);
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
           // await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = "user"
                };
                OperationDetails operationDetails = await VideoService.Create(userDto);
                if (operationDetails.Succedeed)
                {
                        int? par = 1;
                    return View("SuccessRegister");
                }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        //private async Task SetInitialDataAsync()
        //{
        //    //await UserService.SetInitialData(new UserDTO
        //    //{
        //    //    Email = "somemail@mail.ru",
        //    //    UserName = "somemail@mail.ru",
        //    //    Password = "ad46D_ewr3",
        //    //    Name = "Семен Семенович Горбунков",
        //    //    Address = "ул. Спортивная, д.30, кв.75",
        //    //    Role = "admin",
        //    //}, new List<string> { "user", "admin" });
        //}
    }
}