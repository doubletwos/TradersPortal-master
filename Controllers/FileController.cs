
using System.Web.Mvc;
using TradersPortal.Models;

namespace TradersPortal.Controllers
{
    public class FileController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}