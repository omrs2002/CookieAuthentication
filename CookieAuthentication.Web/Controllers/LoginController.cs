using CookieAuthentication.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookieAuthentication.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin([Bind] Users user)
        {
            // username = anet  
            var users = new Users();
            var logedInUser = users.GetUsers()
                .Where( s => s.UserName == user.UserName && s.Password == user.Password ).FirstOrDefault();

            if (logedInUser != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, logedInUser.UserName),
                    new Claim(ClaimTypes.Email, logedInUser.EmailId)
                 };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }

}
