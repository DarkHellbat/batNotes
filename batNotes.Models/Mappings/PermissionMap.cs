using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batNotes.Models.Mappings
{
    public class PermissionMap : ClassMap<Permission>
    {
        public PermissionMap()
        {
            Id(p => p.PermissionID).GeneratedBy.Identity();
            Map(p => p.Description).Length(100);
            Map(p => p.PermissionLevel);
        }
    }
}
