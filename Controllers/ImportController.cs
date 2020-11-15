using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradersPortal.Models;
using WebGrease.Css.Ast;

namespace TradersPortal.Controllers
{
    public class ImportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Import
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Uploader(HttpPostedFileBase postedFile)
        {

            var FileName = System.IO.Path.GetFileName(postedFile.FileName);
            var filePath = Server.MapPath("~/Content/Uploads/");
            filePath = filePath + Path.GetFileName(postedFile.FileName);
            postedFile.SaveAs(filePath);

            try
            {
                String path = Server.MapPath("~/Content/Uploads/").Select(f => filePath).FirstOrDefault();

                var package = new ExcelPackage(new System.IO.FileInfo(path));
                int startColumn = 1;
                int startRow = 2;
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1]; // read sheet 1

                object data = null;

                do
                {
                                   data = workSheet.Cells[startRow, startColumn].Value; //column No
                    object businessName = workSheet.Cells[startRow, startColumn ].Value; 
                    object ContactFirstName = workSheet.Cells[startRow, startColumn + 1].Value; 
                    object ContactLastName = workSheet.Cells[startRow, startColumn + 2].Value; 
                    object Telephone = workSheet.Cells[startRow, startColumn + 3 ].Value; 
                    object Mobile = workSheet.Cells[startRow, startColumn + 4].Value; 
                    object Email = workSheet.Cells[startRow, startColumn + 5].Value; 
                    object TraderId = workSheet.Cells[startRow, startColumn + 6].Value; 
                    object StateId = workSheet.Cells[startRow, startColumn + 7].Value; 








                    if (data != null )
                    {



                        var isSuccess = saveTrader(businessName.ToString(),ContactFirstName.ToString(),ContactLastName.ToString(),Telephone.ToString(),Mobile.ToString(),Email.ToString(),TraderId.ToString(),StateId.ToString());
                        //if (isSuccess)
                        //{
                        //    count++;
                        //}
                    }
                    startRow++;
                }
                while (data != null);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
            //return result;
        }

        public bool saveTrader(String businessname, String ContactFirstName, string ContactLastName, string Telephone, String Mobile, String Email, String TraderId, String StateId)
        {
            var result = false;
            try
            {

                // check if name already exists
                if (db.Traders.Where(t => t.BusinessName.Equals(businessname)).Count() == 0)
                {
                    var item = new Trader();
                    item.BusinessName = businessname;
                    item.ContactFirstName = ContactFirstName;
                    item.ContactLastName = ContactLastName;
                    item.Telephone = Telephone;
                    item.Mobile = Mobile;
                    item.Email = Email;
                    item.TradeId = Convert.ToInt32(TraderId);
                    item.StateId = Convert.ToInt32(StateId);
                    db.Traders.Add(item);
                    db.SaveChanges();
                    result = true;

                }
            }
            catch
            {

            }
            return result;
        }
    }
}






