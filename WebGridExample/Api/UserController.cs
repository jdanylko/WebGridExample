using System.Collections.Generic;
using System.Web.Http;
using WebGridExample.Interface;
using WebGridExample.Models;
using WebGridExample.Repository;

namespace WebGridExample.Api
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _repository;
        public UserController() : this(new UserRepository()) { }
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET api/<controller> (Used for a test to make sure it works)
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<controller>/5
        public IEnumerable<User> GetPaging(int page, int pageSize)
        {
            return _repository.GetPagedUsers(page, pageSize);
        }

    }
}