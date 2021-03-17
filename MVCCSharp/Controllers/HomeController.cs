using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCSharp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
               return RedirectToAction("Login","Login");
            }
            try
            {
                if ((bool)Session["IsAuth"])
                {
                    switch (Session["Type"])
                    {
                        case "Sale":
                            ViewBag.myrole = "<ul class='nav navbar-nav' id='mUser'><li><a href='Home.aspx'>Home</a></li><li><a href='AssignLead.aspx'>Assigned Leads</a></li></ul>";
                            break;
                        case "Admin":
                            ViewBag.myrole = "<ul class='nav navbar-nav' id='mAdmin'><li><a href='../Home/Index'>Home</a></li><li><a href='../Account/Details'>Sales</a></li><li><a href='lead.aspx'>Lead</a></li></ul>";
                            break;

                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception EX)
            {
                Response.Write("<script>alert('" + EX.Message.Replace("\'", " ") + "')</script>");
                return RedirectToAction("Login", "Login");
            }
        }
        public String GetDetails()
        {
            return "<h1>Hello into GetDetails</h1>";
        }
    }
}