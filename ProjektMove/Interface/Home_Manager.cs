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
                obj.ToEmail = System.Configuration.ConfigurationManager.AppSettings["From"]; 
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

       public Image_Model Show_About_Image()
        {
            Image_Model Image = new Image_Model();
               Image.Directory ="~/img/Default_Image";
            try
            {
                Image =_Data.Image_Models.FirstOrDefault(x=>x.Ownership_Id== "About_70f7-6507-4718-bc4a-e14531d5445Image");

                return Image;
            }

            catch
            {
                return Image;
            }
        }

        public bool Change_Image(HttpPostedFile pic)
        {
            try
            {

                if (pic.ContentLength > 0)
                {
                   

                    var filepath = System.Web.HttpContext.Current.Server.MapPath("~/img/About_Image.jpg");
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);

                    }
               

                //var _comPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/img"), "About_Image" + ".jpg");


                    pic.SaveAs(filepath);

                    //var Image = _Data.Image_Models.FirstOrDefault(x=>x.Ownership_Id== "About_70f7-6507-4718-bc4a-e14531d5445Image");

                    //Image.Directory = "~/img/About_Image.jpg";
                    //_Data.SaveChanges();

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
    }
}