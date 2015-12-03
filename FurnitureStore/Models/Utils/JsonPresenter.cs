using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models.Utils
{
    public class JsonPresenter
    {
        private string JsonFormatedData { get; set; }

        public JsonPresenter() { }

        public JsonPresenter(string JsonFormatedData)
        {
            this.JsonFormatedData = JsonFormatedData;
        }

        public string GetData()
        {
            return JsonFormatedData;
        }
    }
}