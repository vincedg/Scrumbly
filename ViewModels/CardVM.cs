using GScrum.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GScrum.ViewModels
{
    public class CardVM
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public Nullable<DateTime> DeletedAt { get; set; }

        public decimal X_Axis { get; set; }

        public decimal Y_Axis { get; set; }

        public int ColourId { get; set; }

        public string Colour { get; set; }

        public static void CreateCard(CardVM card)
        {
            using (var ctx = new GScrumContext()) {
                var colour = ctx.Colours.Where(c => c.Name == card.Colour).FirstOrDefault();
                ctx.Tasks.Add(new Models.Task
                {
                    CardNumber = card.CardNumber,
                    ColourId = colour.Id,
                    CreatedAt = DateTime.Now,
                    Description = "",
                    X_Axis = card.X_Axis,
                    Y_Axis = card.Y_Axis
                });
                ctx.SaveChanges();
            }
        }

        public static void EditCard(CardVM cardModel)
        {
            using (var ctx = new GScrumContext())
            {

                var card = ctx.Tasks.Where(c => c.CardNumber == cardModel.CardNumber).FirstOrDefault();
                card.Description = cardModel.Description;                
                ctx.SaveChanges();
            }
        }

        public static void MoveCard(CardVM cardModel)
        {
            using (var ctx = new GScrumContext())
            {

                var card = ctx.Tasks.Where(c => c.CardNumber == cardModel.CardNumber).FirstOrDefault();
                card.X_Axis = cardModel.X_Axis;
                card.Y_Axis = cardModel.Y_Axis;
                ctx.SaveChanges();
            }
        }

        public static void DeleteCard(string cardNumber)
        {
            using (var ctx = new GScrumContext())
            {

                var card = ctx.Tasks.Where(c => c.CardNumber == cardNumber).FirstOrDefault();
                card.DeletedAt = DateTime.Now;
                ctx.SaveChanges();
            }
        }
    }
}