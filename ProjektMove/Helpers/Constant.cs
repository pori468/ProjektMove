using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMove.Helpers
{
    public static class Constant
    {
        public const string New_Volunteer = "Wellcome to Project Move";
        public const string Emailsubject = "Approval Of Your Account In ComPro ";
        public const string Emailbody = "Please Click this link to confirm your email address:   https://localhost:44307/UserProfile/CheckLink?email=";
        public const string SmtpServer = "smtp.gmail.com";
        public const string SmtpPort = "587";


        public const string Email_Confirem = "Your Email is Verified. Thank You";
        public const string Email_Confirem_Fail = "Your Email is Not Verified. Try Again";
        public const string Email_Verification_Link = "http://localhost:40524/Volunteer_Registration/Email_Confirmation?Id=";

         public const string User_Quary = " User Quary";
    }
}