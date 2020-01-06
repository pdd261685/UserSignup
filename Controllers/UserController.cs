using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using UserSignup.ViewModels;

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
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        
        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                Users newUser = new Users
                {
                    UserName=addUserViewModel.UserName,
                    Password=addUserViewModel.Password,
                    Email=addUserViewModel.Email
                };

                return Redirect("Index?username=" + newUser.UserName);
            }
            return View(addUserViewModel);
        }
    }
}
