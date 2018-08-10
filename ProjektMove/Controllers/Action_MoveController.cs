using ProjektMove.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMove.Controllers
{
    public class Action_MoveController : Controller
    {
        
        IAction_Move _Action_Move = new Action_Move_Manager();

        public ActionResult All_Gallery_Imagey()
        {
            return View();

        }


        public ActionResult Show_Gallery_Imagey()
        {
            return PartialView("_Partial_Show_All_Image_View", _Action_Move.Show_All_Images());
            
        }




        public ActionResult Add_Gallery_Image()
        {
            
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
               
                bool Result = _Action_Move.Add_Image(System.Web.HttpContext.Current.Request.Files["MyImages"]);

                return Content(Result.ToString());

            }

            else
            {
                return Content(false.ToString());
            }
                
        }

        

        
        public ActionResult Remove_Gallery_Image(int id)
        {
            bool Result = _Action_Move.Remove_Image(id);

            return Content(Result.ToString());
        }


        
        public ActionResult Sponsor()
        {
            return PartialView("_Partial_Sponsor_View", _Action_Move.All_Sponsor());
        }

        [HttpPost]
        public ActionResult Remove_Sponsor(int id)
        {
            bool Result = _Action_Move.Remove_Sponsor(id);
            return Content(Result.ToString());
        }

        [HttpPost]
        public ActionResult New_Sponsor(FormCollection collection)
        {
            string Result = _Action_Move.New_Sponsor(collection["Sponsor_Text"]);
            
            return Content(Result.ToString());

        }

        public ActionResult Upload_Sponsor_Photo()
        {


            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
               
                bool Result = _Action_Move.Add_Sponsor_Image(System.Web.HttpContext.Current.Request.Files["MyImages"], System.Web.HttpContext.Current.Request.Form["Name"]);

                return Content(Result.ToString());

            }

            else
            {
                return Content(false.ToString());
            }

        }
    }
}
