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
    public class RoleController : Controller
    {
        private RoleRepository repository;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public RoleController()
        {
            this.repository = new RoleRepository();
        }

        public ActionResult Index()
        {
            var roles = this.repository.GetAllRoles();

            string json = JsonConvert.SerializeObject(roles, Formatting.Indented);

            JsonPresenter jp = new JsonPresenter(json);

            return View("Index", jp);
        }

        public ActionResult Create()
        {
            //While reating new role, i'm test for role of current logined creator
            string UserID = Request.Cookies.Get("UserID").Value.ToString();
            UserRepository rep = new UserRepository();
            RoleRepository roleRep = new RoleRepository();
            User user = rep.GetUserById(Guid.Parse(UserID));
            Role userRole = roleRep.GetRoleById(user.ROLE.ID);
            if (userRole.NAME.Equals("Administrator")) 
            { 
                return View();
            }
            return View();
            
        }

        public ActionResult Edit(string Id)
        {
            var role = this.repository.GetRoleById(Guid.Parse(Id));
            return View(role);
        }

        public ActionResult Delete(string Id)
        {
            this.repository.RemoveRoleById(Guid.Parse(Id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SubmitEdit(Role role)
        {
            this.repository.UpdateRoleById(role);

            return RedirectToAction("Index");
        }

        public ActionResult SubmitCreate(Role role)
        {
            role.ID = Guid.NewGuid();
            role.AddedDateSerialized = DateTime.Now;

            this.repository.Save(role);

            return RedirectToAction("Index");
        }

    }
}
