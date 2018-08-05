using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProjektMove.Models;

namespace ProjektMove.Interface
{
    interface IPersonal_Information
    {
        bool Registration(Person_Info_Model info);

        IEnumerable<Member_ViewModel> All_Members();
        IEnumerable<Person_Info_Model> New_Volunteer();

        bool Approval(int Id);
        bool Delete(int Id);

        Member_ViewModel GetEdit_Info(int Id);
        bool PostEdit_Info(Member_ViewModel info);
        bool Change_Image(HttpPostedFile pic, string Data);

       

    }
}
