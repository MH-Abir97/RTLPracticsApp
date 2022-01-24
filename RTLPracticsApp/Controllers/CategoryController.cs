using RTLPracticsApp.Data;
using RTLPracticsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace RTLPracticsApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAllCategory()
        {
            var category = db.Categories.ToList();
            return Json(category,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string EmailSendSave(EmailSend emailSend)
        {
            //var Obj = new Object();
           // string SoNo = "SO: SO/20-21/3";
         
            

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(emailSend.FormEmail);
            mm.Subject = emailSend.Subject;
            mm.Body = emailSend.Body;

            foreach (var toEmail in emailSend.To)
            {
                mm.To.Add(toEmail);

            }

            if (emailSend.ToBCCEmail.Length >0 )
            {
                if (emailSend.ToBCCEmail == null)
                {
                    foreach (var toCC in emailSend.ToBCCEmail)
                    {
                        mm.To.Add(toCC);
                    }
                }
            }

            if (emailSend.ToCCEmail==null)
            {
                if (emailSend.ToCCEmail.Length > 0)
                {
                    foreach (var toCC in emailSend.ToCCEmail)
                    {
                        mm.To.Add(toCC);
                    }
                }
            }
           
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(emailSend.FormEmail,emailSend.Password);
            smtp.Send(mm);
          
            return "The mail has been Sent"+ emailSend.To;
        }

        [HttpPost]
        public string EmailSend(EmailSend emailSend)
        {
            //string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"];
            //string senderEmailPass = System.Configuration.ConfigurationManager.AppSettings["SenderEmailPass"];

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("mhabir97@gmail.com");
            mm.Subject = emailSend.Subject;
            mm.Body = emailSend.Body;
            try
            {
                foreach (var email in emailSend.To)
                {
                    mm.To.Add(email);
                }

                // for cc email
                if (emailSend.ToCCEmail != null)
                {
                    if (emailSend.ToCCEmail.Length > 0)
                    {
                        foreach (var cc in emailSend.ToCCEmail)
                        {
                            mm.CC.Add(cc);
                        }
                    }
                }


                // for bcc email
                if (emailSend.ToBCCEmail != null)
                {
                    if (emailSend.ToBCCEmail.Length > 0)
                    {
                        foreach (var bcc in emailSend.ToBCCEmail)
                        {
                            mm.CC.Add(bcc);
                        }
                    }
                }


                mm.IsBodyHtml = true;

                SendSmtpEmail(mm);
                return "The mail has been Sent";
            }
            catch (Exception ex)
            {
                return "Something Went Wrong, Please try again!!!" + ex;
            }



        }

        public void SendSmtpEmail(MailMessage mailMessage)
        {
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = System.Configuration.ConfigurationManager.AppSettings["SenderEmailHost"];
            //smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SenderEmailPort"]);
            //smtp.UseDefaultCredentials = true;
            //smtp.EnableSsl = false;
            //smtp.Credentials = new NetworkCredential(senderEmail, senderEmailPass);
            //smtp.Send(mailMessage);

          
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("mhabir97@gmail.com","MHAnwar Abir");
            smtp.Send(mailMessage);
        }
    }
}