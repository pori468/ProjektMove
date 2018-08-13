using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektMove.Models;
using ProjektMove.Interface;


namespace ProjektMove.Controllers
{
    public class ActivitiesController : Controller
    {
        IActivities  _Activities = new Activities_Manager();

      
        public ActionResult VESTERGADE_SEVEN()
        {
            return View();
        }

        public ActionResult FOLLOW_EVEN()
        {
            return View();
        }

        public ActionResult CLUB_MOVE()
        {
            return View(_Activities.All_Story());
        }


        public ActionResult Show_Image(int? id)
        {

            return PartialView("_Partial_Image_View", _Activities.Show_Image(id.Value));
        }



        [HttpPost]
        public ActionResult Change_Image(int? id)
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {

                bool Result = _Activities.Change_Image(System.Web.HttpContext.Current.Request.Files["MyImages"], id.Value);

                return Content(Result.ToString());

            }

            else
            {
                return Content(false.ToString());
            }
        }

            public ActionResult Show_Paragraph(int? id)
                    {

                        return PartialView("_Partial_Paragraph_View", _Activities.All_Paragraph(id.Value));
                    }
       
          
        [HttpPost]
        public ActionResult Add_Paragraph(string Text, int? id)
        {
            bool Result = _Activities.Add_Paragraph(Text,id.Value);
            return Content(Result.ToString());
        }

        [HttpPost]
        public ActionResult Remove_Paragraph(int Id)
        {
            bool Result = _Activities.Remove_Paragraph(Id);
            return Content(Result.ToString());
        }


       

        
        [HttpPost]
        public ActionResult New_Story(FormCollection collection)
        {
            string Result = _Activities.New_Story(collection["Story_Text"]);

            return Content(Result.ToString());

        }


        public ActionResult Upload_Story_Photo()
        {


            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {

                bool Result = _Activities.Add_Story_Image(System.Web.HttpContext.Current.Request.Files["MyImages"], System.Web.HttpContext.Current.Request.Form["Name"]);

                return Content(Result.ToString());

            }

            else
            {
                return Content(false.ToString());
            }

        }

        [HttpPost]
        public ActionResult Remove_Story(int id)
        {
            bool Result = _Activities.Remove_Story(id);
            return Content(Result.ToString());
        }

    }
}
