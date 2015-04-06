using System.Collections.Generic;
using WebGridExample.Models;

namespace WebGridExample.Interface
{
    public interface IUserRepository: IRepository<User>
    {
        User GetById(int id);
        IEnumerable<User> GetPagedUsers(int? pageIndex, int pageSize);
    }
}