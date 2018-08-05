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
    }
}
