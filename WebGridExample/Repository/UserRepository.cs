using System.Data.Entity;
using WebGridExample.Interface;
using WebGridExample.Models;

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
    }
}
