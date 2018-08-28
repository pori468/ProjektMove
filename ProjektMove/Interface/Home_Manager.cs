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
    public class Home_Manager : IHome
    {
        Emai_Service_Model obj = new Emai_Service_Model();
        IUtilities _utility = new Utilities_Manager();

        ApplicationDbContext _Data = new ApplicationDbContext();

        public bool Contac_Move(FormCollection Message)
        {
            try
            {
                obj.ToEmail = System.Configuration.ConfigurationManager.AppSettings["Admin"]; 
                obj.EmailSubject = Helpers.Constant.User_Quary;
                obj.EMailBody = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/Email_Templets/") + "User_Query" + ".cshtml").Replace("UserName", Message["Name"]).Replace("UserPhone", Message["Phone"]).Replace("UserEmail", Message["Email"]).Replace("UserMessage", Message["Message"]).ToString();
                var result = _utility.SendEmail(obj);

                return result;
            }

            catch
            {
                return false;
            }
        }

        public Image_Model Show_About_Image(int id )
        {
            Image_Model Image = new Image_Model();
            Image.Directory = "~/img/Default_Image";
            string ID = "About_70f7-6507-4718-bc4a-e14531d5445Image";
            if (id==2)
            {
                ID = "About2_70f7-6507-4718-bc4a-e14531d5445Image";
            }
            try
            {
                Image = _Data.Image_Models.FirstOrDefault(x => x.Ownership_Id ==ID);

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
                    var filepath = System.Web.HttpContext.Current.Server.MapPath("~/img/About_Image.jpg");

                    if (id == 2)
                    {
                        filepath = System.Web.HttpContext.Current.Server.MapPath("~/img/About_Image2.jpg");

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

        public IEnumerable<Text_Model> All_Paragraph()
        {
            List<Text_Model>  Text = new List<Text_Model>();
            try
            {
               Text=_Data.Text_Model.Where(x=>x.Ownership_Id=="Text_23792_sjdhs_Para_745nfd_Graph").ToList();
                return Text;
            }

            catch
            {
                return Text;
            }
        }


        public bool Add_Paragraph(String Text)
        {

            try
            {
                Text_Model Paragraph = new Text_Model();
                Paragraph.Text = Text;
                Paragraph.Ownership_Id = "Text_23792_sjdhs_Para_745nfd_Graph";

                _Data.Text_Model.Add(Paragraph);
                _Data.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int Id)
        {
            try
            {
                var item = _Data.Text_Model.FirstOrDefault(x => x.Id == Id && x.Ownership_Id == "Text_23792_sjdhs_Para_745nfd_Graph");

                _Data.Text_Model.Remove(item);
                _Data.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public IEnumerable<Contac_Person_Model>  Contac_Person()
        {
            List<Contac_Person_Model> Person = new List<Contac_Person_Model>();
            List<Member_ViewModel> Result = new List<Member_ViewModel>();
            try
            {

                var Contac_Person = _Data.Person_Info_Models.Where(x => x.Contac == true && x.Volunteer == true).ToList();

                


                foreach (var single in Contac_Person)
                {
                    

                    Person.Add(new Contac_Person_Model()
                    {
                        Id = single.Id,
                        Photo = _Data.Image_Models.FirstOrDefault(x => x.Ownership_Id == single.Ownership_Id).Directory,
                        Name = single.Name,
                        Phone_No = single.Phone_No,
                        Email = single.Email,
                        Ownership_Id = single.Ownership_Id
                    });

                }
                return Person;
            }

            catch
            {
                return Person;
            }
        }
    }
}