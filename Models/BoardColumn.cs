using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GScrum.Models
{
    public class BoardColumn
    {
        public int Id { get; set; }

        public string Title { get; set; }

        DateTime DeletedAt { get; set; }

        public int BoardId { get; set; } // fk
    }
}