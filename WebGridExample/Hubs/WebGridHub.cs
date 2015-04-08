using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
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
    }
}