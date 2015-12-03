using FurnitureStore.Models.Utils;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class UserRepository : IUserRepository
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void Save(User User)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(User);
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

        public User GetUserById(Guid id)
        {
            User User = new User();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    User = session.Get<User>(id);
                    Console.WriteLine("Logined successfully!");
                    return User;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void RemoveUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }


        public User Login(string login, string password)
        {
            User User = new User();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    List<User> users = (List<User>)session.CreateCriteria<User>().Add(Restrictions.Eq("Email", login)).Add(Restrictions.Eq("Password", password)).List<User>();
                    User = users.SingleOrDefault(x => x.EMAIL == login);
                    Console.WriteLine("Logined successfully!");
                    return User;
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