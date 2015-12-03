using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FurnitureStore.Models;

namespace FurnitureStore.Models
{
    public class FurnitureType : BasedEntity
    {
        protected virtual string TypeName { get; set; }

        //Added for serialization to json
        public string TYPENAME
        {
            get { return TypeName; } set { TypeName = value; }
        }

        public FurnitureType() { }

        public FurnitureType(Guid Id, string TypeName) 
        {
            this.Id = Id;
            this.TypeName = TypeName;
        }
    }
}