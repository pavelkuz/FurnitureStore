using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    //Base class with id for future classes wich extends this
    public class BasedEntity
    {
        protected virtual Guid Id { get; set; }

        //Added fro json serialization
        public Guid ID { get { return Id; } set { Id = value; } }

        public BasedEntity() { }

        public BasedEntity(Guid Id) 
        {
            this.Id = Id;
        }
    }
}