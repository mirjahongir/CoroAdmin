using AutoMapper;

using Domain.Entities.Servers;

using MediatR;

using MongoDB.Libmongocrypt;

using Repo;

using ServerHandler.Querys;
using ServerHandler.Responses;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHandler.Handlers
{
    public class AddServerHandler : IRequestHandler<AddServerQuery, AddServerResult>
    {
        IRepository<Server, string> _server;
        IMapper _mapper;
        public AddServerHandler(IRepository<Server, string> server, IMapper mapper)
        {
            _server = server;
            _mapper = mapper;
        }
        public async Task<AddServerResult> Handle(AddServerQuery request, CancellationToken cancellationToken)
        {
            var server = _server.Find(m => m.Ip == request.Ip).FirstOrDefault();
            if (server != null)
            {

            }
            server = _mapper.Map<Server>(request);
            server.CreateUserId = request.CreateUserId;
            _server.Add(server);
            return new AddServerResult() { Id = server.Id, Ip = server.Ip, Name = server.Name };

        }
    }
}
