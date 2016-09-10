using System;
using System.Collections.Generic;
using WebGridExample.Models;

namespace WebGridExample.ViewModel
{
    public class WebGridFilterModel
    {
        public IEnumerable<User> Users { get; set; }
        public string HeadingText { get; set; }
        public Func<User, string> Property { get; set; }
    }
}