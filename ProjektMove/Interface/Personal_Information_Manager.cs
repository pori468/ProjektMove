using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Hosting;
using ProjektMove.Models;
using ProjektMove.Interface;


namespace ProjektMove.Interface
{
    public class Personal_Information_Manager :IPersonal_Information
    {
        ApplicationDbContext _Data = new ApplicationDbContext();
        List<Person_Info_Model> Result = new List<Person_Info_Model>();
        Emai_Service_Model obj = new Emai_Service_Model();

        IUtilities _utility = new Utilities_Manager();


        public bool Registration(Person_Info_Model info)
        {
            try
            {
                Person_Info_Model Information = new Person_Info_Model
                {
                    Name = info.Name,
                    Email = info.Email,
                    Phone_No = info.Phone_No,
                    Category = info.Category,

                    Approved = false,
                    Email_Verification = false,
                    Volunteer = false,
                    Leader = false,
                    Contac = false,

                    Date = System.DateTime.Now
                };

                _Data.Person_Info_Models.Add(Information);
                _Data.SaveChanges();


                obj.ToEmail = info.Email;
                obj.EmailSubject = Helpers.Constant.New_Volunteer;
                var My_Url = Helpers.Constant.Email_Verification_Link + Information.Id;
                obj.EMailBody = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/Email_Templets/") + "Volunteer_Confirmation" + ".cshtml").Replace("Volunteer", Information.Name).Replace("ConfirmationLink", My_Url).ToString();
               



                var result = _utility.SendEmail(obj);

                return result;
            }
            catch
            {
                return false;
            }
        }
       
        public IEnumerable<Member_ViewModel> All_Members()
        {
            List<Member_ViewModel>  Result = new List<Member_ViewModel> ();
            try
            {
               var Persons  = _Data.Person_Info_Models.Where(x=>x.Approved==true && x.Volunteer== true).ToList();
              
                foreach(var Member in Persons)
                {

                    Result.Add(new Member_ViewModel()
                    {
                        Id = Member.Id,
                        Photo = _Data.Image_Models.FirstOrDefault(x => x.Ownership_Id == Member.Ownership_Id).Directory,
                        Name = Member.Name,
                        Phone_No = Member.Phone_No,
                        Email = Member.Email,
                        Category = Member.Category,
                        Volunteer = Member.Volunteer,
                        Leader = Member.Leader,
                        Contac=Member.Contac,
                        Date = Member.Date




                    });

                    
                }
                
                return Result;
            }
        catch
            {
                return Result;
            }
            }

        public IEnumerable<Person_Info_Model> New_Volunteer()
        {
            
            try
            {
                Result = _Data.Person_Info_Models.Where(x => x.Approved == false).ToList();

                return Result;
            }
            catch
            {
                return Result;
            }
        }


      public bool Approval(int Id)
        {

            try
            {
                var Person = _Data.Person_Info_Models.FirstOrDefault(x => x.Id == Id && x.Approved== false);

                Person.Approved = true;
                Person.Volunteer = true;
                Person.Date = System.DateTime.Now;
                Person.Ownership_Id = Guid.NewGuid().ToString();


                Image_Model Image = new Image_Model
                {
                    Image_Name = Person.Name,
                    Ownership_Id = Person.Ownership_Id,
                    Date = System.DateTime.Now,
                    Directory = "~/img/Member_Photo.jpg".ToString()
                };

                _Data.Image_Models.Add(Image);
                _Data.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete (int Id)
        {

            try
            {
                var Person = _Data.Person_Info_Models.FirstOrDefault(x => x.Id == Id );
                if (Person.Approved)
                {
                    var Image = _Data.Image_Models.FirstOrDefault(y=> y.Ownership_Id==Person.Ownership_Id);
                    _Data.Image_Models.Remove(Image);
                }

                _Data.Person_Info_Models.Remove(Person);

               

                _Data.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


       public Member_ViewModel GetEdit_Info(int Id)
        {
            Person_Info_Model Member = new Person_Info_Model();
            Member_ViewModel info = new Member_ViewModel();
            try
            {
                Member = _Data.Person_Info_Models.FirstOrDefault(x => x.Id == Id);

                info = new Member_ViewModel
                {   Id = Member.Id,
                    Photo = _Data.Image_Models.FirstOrDefault(x =>  x.Ownership_Id == Member.Ownership_Id).Directory,
                    Name = Member.Name,
                    Phone_No = Member.Phone_No,
                    Email = Member.Email,
                    Category = Member.Category,
                    Volunteer = Member.Volunteer,
                    Leader = Member.Leader,
                    Date = Member.Date,
                    Approved = Member.Approved,
                    Contac=Member.Contac,
                    Ownership_Id = Member.Ownership_Id
                };




                return info;


            }
            catch
            {
                return info;
            }
        }


        

            public bool PostEdit_Info(Member_ViewModel info)
           {
            try
            {
                Person_Info_Model Member = new Person_Info_Model
                {
                    Id = info.Id,
                    Name = info.Name,
                    Phone_No = info.Phone_No,
                    Email = info.Email,
                    Category = info.Category,
                    Volunteer = info.Volunteer,
                    Leader = info.Leader,
                    Date = info.Date,
                    Approved = info.Approved,
                    Contac=info.Contac,
                    Ownership_Id = info.Ownership_Id
                };

                if(info.Photo!=null)
                _Data.Image_Models.FirstOrDefault(x =>  x.Ownership_Id == Member.Ownership_Id).Directory= info.Photo;
                   
              
                _Data.Entry(Member).State = EntityState.Modified;
                _Data.SaveChanges();

                return true;


            }
            catch
            {
                return false;
            }
        }

        public bool Change_Image(HttpPostedFile pic , string Data)
        {
           

            try
            {
                

                if (pic.ContentLength > 0)
                {

                    var Member_Image_Info= _Data.Image_Models.FirstOrDefault(x=>x.Ownership_Id==Data);
                    var Member_Info = _Data.Person_Info_Models.FirstOrDefault(y=>y.Ownership_Id==Data);

                    //Uri uri = new Uri(Member_Image_Info.Directory);

                    string file_Name = System.IO.Path.GetFileName(Member_Image_Info.Directory);
                    string file_Extension = System.IO.Path.GetExtension(Member_Image_Info.Directory);
                    if(file_Name!= "Member_Photo.jpg")
                    {
               var filepath = System.Web.HttpContext.Current.Server.MapPath(Member_Image_Info.Directory);
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);

                    }
                    }
                   

                   

                    var _comPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/img"), Member_Info.Ownership_Id + file_Extension);


                    pic.SaveAs(_comPath);


                    Member_Image_Info.Directory = "~/img/" + Member_Info.Ownership_Id + file_Extension;
                    
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

       

       
    }



}


