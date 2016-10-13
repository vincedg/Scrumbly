using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GScrum.ViewModels
{
    public class BoardVM
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public DateTime CreatedAt { get; set; }

        public Nullable<DateTime> DeletedAt { get; set; }

        public bool BigNote { get; set; }
        
        public List<SelectListItem> AllBoards { get; set; }

        public string[] Columns { get; set; }

        public List<CardVM> Cards { get; set; }
    }
}