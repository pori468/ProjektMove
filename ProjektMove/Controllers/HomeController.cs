using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektMove.Models;
using ProjektMove.Interface;


namespace ProjektMove.Controllers
{
    public class HomeController : Controller
    {
        IHome _Home = new Home_Manager();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Show_About()
        {
           
            return PartialView("_Partial_Show_About_Image_View", _Home.Show_About_Image());
        }

        [HttpPost]
        public ActionResult Change_About()
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {

                bool Result = _Home.Change_Image(System.Web.HttpContext.Current.Request.Files["MyImages"]);

                return Content(Result.ToString());

            }

            else
            {
                return Content(false.ToString());
            }
        }

        [HttpPost]
        public ActionResult Add_Paragraph(string Text)
        {
            bool Result = _Home.Add_Paragraph(Text);
            return Content(Result.ToString());
        }
        public ActionResult Show_Paragraph()
        {

            return PartialView("_Partial_Show_Paragraph_View", _Home.All_Paragraph());
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection message)
        {
            bool Result = _Home.Contac_Move(message);
            return Content(Result.ToString());
        }

        [HttpPost]
        public ActionResult Remove_Paragraph(int Id)
        {
            bool Result = _Home.Remove(Id);
            return Content(Result.ToString());
        }
    }
}