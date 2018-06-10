using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using batNotes.Models;

namespace batNotes.Models.Repositories
{
    [Repository]
   public class NotesMethods : Repository<Note>
    {
        public NotesMethods(ISession session):
            base(session)
        {
            this.session = session;
        }

        protected virtual void SetupFilter(ICriteria crit, NotesFilter filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    crit.Add(Restrictions.Like("Name", filter.Name, MatchMode.Anywhere));
                }
                if (filter.CreationDate != null)
                {
                    if (filter.CreationDate.From.HasValue)
                    {
                        crit.Add(Restrictions.Ge("Created", filter.CreationDate.From.Value));
                    }
                    if (filter.CreationDate.To.HasValue)
                    {
                        crit.Add(Restrictions.Le("Created", filter.CreationDate.To.Value));
                    }
                }
                if (filter.ChangingDate != null)
                {
                    if (filter.ChangingDate.From.HasValue)
                    {
                        crit.Add(Restrictions.Ge("Changed", filter.CreationDate.From.Value));
                    }
                    if (filter.CreationDate.To.HasValue)
                    {
                        crit.Add(Restrictions.Le("Changed", filter.CreationDate.To.Value));
                    }
                }
            }
        }


        public List<Note> GetAll()
        {
            return session.CreateCriteria<Note>().List<Note>().ToList();
        }
        public IList<Note> GetUsersNotes(User user, NotesFilter filter = null, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<Note>();
            SetupFilter(crit, filter);
            crit.Add(Restrictions.Eq("Author.Id", user.Id));
            if (options != null)
            {
                SetFetchOptions(crit, options);
            }
            return crit.List<Note>();

        }
    }
}
