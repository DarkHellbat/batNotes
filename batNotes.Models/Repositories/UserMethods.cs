using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace batNotes.Models.Repositories
{
    [Repository]
    public class UserMethods
    {
        private User current = new User();
        private ISession session;
        public UserMethods(ISession session)
        {
            this.session = session;
        }
        public User GetCurrentUser(IPrincipal user = null)
        {
            user = user ?? HttpContext.Current.User;
            if (user == null || user.Identity == null)
            {
                return null;
            }
            var currentUserId = user.Identity.GetUserId();
            current = user as User;
            long userId;
            if (string.IsNullOrEmpty(currentUserId) || !long.TryParse(currentUserId, out userId))
            {
                return null;
            }
            return Load(userId);
        }
        public User FindByLogin(string login)
        {
            var crit = session.CreateCriteria<User>();
            crit.Add(Restrictions.Eq("UserName", login));
            try
            {
                return crit.List<User>().FirstOrDefault();
            }
            catch
            {
                User user = null;
                return user;
            }
        }
        public void Change(User user)
        {
            using (var tr = session.BeginTransaction())
            {
                session.Update(user);
                tr.Commit();
            }
        }
        public User Load(long id)
        {
            return session.Load<User>(id);
        }
        public User RememberCurrent(User loggegin)
        {
            User user = loggegin;
            return user;
        }
        public List<User> GetAll()
        {
            return session.CreateCriteria<User>()
                .List<User>()
                .ToList();
        }

        public void Save(User user)
        {
            using (var tr = session.BeginTransaction())
            {
                session.Save(user);
                tr.Commit();
            }
        }
        public void SelectByStatus()
        { }
        public void GenerateSalt()
        { }
    }
}
