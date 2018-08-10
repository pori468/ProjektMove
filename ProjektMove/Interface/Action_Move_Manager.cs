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

       public IEnumerable<Sponsor_View_Model> All_Sponsor()
           
        {
            List<Sponsor_View_Model> Result = new List<Sponsor_View_Model>();

            try
            {
                 var Item = _Data.Image_Models.Where(x => x.Image_Name== "Sponsor").ToList();

                Sponsor_View_Model Sponsor = new Sponsor_View_Model();
                foreach (var i in Item )
                {
                   
                    Result.Add(new Sponsor_View_Model() {
                        Id = i.Id,
                        Text = _Data.Text_Model.FirstOrDefault(x => x.Ownership_Id == i.Ownership_Id).Text,
                    Directory = i.Directory });

                  
                }

               


                return Result;

            }

            catch
            {
                return Result;
            }
        }

        public string New_Sponsor(string Text)
        {
            string Result = "NULL";
            try
            {
                ProjektMove.Models.Text_Model model = new Models.Text_Model
                {
                    Text = Text,
                    Ownership_Id = Guid.NewGuid().ToString()
                };



                var image = new Image_Model
                {
                    Image_Name = "Sponsor",
                    Date = DateTime.Now,
                    Directory = "~/img/Sponsor.jpg",
                    Ownership_Id = model.Ownership_Id



                };

                _Data.Image_Models.Add(image);
                _Data.Text_Model.Add(model);
                _Data.SaveChanges();

                
                return model.Ownership_Id;
            }

            catch
            {
                return Result;
            }
        }

        public bool Add_Sponsor_Image(HttpPostedFile pic, string Data)
        {


            try
            {


                if (pic.ContentLength > 0)
                {

                    
                    var _comPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/img"), "Sponsor"+ Data + ".jpg");


                    pic.SaveAs(_comPath);
                    string Sponsor_Directory = "~/img/" + "Sponsor" + Data + ".jpg";

                    var image = _Data.Image_Models.FirstOrDefault(x=>x.Ownership_Id==Data);

                    image.Directory = Sponsor_Directory;

                   
                    _Data.SaveChanges();

                    return true;

                }

                else
                {
                    var image = _Data.Image_Models.FirstOrDefault(x => x.Ownership_Id == Data);

                    image.Directory = "~/img/Sponsor.jpg";

                   
                    _Data.SaveChanges();

                    return true;

                }


            }

            catch
            {
                return false;
            }
        }

        

        public bool Remove_Sponsor(int id)
        {

            try
            {
                var Item = _Data.Image_Models.FirstOrDefault(x => x.Id == id);

               
                if (Item.Directory != "~/img/Sponsor.jpg")
                {
                    var filepath = System.Web.HttpContext.Current.Server.MapPath(Item.Directory);
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);

                    }
                }

                var text = _Data.Text_Model.FirstOrDefault(x=>x.Ownership_Id==Item.Ownership_Id);
                _Data.Text_Model.Remove(text);
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