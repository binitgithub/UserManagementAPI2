using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI2.Models
{
    public class Profile
    {
        public int UserId { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public User User { get; set; }
    }
}