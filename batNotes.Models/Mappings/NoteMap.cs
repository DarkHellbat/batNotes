using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batNotes.Models.Mappings
{
    public class NoteMap : ClassMap<Note>
    {
        public NoteMap()
        {
            Id(n=>n.NoteId).GeneratedBy.Identity();
           References(n=>n.Author);
            Map(n=>n.Changed);
            Map(n=>n.Created);
            Map(n => n.Name).Length(50);
            Map(n => n.Text).Length(200);
            References(n => n.File);

        }
    }
}
