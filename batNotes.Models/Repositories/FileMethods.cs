using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace batNotes.Models.Repositories
{
    [Repository]
   public class FileMethods:Repository<File>
    {
        public FileMethods(ISession session):
            base(session)
        {
            this.session = session;
        }
      
    }
}
