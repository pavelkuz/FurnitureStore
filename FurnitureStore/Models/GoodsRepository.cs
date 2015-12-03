using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using FurnitureStore.Models.Utils;
using NHibernate.Criterion;

namespace FurnitureStore.Models
{
    public class GoodsRepository : IGoodsRepository
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public GoodsRepository()
        {
        }

        public List<Goods> GetAllFurnitures()
        {
            List<Goods> Goods = new List<Goods>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Goods = (List<Goods>)session.CreateCriteria<Goods>().List<Goods>();
                    logger.Info("DB goods get successfully!");
                    return Goods;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public Goods GetFurnitureById(Guid id)
        {
            Goods goods = new Goods();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    goods = (Goods)session.Get<Goods>(id);
                    logger.Info("Got goods successfully!");
                    return goods;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void Save(Goods furniture)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(furniture);
                        transaction.Commit();
                    }
                    Console.WriteLine("DB save was successfull!");
                }
            }
            catch (Exception e) {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void RemoveFurnitureById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateFurniture(Goods goods)
        {
            throw new NotImplementedException();
        }

        public List<Goods> Buy(List<Goods> goods, User user)
        {
            throw new NotImplementedException();
        }

        public List<Goods> Add(Goods goods, List<Goods> allGoods)
        {
            throw new NotImplementedException();
        }

        public List<Goods> GetAllFurnituresInCart(User user)
        {
            throw new NotImplementedException();
        }
    }
}