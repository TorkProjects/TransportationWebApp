using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataContracts;
using DataContracts.DL;

namespace TransportSmart.Web.Controllers
{
    public class AccountController : Controller
    {
        //private UnitOfWork unitOfWork = new UnitOfWork();
        private IUsersRepository userRepository;
        public AccountController()
        {
            this.userRepository = new UsersRepository(new TransportEntities());
        }


        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult GetUserDetails(Users user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Login", user);
                }

                var currenUser = userRepository.GetUserNameAndPassword(user.UserName, user.Password);
                if (null != currenUser)
                {
                    return RedirectToAction("MainDashboard", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "إسم المستخدم أو الرمز السري  غير صحيح");
                    return View("Login");
                }

            }
            catch (Exception ex)
            {
                return View("Login");
            }
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}