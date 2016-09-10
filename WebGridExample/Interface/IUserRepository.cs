using System.Collections.Generic;
using MvcPaging;
using WebGridExample.Models;
using WebGridExample.ViewModel;

namespace WebGridExample.Interface
{
    public interface IUserRepository: IRepository<User>
    {
        User GetById(int id);
        IPagedList<User> GetPagedUsers(PagingModel model);
        IEnumerable<User> GetPagedUsers(int? page, int pageSize);
    }
}