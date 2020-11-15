using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TradersPortal.Models;

namespace TradersPortal.Controllers
{
    public class TradersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        // GET: Traders

        public ActionResult Index()
        {
            var traders = db.Traders
                .Include(t => t.State)
                .Include(t => t.Trade)
                .ToList();

            return View(traders);
        }


        // GET: Traders
        [Authorize(Roles = "CanManageTraders")]
        public ActionResult IndexAd()
        {
            var traders = db.Traders
                .Include(t => t.State)
                .Include(t => t.Trade)
                .ToList();

            return View(traders);
        }




        // GET: Traders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trader = db.Traders
                .Include(t => t.State)
                .Include(t => t.Trade)
                .Include(s => s.Files)
                .SingleOrDefault(c => c.TraderId == id);


            return View(trader);




        }









        // GET: Traders/Create
        public ActionResult Create()
        {


            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            ViewBag.TradeId = new SelectList(db.Trades, "TradeId", "TradeName");
            return View();
        }

        // POST: Traders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trader trader, HttpPostedFileBase upload)
        {
         
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };


                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    trader.Files = new List<File> { avatar };
                }
                db.Traders.Add(trader);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");


            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            ViewBag.TradeId = new SelectList(db.Trades, "TradeId", "TradeName");
            return View(trader);
          

        }
       
            
            
        




        // GET: Traders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trader trader = db.Traders.Include(s => s.Files).SingleOrDefault(s => s.TraderId == id);
            if (trader == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", trader.StateId);
            ViewBag.TradeId = new SelectList(db.Trades, "TradeId", "TradeName", trader.TradeId);
            return View(trader);
        }

        // POST: Traders/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trader trader, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var traderinDb = db.Traders.Include(f => f.Files).Single(c => c.TraderId == trader.TraderId);
                traderinDb.BusinessName = trader.BusinessName;
                traderinDb.ContactFirstName = trader.ContactFirstName;
                traderinDb.ContactLastName = trader.ContactLastName;
                traderinDb.Telephone = trader.Telephone;
                traderinDb.Mobile = trader.Mobile;
                traderinDb.Email = trader.Email;
                traderinDb.RegistrationDate = trader.RegistrationDate;
                traderinDb.TradeId = trader.TradeId;
                traderinDb.StateId = trader.StateId;


                if (upload != null && upload.ContentLength > 0)
                {
                    if (traderinDb.Files.Any(f => f.FileType == FileType.Avatar))
                    {
                        db.Files.Remove(traderinDb.Files.First(f => f.FileType == FileType.Avatar));
                    }
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    traderinDb.Files = new List<File> { avatar };
                }



                db.Entry(traderinDb).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");


        }

        // GET: Traders/Delete/5
        [Authorize(Roles = "CanManageTraders")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trader = db.Traders.Find(id);
            if (trader == null)
            {
                return HttpNotFound();
            }
            return View(trader);
        }

        // POST: Traders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var trader = db.Traders.Find(id);
            db.Traders.Remove(trader);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
