using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class Goods : NamedEntity, IGoods
    {
        protected virtual string Material { get; set; }
        protected virtual string Color { get; set; }
        protected virtual string Manufacturer { get; set; }
        protected virtual float Length { get; set; }
        protected virtual float Width { get; set; }
        protected virtual float Height { get; set; }
        protected virtual Decimal Price { get; set; }
        protected virtual string AdditionalInformation { get; set; }
        protected virtual FurnitureType FurnitureType { get; set; }

        //added fro serialization to json
        public string MATERIAL { get { return Material; } }
        public string COLOR { get { return Color; } }
        public string MANUFACTURER { get { return Manufacturer; } }
        public float LENGTH { get { return Length; } }
        public float WIDTH { get { return Width; } }
        public float HEIGHT { get { return Height; } }
        public Decimal PRICE { get { return Price; } }
        public string ADDITIONALINFORMATION { get { return AdditionalInformation; } }
        public FurnitureType FURNITURETYPE { get { return FurnitureType; } }



        public Goods() { }

        public Goods(Guid Id, string Name, string Material, string Color, string Manufacturer, float Length, float Width, float Height, Decimal Price, string AdditionalInformation, FurnitureType FurnitureType) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Material = Material;
            this.Manufacturer = Manufacturer;
            this.Color = Color;
            this.Length = Length;
            this.Width = Width;
            this.Height = Height;
            this.Price = Price;
            this.AdditionalInformation = AdditionalInformation;
            this.FurnitureType = FurnitureType;
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
}