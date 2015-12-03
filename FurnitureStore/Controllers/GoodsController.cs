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
        private FurnitureTypeRepository furnitureTypeRep;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public GoodsController()
        {
            this.repository = new GoodsRepository();
            this.furnitureTypeRep = new FurnitureTypeRepository();
        }

        public ActionResult Index()
        {
            var goods = this.repository.GetAllFurnitures();
            string json = JsonConvert.SerializeObject(goods, Formatting.Indented);
            JsonPresenter jp = new JsonPresenter(json);
            return View("Index", jp);
        }

        public ActionResult Create()
        {
            IEnumerable<SelectListItem> types = furnitureTypeRep.GetAllFurnitureTypes()
              .Select(c => new SelectListItem
              {
                  Value = c.ID.ToString(),
                  Text = c.TYPENAME
              });
            ViewBag.TypeID = types;
            return View();
        }

        [HttpPost]
        public ActionResult SubmitCreate(Goods goods)
        {
            string TypeID = Request.Params.Get("TypeID");
            goods.FURNITURETYPE = furnitureTypeRep.GetFurnitureTypeById(Guid.Parse(TypeID));
            this.repository.Save(goods);

            var allGoods = this.repository.GetAllFurnitures();
            string json = JsonConvert.SerializeObject(allGoods, Formatting.Indented);
            JsonPresenter jp = new JsonPresenter(json);
            return View("Index", jp);
        }
    }
}
