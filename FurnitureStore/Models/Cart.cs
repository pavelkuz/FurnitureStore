using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class Cart : BasedEntity
    {

        protected virtual User User { get; set; }
        protected virtual DateTime? PayDate { get; set; }
        protected virtual bool IsPayed { get; set; }
        protected virtual IList<Goods> Orders { get; set; }

        //Added for serialization to json
        public User USER { get { return User; }}
        public DateTime? PAYDATE { get { return PayDate; } }
        public bool ISPAYED { get { return IsPayed; } }
        public IList<Goods> ORDERS { get { return Orders; } }

        //default constructor
        public Cart() { }

        public Cart(Guid Id, User User, DateTime? PayDate, bool IsPayed, IList<Goods> Orders)
        {
            this.Id = Id;
            this.User = User;
            this.PayDate = PayDate;
            this.IsPayed = IsPayed;
            this.Orders = Orders;
        }
    }
}