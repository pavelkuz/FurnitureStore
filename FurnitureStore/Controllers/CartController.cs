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
    public class CartController : Controller
    {
        private CartRepository repository;
        private UserRepository userRepository;
        private GoodsRepository goodsRepository;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public CartController()
        {
            this.repository = new CartRepository();
            this.userRepository = new UserRepository();
            this.goodsRepository = new GoodsRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(string Id)
        {
            //While reating new role, i'm test for role of current logined creator
            string UserID = Request.Cookies.Get("UserID").Value.ToString();
            UserRepository rep = new UserRepository();
            RoleRepository roleRep = new RoleRepository();
            User user = rep.GetUserById(Guid.Parse(UserID));
            Cart cart = repository.GetUnpayedCartByUser(user);
            if (cart != null)
            {
                cart.ORDERS.Add(goodsRepository.GetFurnitureById(Guid.Parse(Id)));
                var goods = cart.ORDERS;
                string json = JsonConvert.SerializeObject(goods, Formatting.Indented);
                JsonPresenter jp = new JsonPresenter(json);
                return View("Index", jp);
            }
            else {
                List<Goods> orders = new List<Goods>();
                Cart newCart = new Cart(Guid.NewGuid(), user, null, false, orders);
                newCart.ORDERS.Add(goodsRepository.GetFurnitureById(Guid.Parse(Id)));
                repository.Save(newCart);
                var allFurnitures = goodsRepository.GetAllFurnituresInCart(user);
                string json = JsonConvert.SerializeObject(allFurnitures, Formatting.Indented);
                JsonPresenter jp = new JsonPresenter(json);
                return View("Index", jp);
            }
        }

    }
}
