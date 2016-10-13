using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GScrum.ViewModels
{
    public class StickerVM
    {
        public int Id { get; set; }

        public int TaskId { get; set; } // fk

        public int StickerId { get; set; } // fk

        public Nullable<DateTime> DeletedAt { get; set; }
    }
}