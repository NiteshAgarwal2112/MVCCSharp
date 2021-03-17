using MVCCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCSharp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            Request.Cookies.Remove("user");
            Session.RemoveAll();
            return View();
        }
        [HttpPost]
        public ActionResult Login(string uname, string psw)
        {
            try
            {
                Request.Cookies.Remove("user");
                Session.RemoveAll();
                LoginDetails log = ValidateUser(uname, psw);
                if (log.IsAuthUser)
                {
                    Session["id"] = log.UserId;
                    Session["Name"] = log.UserName;
                    Session["IsAuth"] = log.IsAuthUser;
                    Session["Type"] = log.Role;
                    //return RedirectToAction("Details", "Account", new { id = log.UserId });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Invalid User Name Or Password";
                    return View();
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.Replace("\'", " ") + "')</script>");
                return View();

            }
        }
        private LoginDetails ValidateUser(string uname, string psw)
        {
            Accountcontext accountContext = new Accountcontext();
            Account account = accountContext.Accounts.FirstOrDefault(acc => (acc.FirstName == uname) && (acc.Empid == psw));
            LoginDetails obj = new LoginDetails();
            obj.IsAuthUser = false;
            try
            {

                Accountcontext accountContext1 = new Accountcontext();
                Account account1 = accountContext.Accounts.FirstOrDefault(acc => (acc.FirstName == uname) && (acc.Empid == psw));
                if (account != null)
                {
                    obj.UserId = account1.Personid;
                    obj.UserName = account1.FirstName;
                    obj.Role = account1.Type;
                    obj.IsAuthUser = true;
                }
            }
            catch (Exception ex)
            {
                obj.IsAuthUser = false;
                Response.Write("<script>alert('" + ex.Message.Replace("\'", " ") + "')</script>");
            }
            return obj;

        }
        private struct LoginDetails
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Role { get; set; }
            public bool IsAuthUser { get; set; }
        }
    }
   
}