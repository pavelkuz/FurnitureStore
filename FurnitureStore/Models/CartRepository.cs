using FurnitureStore.Models.Utils;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class CartRepository : ICartRepository
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public List<Cart> GetAllCarts()
        {
            List<Cart> carts = new List<Cart>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    carts = (List<Cart>)session.CreateCriteria<Cart>().List<Cart>();
                    logger.Info("DB carts get successfully!");
                    return carts;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void Save(Cart Cart)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Cart);
                        transaction.Commit();
                    }
                    Console.WriteLine("DB save was successfull!");
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public Cart GetUnpayedCartByUser(User user)
        {
            Guid UserI = user.ID;

            Cart cart = new Cart();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    List<Cart> carts = (List<Cart>)session.CreateCriteria<Cart>().Add(Restrictions.Eq("IsPayed", false)).List<Cart>();
                    cart = carts.SingleOrDefault(x => x.USER == user);
                    logger.Info("Unpayed cart successfully have been get!");
                    return cart;
                    
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void RemoveCartById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }


        public Cart GetPayedCartByUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}