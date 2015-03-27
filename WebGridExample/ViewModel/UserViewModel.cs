using System.Collections.Generic;
using WebGridExample.Models;

namespace WebGridExample.ViewModel
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public User User { get; set; }
    }
}