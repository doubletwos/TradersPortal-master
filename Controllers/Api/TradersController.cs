//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using TradersPortal.Dtos;
//using TradersPortal.Models;

//namespace TradersPortal.Controllers.Api
//{
//    public class TradersController : ApiController
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();


//        // GET: api/Traders
//        //public IEnumerable<TraderDto> GetTraders()
//        //{
//        //    return db.Traders
//        //        .Include(s => s.State)
//        //        .Include(t => t.Trade)
//        //        .ToList().Select(Mapper.Map<Trader, TraderDto>);
//        //}




//        // GET: api/Traders/5
//        //[ResponseType(typeof(Trader))]
//        public IHttpActionResult GetTrader(int id)
//        {
//            var trader = db.Traders.SingleOrDefault(t => t.TraderId == id);


//            if (trader == null)
//            return NotFound();

//            return Ok(Mapper.Map<Trader, TraderDto>(trader));
//        }

     

//        // POST: api/Traders
//        //[ResponseType(typeof(Trader))]
//        [HttpPost]
//        public IHttpActionResult CreateTrader(TraderDto traderDto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest();

//            var trader = Mapper.Map<TraderDto, Trader>(traderDto);

//            db.Traders.Add(trader);
//            db.SaveChanges();

//            traderDto.TraderId = trader.TraderId;

//            return Created(new Uri(Request.RequestUri + "/" + trader.TraderId), traderDto);
//        }






//        // PUT: api/Traders/5
//        //[ResponseType(typeof(void))]
//        [HttpPut]
//        public IHttpActionResult UpdateTrader(int id, TraderDto traderDto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest();

//            var traderInDb = db.Traders.SingleOrDefault(t => t.TraderId == id);


//            if (traderInDb == null)
//            {
//                return NotFound();
//            }

//            Mapper.Map(traderDto, traderInDb);

//            db.SaveChanges();
//            return Ok();

//        }



//        // DELETE: api/Traders/5
//        //[ResponseType(typeof(Trader))]
//        [HttpDelete]
//        public IHttpActionResult DeleteTrader(int id)
//        {

//            var traderInDb = db.Traders.SingleOrDefault(t => t.TraderId == id);
            
           
//            if (traderInDb == null)
//            {
//              return NotFound();
//            }

//            db.Traders.Remove(traderInDb);
//            db.SaveChanges();

//            return Ok();
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool TraderExists(int id)
//        {
//            return db.Traders.Count(e => e.TraderId == id) > 0;
//        }
//    }
//}