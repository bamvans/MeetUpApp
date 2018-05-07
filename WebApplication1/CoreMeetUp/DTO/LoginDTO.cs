using CoreMeetUp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreMeetUp.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }

        public LoginDTO() { }

        public LoginDTO(Login login)
        {
            Id = login.Id;
            Pass = login.Pass;
            Email = login.Email;
        }

        public void Save(Login target)
        {
            target.Pass = Pass;
            target.Email = Email;
        }
    }
}