using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MvcPaging;
using WebGridExample.Interface;
using WebGridExample.Models;
using WebGridExample.ViewModel;

namespace WebGridExample.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository() : this(new UserContext()) { }
        public UserRepository(DbContext context) : base(context) { }

        public User GetById(int id)
        {
            return First(e => e.Id == id);
        }

        public IPagedList<User> GetPagedUsers(PagingModel model)
        {
            var records = GetAll()
                .OrderBy(e=> e.UserName);
            var total = records.Count();
            return new PagedList<User>(records, model.PageIndex, model.PageSize, total);
        }

        public IEnumerable<User> GetPagedUsers(int? page, int pageSize)
        {
            var pageIndex = page - 1 ?? 0;
            return GetAll()
                .OrderBy(e => e.UserName)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
