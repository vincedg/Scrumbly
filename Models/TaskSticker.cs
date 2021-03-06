﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GScrum.Models
{
    public class TaskSticker
    {
        public int Id { get; set; }

        public int TaskId { get; set; } // fk

        public virtual Task Task { get; set; }

        public int StickerId { get; set; } // fk

        public virtual Sticker Sticker { get; set; }

        public Nullable<DateTime> DeletedAt { get; set; }
    }
}