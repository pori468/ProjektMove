using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjektMove.Models;

namespace ProjektMove.Interface
{
    interface IActivities
    {
        Image_Model Show_Image(int id);
        bool Change_Image(HttpPostedFile pc, int id);

        IEnumerable<Text_Model> All_Paragraph(int id);
        bool Add_Paragraph(String Text,int id);
        bool Remove_Paragraph(int Id);

        IEnumerable<Sponsor_View_Model> All_Story();
        string New_Story(string Text);
        bool Add_Story_Image(HttpPostedFile pic, string Data);
        bool Remove_Story(int id);
    }
}
