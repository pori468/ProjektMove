using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektMove.Models;

namespace ProjektMove.Interface
{
    interface IUtilities
    {
        bool SendEmail(Emai_Service_Model Obj);
        string Email_confirm(int Id);

        void ForgotPassword(string userId, string action, string link);
    }
}
