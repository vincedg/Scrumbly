using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GScrum.Models
{
    public class Board
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public bool BigNote { get; set; }
    }
}