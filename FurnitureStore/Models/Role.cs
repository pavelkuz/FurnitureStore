using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class Role : NamedEntity
    {
        protected virtual DateTime AddedDate { get; set; }

        public DateTime AddedDateSerialized { get { return AddedDate; } set { AddedDate = value; } }

        public Role() { }

        public Role(Guid Id, string Name, DateTime AddedDate) 
        {
            this.Id = Id;
            this.Name = Name;
            this.AddedDate = AddedDate;
        }

        public Guid GetId() {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }
    }
}