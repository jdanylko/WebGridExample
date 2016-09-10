using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGridExample.Models
{
    public class WebGridFilterModel
    {
        public IEnumerable<User> Users { get; set; }
        public string HeadingText { get; set; }
        public Func<User, string> Property { get; set; }
    }
}
