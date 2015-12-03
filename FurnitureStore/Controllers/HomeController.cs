using FurnitureStore.Models;
using FurnitureStore.Models;
using FurnitureStore.Models.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureStore.Controllers
{
    public class HomeController : Controller
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private GoodsRepository goodsRepository;
        private User loginedUser;

        public HomeController()
        {
            this.userRepository = new UserRepository();
            this.roleRepository = new RoleRepository();
            this.goodsRepository = new GoodsRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            string login = Request.Params.Get("Email");
            string password = Request.Params.Get("Password");

            //Authorization sample, i will set it in actions for verify user
            loginedUser = userRepository.Login(login, password);
            if (loginedUser != null) { 
                Role userRole = roleRepository.GetRoleById(loginedUser.ROLE.ID);
                HttpCookie UserID = new HttpCookie("UserID", loginedUser.ID.ToString());
                //// Set the cookie value.
                //UserID.Value = loginedUser.ID.ToString();
                // Set the cookie expiration date.
                UserID.Expires = DateTime.Now.AddHours(30);
                // Add the cookie.
                Response.Cookies.Add(UserID);
                if (userRole.NAME.Equals("Administrator"))
                {
                    return View("Logined", loginedUser);
                }
                var goods = this.goodsRepository.GetAllFurnitures();
                string json = JsonConvert.SerializeObject(goods, Formatting.Indented);
                JsonPresenter jp = new JsonPresenter(json);
                return View("LoginedClient", jp);
            }
            return View("Error");
        }

        public ActionResult Register()
        {
            RoleRepository rep = new RoleRepository();
            IEnumerable<SelectListItem> roles = rep.GetAllRoles()
              .Select(c => new SelectListItem
              {
                  Value = c.ID.ToString(),
                  Text = c.NAME
              });
            ViewBag.RoleId = roles;
            return View();
        }

        [HttpPost]
        public ActionResult SubmitRegister(User user)
        {
            Role selectedRole = roleRepository.GetRoleById(Guid.Parse(Request.Params.Get("RoleId")));
            user.ID = Guid.NewGuid();
            user.REGISTRATIONDATE = DateTime.Now;
            user.ROLE = selectedRole;
            userRepository.Save(user);
            return View("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Abandon();
            HttpContext.User = null;
            return View("Index");
        }
    }
}
