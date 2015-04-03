using System;

namespace WebGridExample.Models
{
    [Serializable]
    public class User
    {
        public int Id { get; set; } // Id (Primary key)
        public string UserName { get; set; } // UserName
        public DateTime LastLogin { get; set; } // LastLogin
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName

        public User()
        {
            LastLogin = System.DateTime.Now;
        }
    }
}