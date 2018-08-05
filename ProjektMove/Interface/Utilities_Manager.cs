using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using ProjektMove.Models;
using ProjektMove.Interface;


namespace ProjektMove.Interface 
{
    public class Utilities_Manager: IUtilities
    {
        ApplicationDbContext _Data = new ApplicationDbContext();

        public bool SendEmail(Emai_Service_Model obj)
        {
            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  

                //WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpServer = Helpers.Constant.SmtpServer;

                //gmail port to send emails 

                //WebMail.SmtpPort = 587;
                WebMail.SmtpPort = Int32.Parse(Helpers.Constant.SmtpPort);


                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application 

                //WebMail.UserName = "pori468@gmail.com";
                WebMail.UserName = System.Configuration.ConfigurationManager.AppSettings["UserName"];



                WebMail.Password = System.Configuration.ConfigurationManager.AppSettings["Password"];

                //Sender email address.  
                //WebMail.From = "pori468@gmail.com";
                WebMail.From = System.Configuration.ConfigurationManager.AppSettings["From"];

                //Send email  
                WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);
                //ViewBag.Status = "Email Sent Successfully.";

                //return "Email Sent Successfully.";
                return true;
            }
            catch
            {
                return false;
            }



        }


        public string Email_confirm(int Id)
        {
            try
            {
                var Confirm = _Data.Person_Info_Models.FirstOrDefault(x => x.Id == Id);
                Confirm.Email_Verification = true;

                _Data.SaveChanges();

                return Helpers.Constant.Email_Confirem.ToString();
            }
            catch
            {
                return Helpers.Constant.Email_Confirem_Fail.ToString();
            }
        }

        public void ForgotPassword(string userId, string action, string link)
        {

            try
            {
                var User = _Data.Users.FirstOrDefault(x => x.Id == userId);
                Emai_Service_Model obj = new Emai_Service_Model();

                obj.ToEmail = User.Email;
                obj.EmailSubject = action;

                obj.EMailBody = link;

                var result = SendEmail(obj);
            }

            catch
            {

                throw;
            }
        }
    }
}