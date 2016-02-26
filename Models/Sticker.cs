using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GScrum.Models
{
    public class Sticker
    {
        public int Id { get; set; }
        public int ColourId { get; set; } //fk
    }
}