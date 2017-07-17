using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DVMN.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Member : IdentityUser
    {
        public string FullName { get; set; }
        public string PictureSmall { get; set; }
        public string PictureBig { get; set; }
        public string DateofBirth { get; set; }
        public string Facebook { get; set; }
        public int Score { get; set; }
    }
}
