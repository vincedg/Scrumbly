using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GScrum.Models
{
    public class Task
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public decimal X_Axis { get; set; }

        public decimal Y_Axis { get; set; }

        public int ColourId { get; set; }
    }
}