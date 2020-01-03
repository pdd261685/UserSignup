using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult Index(string userName="User")
        {
            ViewBag.UserName = userName;
            return View();
        }

        
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Add(Users user,string vPassword)
        {
            ViewBag.UserName = user.UserName;
            ViewBag.Eamil = user.Email;
            if (!String.IsNullOrEmpty(user.Password) && !String.IsNullOrEmpty(user.UserName) && !String.IsNullOrEmpty(user.Email))
            {
                
                if (user.Password.Equals(vPassword))
                {
                    if (user.Password.Length > 8 && user.Password.Any(char.IsDigit))
                    {
                        return Redirect("Index?username=" + user.UserName);
                    }
                    else
                    {
                        ViewBag.error1 = "Password should contain a digit and should be 8 characters long";
                    }

                }
                else
                {
                    ViewBag.error2 = "Password and verify password don't match";
                }
            }
            else
            {
                ViewBag.error = "Empty fields";
            }

            return View();
        }
    }
}
