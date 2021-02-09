using NLog;
using SourceControl.Models;
using SourceControl.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SourceControl.Controllers
{
    public class HomeController : Controller
    {
        private static Logger Nlogger = LogManager.GetLogger("NloggerRules");

        [Authorize]
        public ActionResult Index()
        {
            Nlogger.Info("User entered in Index Controller.");
            try 
            {
                ViewBag.Message = $"Welcome {Session["userName"]}";
                return View();
            }
            catch(Exception e)
            {
                Nlogger.Error("Exception !! " + e.Message);
                return View("Error");
            }
            
        }

        //Registration Controller
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {
            Nlogger.Info("User entered in Register Controller.");
            
            using (var db = new SourceControlEntities())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (db.UserDetails.FirstOrDefault(m => m.EmailId == user.EmailId) == null)
                        {
                            UserDetail userDetail = new UserDetail();
                            userDetail.Name = user.Name;
                            userDetail.EmailId = user.EmailId;
                            userDetail.Password = user.Password;
                            db.UserDetails.Add(userDetail);
                            db.SaveChanges();
                            ViewBag.Message = "Successfully Registered";
                            //return RedirectToAction("Login");
                            return View("Login");
                        }
                        ViewBag.FailureMessage = $"User with Email Id = {user.EmailId} is already Registered";
                        return View();
                    }
                    return View();
                }
                catch(Exception e)
                {
                    Nlogger.Error("Exception !! " + e.Message);
                    return View("Error");
                }
            }

        }


        //Login Controllers
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            Nlogger.Info("User entered in Login Controller.");
            
            using (var db = new SourceControlEntities())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        UserDetail userDetail = db.UserDetails.FirstOrDefault(m => m.EmailId == user.EmailId && m.Password == user.Password);
                        if (userDetail != null)
                        {
                            FormsAuthentication.SetAuthCookie(userDetail.EmailId, true);
                            Session["userName"] = userDetail.Name;
                            Session["userId"] = userDetail.Id;
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.FialureMessage = "No user Found";
                            return View();
                        }
                    }
                    return View();
                }
                catch(Exception e)
                {
                    Nlogger.Error("Exception !! " + e.Message);
                    return View("Error");
                }
                
            }
        }   

        // Signout Controller
        public ActionResult SignOut()
        {
            Nlogger.Info("User SignedOut");
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }


        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Nlogger.Info("User entered in Edit Controller to get Edit Form.");

            EditViewModel user = new EditViewModel();

            using (var db = new SourceControlEntities())
            {
                try
                {
                    UserDetail userDetail = db.UserDetails.FirstOrDefault(m => m.Id == id);

                    if (userDetail != null)
                    {
                        user.Id = userDetail.Id;
                        user.Name = userDetail.Name;
                        user.EmailId = userDetail.EmailId;
                        user.ContactNo = userDetail.ContactNo;
                        user.Gender = userDetail.Gender;
                        user.BirthDate = userDetail.BirthDate;
                        user.Experience = userDetail.Experience;
                        user.ImagePath = userDetail.ImagePath;

                        return View(user);
                    }
                    ViewBag.Message = "Please Login Again";
                    return View("Login");
                }
                catch(Exception e)
                {
                    Nlogger.Error("Exception !! " + e.Message);
                    return View("Error");
                }
                
            }
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel user)
        {
            Nlogger.Info("User entered in Edit Controller by submitting Edit Request.");

            try
            {
                if (ModelState.IsValid)
                {
                    int maxImageBytes = 5000000;
                    if (user.ImageFile != null)
                    {
                        var fileName = Path.GetFileName(user.ImageFile.FileName);

                        if (user.ImageFile.ContentLength < maxImageBytes)// && supportedTypes.Contains(imageExt))
                        {
                            var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                            user.ImageFile.SaveAs(path);
                            user.ImagePath = "~/Images/" + user.ImageFile.FileName;
                        }
                        else
                        {
                            ViewBag.FailureMessage("File Size must be Less than 4MB");
                            return View("Error");
                        }
                    }

                    using (var db = new SourceControlEntities())
                    {
                        UserDetail userDetail = db.UserDetails.FirstOrDefault(m => m.EmailId == user.EmailId);
                        userDetail.Name = user.Name;
                        userDetail.ContactNo = user.ContactNo;
                        userDetail.Gender = user.Gender;
                        userDetail.BirthDate = user.BirthDate;
                        userDetail.Experience = user.Experience;
                        userDetail.ImagePath = user.ImagePath;
                        db.SaveChanges();
                        user.Id = userDetail.Id;
                        ViewBag.SuccessMessage = "Details Updated Successfully";
                        return RedirectToAction("Details", new { id = user.Id });
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                Nlogger.Error("Exception !! " + e.Message);
                return View("Error");
            }
        }


        [Authorize]
        public ActionResult Details(int id)
        {
            Nlogger.Info("User entered in Details Controler.");

            UserModel user = new UserModel();

            using(var db = new SourceControlEntities())
            {
                UserDetail userDetail = db.UserDetails.FirstOrDefault(m => m.Id == id);


                try
                {
                    if (userDetail != null)
                    {
                        user.Id = userDetail.Id;
                        user.Name = userDetail.Name;
                        user.EmailId = userDetail.EmailId;
                        user.ContactNo = userDetail.ContactNo;
                        user.Gender = userDetail.Gender;
                        user.BirthDate = userDetail.BirthDate;
                        user.Experience = userDetail.Experience;
                        if (userDetail.ImagePath != null)
                        {
                            user.ImagePath = userDetail.ImagePath;
                        }
                        else
                        {
                            user.ImagePath = "/Images/Screenshot(82).png";
                        }

                        return View(user);
                    }
                }
                catch (Exception e)
                {
                    Nlogger.Error("Exception !! " + e.Message);
                    return View("Error");
                }

                ViewBag.Message($"No user exists with  Id:{User.Identity}");
                return View("Error");
            }
        }
    }
}