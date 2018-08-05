using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ProjektMove.Models;

using ProjektMove.Interface;

using System.Web.Mvc;

namespace ProjektMove.Interface
{
    public class Action_Move_Manager : IAction_Move
    {
        ApplicationDbContext _Data = new ApplicationDbContext();
       

        public IEnumerable<Image_Model> Show_All_Images()
        {
            List<Image_Model> Result = new List<Image_Model>();

            try
            {
               Result= _Data.Image_Models.Where(x=>x.Image_Name=="Galerry" && x.Ownership_Id=="Image32Gallery35Ownership007").ToList();
                return Result;

            }

            catch
            {
                return Result;
            }
        }



        public bool Add_Image(HttpPostedFile pic)
        {
            try
            {

                if (pic.ContentLength > 0)
                {
                    //var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    var _Image_Name = Guid.NewGuid().ToString();

                    var _comPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/img"), _Image_Name + _ext);


                    pic.SaveAs(_comPath);


                    Image_Model New_Image = new Image_Model
                    {
                        Image_Name = "Galerry",
                        Ownership_Id = "Image32Gallery35Ownership007",
                        Directory = "~/img/"+ _Image_Name + _ext,
                        Date = System.DateTime.Now

                    };

                    _Data.Image_Models.Add(New_Image);
                    _Data.SaveChanges();

                    return true;

                }

                else return false;
                

            }

            catch
            {
                return false;
            }
        }

        public bool Remove_Image(int id)
        {
           

            try
            {
                var Item = _Data.Image_Models.FirstOrDefault(x => x.Id== id && x.Image_Name == "Galerry" && x.Ownership_Id == "Image32Gallery35Ownership007");

                var filepath = System.Web.HttpContext.Current.Server.MapPath(Item.Directory);
                if(File.Exists(filepath))
                {
                    File.Delete(filepath);

                }

               
              _Data.Image_Models.Remove(Item);
              _Data.SaveChanges();



                return true;

            }

            catch
            {
                return false;
            }
        }
    }
}