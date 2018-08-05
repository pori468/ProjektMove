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
    interface IHome
    {
        bool Contac_Move(FormCollection Message);
        Image_Model Show_About_Image();
        bool Change_Image(HttpPostedFile pc);

        IEnumerable<Text_Model> All_Paragraph();
        bool Add_Paragraph(String Text);
        bool Remove(int Id);
    }
}
