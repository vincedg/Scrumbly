using GScrum.DAL;
using GScrum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GScrum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BoardVM board = new BoardVM();
            using (var ctx = new GScrumContext()) {
                List<SelectListItem> newList = ctx.Boards.Where(b => b.DeletedAt == null)
                    .Select(b => new SelectListItem
                    {
                        Text = b.Name,
                        Value = b.Id.ToString()
                    })
                    .ToList();
            }
            return View(board);
        }

        public ActionResult BoardNavigation(string boardName)
        {
            BoardVM board = new BoardVM();
            using (var ctx = new GScrumContext())
            {
                board = ctx.Boards.Where(b => b.Name == boardName)
                    .Select(b => new BoardVM { 
                        Name = b.Name,
                        Id = b.Id,
                        BigNote = b.BigNote,
                        CreatedAt = b.CreatedAt,
                        Height = b.Height,
                        Width = b.Width
                    })
                    .FirstOrDefault();
            }
            return PartialView("~/Views/Home/Board.cshtml", board);
        }

        public ActionResult createCard(CardVM cardModel)
        {
            CardVM.CreateCard(cardModel);
            return Json(new { success = true, message = "Success" });
        }               

        public ActionResult moveCard(CardVM cardModel)
        {
            CardVM.MoveCard(cardModel);
            return Json(new { success = true, message = "Success" });
        }

        public ActionResult editCard(CardVM cardModel)
        {
            CardVM.EditCard(cardModel);
            return Json(new { success = true, message = "Success" });
        }

        public ActionResult deleteCard(CardVM cardModel)
        {
            CardVM.DeleteCard(cardModel.CardNumber);
            return Json(new { success = true, message = "Success" });
        }

        public ActionResult addSticker(StickerVM stickerModel)
        {

            return Json(new { success = true, message = "Success" });
        }

        public ActionResult changeTheme(string newTheme)
        {

            return Json(new { success = true, message = "Success" });
        }

        public ActionResult setBoardSize(BoardVM boardModel)
        {
            using (var ctx = new GScrumContext())
            {
                var board = ctx.Boards.Where(b => b.Id == 1).FirstOrDefault();
                board.Height = boardModel.Height;
                board.Width = boardModel.Width;
                ctx.SaveChanges();
            }
            return Json(new { success = true, message = "Success" });
        }

        public ActionResult updateColumns(string[] columns)
        {
            using (var ctx = new GScrumContext()) {
                var columnChanges = ctx.BoardColumns.Where(b => b.BoardId == 1).ToList();
                foreach(var column in columnChanges) {
                    column.DeletedAt = DateTime.Now;
                }
                if (columns != null) {
                    foreach (var col in columns)
                    {
                        ctx.BoardColumns.Add(new Models.BoardColumn
                        {
                            BoardId = 1,
                            Title = col
                        });
                    }
                }
                ctx.SaveChanges();
            }
            return Json(new { success = true, message = "Success" });
        }
        
        public ActionResult getBoard(int Id)
        {
            BoardVM board = new BoardVM();
            using (var ctx = new GScrumContext())
            {
                var cards = ctx.Tasks.Where(t => t.DeletedAt == null).Select(t => new CardVM
                {
                    CardNumber = t.CardNumber,
                    Colour = t.Colour.Name,
                    Description = t.Description,
                    X_Axis = t.X_Axis,
                    Y_Axis = t.Y_Axis
                }).ToList();
                var columns = ctx.BoardColumns.Where(t => t.DeletedAt == null && t.BoardId == Id).Select(t => t.Title).ToArray();
                board = ctx.Boards.Where(b => b.Id == Id)
                    .Select(b => new BoardVM { 
                        Name = b.Name,
                        Id = b.Id,
                        BigNote = b.BigNote,
                        CreatedAt = b.CreatedAt,
                        Height = b.Height,
                        Width = b.Width
                    })
                    .FirstOrDefault();
                board.Cards = cards;
                board.Columns = columns;
            }
            return Json(new { success = true, message = "Success", data =  board}, JsonRequestBehavior.AllowGet);
        }
    }
}