using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using ProjektMove.Models;
using ProjektMove.Interface;
using System.Web.Mvc;
using System.Web.Hosting;
using System.IO;


namespace ProjektMove.Interface
{
    public class Activities_Manager : IActivities
    {
        ApplicationDbContext _Data = new ApplicationDbContext();

        

        public Image_Model Show_Image(int id)
        {
            Image_Model Image = new Image_Model
            {
                Directory = "~/img/VESTERGADE_SEVEN_Image.jpg"
            };
            string ID = "Vester_78f7-6507-gade_03860-bc4a-e14dh5kjd5445Seven";

            if (id==2)
            {
                Image.Directory = "~/img/FOLLOW_EVEN_Image.jpg";

             ID = "Follow_7fdkf67-6467-gade_076470-45h4a-e14dh5kjd5445even";
        }
            
            
            try
            {
                Image = _Data.Image_Models.FirstOrDefault(x => x.Ownership_Id == ID);

                return Image;
            }

            catch
            {
                return Image;
            }
        }


        public bool Change_Image(HttpPostedFile pic, int id)
        {
            try
            {

                if (pic.ContentLength > 0)
                {
                    var filepath = System.Web.HttpContext.Current.Server.MapPath("~/img/VESTERGADE_SEVEN_Image.jpg");

                    if (id == 2)
                    {
                        filepath = System.Web.HttpContext.Current.Server.MapPath("~/img/FOLLOW_EVEN_Image.jpg");

                    }


                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);

                    }




                    pic.SaveAs(filepath);

                    return true;

                }

                else return false;


            }

            catch
            {
                return false;
            }
        }

        public IEnumerable<Text_Model> All_Paragraph(int id)
        {
            List<Text_Model> Text = new List<Text_Model>();
            try
            {
                Text = _Data.Text_Model.Where(x => x.Ownership_Id == "VesterGade_543v92_sjdhs_Para_7jdh45d_Graph").ToList();

                if(id==2)
                {
                    Text = _Data.Text_Model.Where(x => x.Ownership_Id == "Follow_7fdkf67-6467-gade_076470-45h4a-e14dh5kjd5445even").ToList();

                }
                return Text;
            }

            catch
            {
                return Text;
            }
        }


        public bool Add_Paragraph(String Text,int id)
        {

            try
            {
                Text_Model Paragraph = new Text_Model
                {
                    Text = Text,
                    Ownership_Id = "VesterGade_543v92_sjdhs_Para_7jdh45d_Graph"
                };

                if(id==2)
                {
                    Paragraph.Ownership_Id = "Follow_7fdkf67-6467-gade_076470-45h4a-e14dh5kjd5445even";
                }

                _Data.Text_Model.Add(Paragraph);
                _Data.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Remove_Paragraph(int Id)
        {
            try
            {
                var item = _Data.Text_Model.FirstOrDefault(x => x.Id == Id);

                _Data.Text_Model.Remove(item);
                _Data.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }


        public IEnumerable<Sponsor_View_Model> All_Story()

        {
            List<Sponsor_View_Model> Result = new List<Sponsor_View_Model>();

            try
            {
                var Item = _Data.Image_Models.Where(x => x.Image_Name == "Story").ToList();

             
                foreach (var i in Item)
                {

                    Result.Add(new Sponsor_View_Model()
                    {
                        Id = i.Id,
                        Text = _Data.Text_Model.FirstOrDefault(x => x.Ownership_Id == i.Ownership_Id).Text,
                        Directory = i.Directory
                    });


                }




                return Result;

            }

            catch
            {
                return Result;
            }
        }

        public string New_Story(string Text)
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
                    Image_Name = "Story",
                    Date = DateTime.Now,
                    Directory = "~/img/Story.jpg",
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

        public bool Add_Story_Image(HttpPostedFile pic, string Data)
        {


            try
            {


                if (pic.ContentLength > 0)
                {


                    var _comPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/img"), "Story" + Data + ".jpg");


                    pic.SaveAs(_comPath);
                    string Story_Directory = "~/img/" + "Story" + Data + ".jpg";

                    var image = _Data.Image_Models.FirstOrDefault(x => x.Ownership_Id == Data);

                    image.Directory = Story_Directory;


                    _Data.SaveChanges();

                    return true;

                }

                else
                {
                    var image = _Data.Image_Models.FirstOrDefault(x => x.Ownership_Id == Data);

                    image.Directory = "~/img/Story.jpg";


                    _Data.SaveChanges();

                    return true;

                }


            }

            catch
            {
                return false;
            }
        }



        public bool Remove_Story(int id)
        {

            try
            {
                var Item = _Data.Image_Models.FirstOrDefault(x => x.Id == id);


                if (Item.Directory != "~/img/Story.jpg")
                {
                    var filepath = System.Web.HttpContext.Current.Server.MapPath(Item.Directory);
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);

                    }
                }

                var text = _Data.Text_Model.FirstOrDefault(x => x.Ownership_Id == Item.Ownership_Id);
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