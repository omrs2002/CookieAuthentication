using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAuthentication.Web.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public IEnumerable<Users> GetUsers()
        {
            return new List<Users>() 
            { 
                new Users 
                { Id = 101, UserName = "anet", Name = "Anet", EmailId = "anet@test.com", Password = "anet123" },
                new Users
                { Id = 102, UserName = "anet2", Name = "Anet2", EmailId = "anet2@test.com", Password = "anet1232" }

            };
        }
    }

}
