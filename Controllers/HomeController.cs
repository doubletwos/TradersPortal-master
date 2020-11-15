using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradersPortal.Models;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Web.WebPages.Html;
using System.Web.UI.WebControls;
using System.Net;

namespace TradersPortal.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public ActionResult Index()
        //{



        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "CanManageTraders")]
        public ActionResult AdminPage()
        {
            return View();
        }




        // GET: Traders
        public ActionResult Index(string searchstate, string searchtrade)
        {
            var traders = db.Traders
                .Include(t => t.Trade)
                .Include(s => s.State).ToList();

            // returns all when all textbox are empty 
            if (string.IsNullOrWhiteSpace(searchstate) && string.IsNullOrWhiteSpace(searchtrade))
            {
                return View(traders);
            }

            // returns traders if trade is selected & state is null
            else if (string.IsNullOrWhiteSpace(searchstate) && !(string.IsNullOrWhiteSpace(searchtrade)))
            {
                return View(db.Traders.Include(t => t.Trade).Include(s => s.State).Where(t => t.Trade.TradeName == searchtrade).ToList());
            }

            // returns traders if state is selected & trade is null
            else if (string.IsNullOrWhiteSpace(searchtrade) && !(string.IsNullOrEmpty(searchstate)))
            {
                return View(db.Traders.Include(t => t.Trade).Include(s => s.State).Where(t => t.State.StateName == searchstate).ToList());
            }

            // returns traders & state if both are selected
            else if (!(string.IsNullOrWhiteSpace(searchtrade) && !(string.IsNullOrEmpty(searchstate))))
            {
                return View(db.Traders.Include(t => t.Trade).Include(s => s.State).Where(s => s.State.StateName == searchstate).Where(t => t.Trade.TradeName == searchtrade).ToList());
            }
            else
            {

                return View(traders);

            }
        }



        public JsonResult AutoCompleteTrade(string prefix)
        {
            var tradelist = (from trade in db.Trades
                             where trade.TradeName.StartsWith(prefix)
                             select new
                             {
                                 label = trade.TradeName,
                                 val = trade.TradeId
                             }).ToList();

            return Json(tradelist);
        }


        public JsonResult AutoCompleteState(string prefix)
        {
            var statelist = (from state in db.States
                             where state.StateName.StartsWith(prefix)
                             select new
                             {
                                 label = state.StateName,
                                 val = state.StateId
                             }).ToList();

            return Json(statelist);
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


    }


  














}