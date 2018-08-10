using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProjektMove.Models;

namespace ProjektMove.Interface
{
    interface IAction_Move
    {
        IEnumerable<Image_Model> Show_All_Images();
        bool Add_Image(HttpPostedFile pc );
        bool Remove_Image(int id);
        IEnumerable<Sponsor_View_Model> All_Sponsor();

        string New_Sponsor(string Text);
        bool Add_Sponsor_Image(HttpPostedFile pic, string Data);
        bool Remove_Sponsor(int id);
       
    }
}
