using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace batNotes.Models
{
    public class RangeDateTime
    {
        [DataType(DataType.DateTime)]
        public DateTime? From { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? To { get; set; }
    }
}