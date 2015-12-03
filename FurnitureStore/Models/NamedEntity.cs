using FurnitureStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class NamedEntity : BasedEntity
    {

        protected virtual string Name { get; set; }

        //Added fro json serialization
        public string NAME { get { return Name; } set { Name = value; } }

        public NamedEntity(){}

        public NamedEntity(Guid Id, string Name) 
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}