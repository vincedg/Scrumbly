using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GScrum.Models
{
    public class TaskSticker
    {
        public int Id { get; set; }

        public int TaskId { get; set; } // fk

        public int StickerId { get; set; } // fk

        public DateTime DeletedAt { get; set; }
    }
}