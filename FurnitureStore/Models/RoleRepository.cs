using FurnitureStore.Models.Utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class RoleRepository : IRoleRepository
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public List<Role> GetAllRoles()
        {
            List<Role> Roles = new List<Role>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Roles = (List<Role>)session.CreateCriteria<Role>().List<Role>();
                    logger.Info("DB roles get successfully!");
                    return Roles;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void Save(Role Role)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Role);
                        transaction.Commit();
                    }
                    logger.Info("DB save was successfull!");
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public Role GetRoleById(Guid Id)
        {
            Role Role = new Role();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Role = (Role)session.Get<Role>(Id);
                    logger.Info("Get role successfully!");
                    return Role;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void RemoveRoleById(Guid Id)
        {
            Role Role = new Role();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Role = (Role)session.Get<Role>(Id);

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Role);
                        transaction.Commit();
                    }
                    logger.Info("Role removed successfully!");
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void UpdateRoleById(Role role)
        {
            logger.Info(role.ID+" | "+role.NAME+" | "+role.AddedDateSerialized);
            //role.AddedDateSerialized = DateTime.Now;

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(role);
                        transaction.Commit();
                    }
                    logger.Info("DB update was successfull!");
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}