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
    public class GoodsController : Controller
    {
        private GoodsRepository repository;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public GoodsController()
        {
            this.repository = new GoodsRepository();
        }

        public ActionResult Index()
        {
            var goods = this.repository.GetAllFurnitures();
            string json = JsonConvert.SerializeObject(goods, Formatting.Indented);
            JsonPresenter jp = new JsonPresenter(json);
            return View("Index", jp);
        }
    }
}
