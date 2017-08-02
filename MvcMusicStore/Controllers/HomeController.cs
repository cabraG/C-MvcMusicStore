using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
   
    public class HomeController : Controller
    {
        LoginUser storeDB = new LoginUser();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", " Home");
        }
        [HttpPost]
        public ActionResult Login(MuUsers login)
        {
            if (login.MuUserId == 0) {
                login.MuUserId = 2;
            }
            if (ModelState.IsValid)
            {
                var user = storeDB.MuUsers.Where(m => m.MuUserName==login.MuUserName);
                
                
                if (user == null) ModelState.AddModelError("username", "用户名不存在");
                else if (login.MuPassWord != user.Single().MuPassWord)
                {
                    ModelState.AddModelError("Password", "密码不正确");
                }
                else {
                    Session.Add("UserId", login.MuUserId);
                    return RedirectToAction("Index", "Home");
                }

            }
                return View();
        }


    }
}