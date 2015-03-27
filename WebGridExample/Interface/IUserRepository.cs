using WebGridExample.Models;

namespace WebGridExample.Interface
{
    public interface IUserRepository: IRepository<User>
    {
        User GetById(int id);
    }
}