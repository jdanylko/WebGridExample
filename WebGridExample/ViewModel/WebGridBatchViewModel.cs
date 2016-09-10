using System.Collections.Generic;
using WebGridExample.Models;
namespace WebGridExample.ViewModel
{
    public class WebGridBatchViewModel: BaseViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public User User { get; set; }
    }
}