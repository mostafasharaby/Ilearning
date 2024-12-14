using Microsoft.AspNetCore.Identity;

namespace Demo1.Models
{
    public class AppUser:IdentityUser
    {
      public  string Address { get; set; }        
    }
    public class StudentUser : IdentityUser
    {
        public string Faculty { get; set; }
        public string Address { get; set; }
    }
}
