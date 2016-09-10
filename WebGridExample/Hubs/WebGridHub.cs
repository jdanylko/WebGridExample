using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebGridExample.Models;
using WebGridExample.Repository;

namespace WebGridExample.Hubs
{
    [HubName("webGridHub")]
    public class WebGridHub : Hub
    {
        private readonly UserRepository _repository;


        public WebGridHub() : this(new UserRepository()) { }

        public WebGridHub(UserRepository repository)
        {
            _repository = repository;
        }

        public Task GetPagedUsers(int page, int pageSize)
        {
            var records = _repository.GetPagedUsers(page, pageSize);
            return Clients.Caller.populateGrid(records);
        }

        public Task SaveRecord(User user)
        {
            var record = _repository.GetById(user.Id);
            record.UserName = user.UserName;
            record.FirstName = user.FirstName;
            record.LastName = user.LastName;
            record.LastLogin = user.LastLogin;

            _repository.SaveChanges();

            return Clients.Caller.recordSaved();
        }

        public ValidationMessage GetValidation(User user)
        {
            var message = new ValidationMessage();

            var validations = user.Validate(new ValidationContext(user));
            if (validations.Any())
            {
                message.Message = validations.First().ErrorMessage;
                message.MemberName = validations.First().MemberNames.First();
            }
            message.Success = !validations.Any();
            return message;
        }
    }
}