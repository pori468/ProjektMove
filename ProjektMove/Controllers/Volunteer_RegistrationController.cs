using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektMove.Models;
using ProjektMove.Interface;
using System.IO;


namespace ProjektMove.Controllers
{
    public class Volunteer_RegistrationController : Controller
    {
        IPersonal_Information _Personal_Information = new Personal_Information_Manager();
        IUtilities _utility = new Utilities_Manager();

        // GET: Volunteer_Registration
        public ActionResult Index()
        {


            return View();
        }





        public ActionResult All_Members()
        {
            return PartialView ("_Partial_All_Member_View", _Personal_Information.All_Members());
            
        }

        public ActionResult New_Volunteer()
        {
            return PartialView("_Partial_New_Volunteer_View", _Personal_Information.New_Volunteer());

        }

        

        public ActionResult Approval(int id)
        {
            bool Result = _Personal_Information.Approval(id);

            return Content(Result.ToString());
        }

        public ActionResult Edit(int id)
        {

            return View(_Personal_Information.GetEdit_Info(id));
        }

        // POST: Volunteer_Registration/Edit/5
        [HttpPost]
        public ActionResult Edit(Member_ViewModel collection)
        {
            
            bool Result = _Personal_Information.PostEdit_Info(collection);
           

            return Content(Result.ToString());
            
        }

        public ActionResult Upload_Photo()
        {

           
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
               
                bool Result = _Personal_Information.Change_Image(System.Web.HttpContext.Current.Request.Files["MyImages"], System.Web.HttpContext.Current.Request.Form["Name"]);

                return Content(Result.ToString());

            }

            else
            {
                return Content(false.ToString());
            }

        }



        // GET: Volunteer_Registration/Delete/5
        public ActionResult Delete(int id)
        {
            bool Result = _Personal_Information.Delete(id);

            return Content(Result.ToString());
            
        }

        
       public ActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Register(Person_Info_Model collection)
        {
           
               
               bool Result = _Personal_Information.Registration(collection);
            return Content(Result.ToString());


        }

        public ActionResult Email_Confirmation(int Id)
        {
            ViewBag.Email = _utility.Email_confirm(Id);

            return View();
        }


    }
}
