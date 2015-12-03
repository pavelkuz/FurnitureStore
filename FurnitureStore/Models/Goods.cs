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
        public string MATERIAL { get { return Material; } set { Material = value; } }
        public string COLOR { get { return Color; } set { Color = value; } }
        public string MANUFACTURER { get { return Manufacturer; } set { Manufacturer = value; } }
        public float LENGTH { get { return Length; } set { Length = value; } }
        public float WIDTH { get { return Width; } set { Width = value; } }
        public float HEIGHT { get { return Height; } set { Height = value; } }
        public Decimal PRICE { get { return Price; } set { Price = value; } }
        public string ADDITIONALINFORMATION { get { return AdditionalInformation; } set { AdditionalInformation = value; } }
        public FurnitureType FURNITURETYPE { get { return FurnitureType; } set { FurnitureType = value; } }



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