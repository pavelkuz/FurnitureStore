using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Models
{
    interface ICartRepository
    {
        List<Cart> GetAllCarts();

        void Save(Cart Cart);

        Cart GetUnpayedCartByUser(User user);

        Cart GetPayedCartByUser(User user);

        void RemoveCartById(Guid id);

        void UpdateCart(Cart cart);
    }
}
