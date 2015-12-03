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
        public List<FurnitureType> GetAllFurnitureTypes()
        {
            throw new NotImplementedException();
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

        public FurnitureType GetFurnitureTypeById()
        {
            throw new NotImplementedException();
        }

        public void RemoveFurnitureTypeById()
        {
            throw new NotImplementedException();
        }

        public void UpdateFurnitureTypeById()
        {
            throw new NotImplementedException();
        }
    }
}