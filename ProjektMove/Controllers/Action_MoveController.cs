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
        IAction_Move _Image_Function = new Action_Move_Manager();

        public ActionResult All_Gallery_Imagey()
        {
            return View();

        }


        public ActionResult Show_Gallery_Imagey()
        {
            return PartialView("_Partial_Show_All_Image_View", _Image_Function.Show_All_Images());
            
        }




        public ActionResult Add_Gallery_Image()
        {
            
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
               
                bool Result = _Image_Function.Add_Image(System.Web.HttpContext.Current.Request.Files["MyImages"]);

                return Content(Result.ToString());

            }

            else
            {
                return Content(false.ToString());
            }
                
        }

        

        
        public ActionResult Remove_Gallery_Image(int id)
        {
            bool Result = _Image_Function.Remove_Image(id);

            return Content(Result.ToString());
        }



    }
}
