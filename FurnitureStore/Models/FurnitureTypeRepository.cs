using FurnitureStore.Models.Utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class FurnitureTypeRepository : IFurnitureTypeRepository
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public List<FurnitureType> GetAllFurnitureTypes()
        {
            List<FurnitureType> types = new List<FurnitureType>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    types = (List<FurnitureType>)session.CreateCriteria<FurnitureType>().List<FurnitureType>();
                    logger.Info("DB types get successfully!");
                    return types;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void Save(FurnitureType furnitureType)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(furnitureType);
                        transaction.Commit();
                    }
                    Console.WriteLine("DB save was successfull!");
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public FurnitureType GetFurnitureTypeById(Guid id)
        {
            FurnitureType fType = new FurnitureType();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    fType = (FurnitureType)session.Get<FurnitureType>(id);
                    logger.Info("Got furniture type successfully!");
                    return fType;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void RemoveFurnitureTypeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateFurnitureTypeById(FurnitureType furnitureType)
        {
            throw new NotImplementedException();
        }
    }
}