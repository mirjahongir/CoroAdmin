using AutoMapper;

using Domain.Entities.Servers;
using Domain.Enums;

using MediatR;

using Repo;

using ServerHandler.Querys;
using ServerHandler.Responses;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHandler.Handlers
{
    public class ActionServerHandler : IRequestHandler<ActionServerQuery, ActionServerResult>
    {
        IRepository<Server, string> _server;
        IMapper _mapper;
        public ActionServerHandler(
         IRepository<Server, string> server,
        IMapper mapper
            )
        {
            _server = server;
            _mapper = mapper;
        }
        public async Task<ActionServerResult> Handle(ActionServerQuery request, CancellationToken cancellationToken)
        {
            var server = _server.Get(request.Id);
            if (server.ServerProjects == null)
            {
                server.ServerProjects = new System.Collections.Generic.List<ServerProjects>();
            }
            if (server.ServerLogins == null) server.ServerLogins = new System.Collections.Generic.List<ServerLogins>();
            switch (request.Action)
            {
                case EnumAction.Add: { EditHandler(server, request); } break;
                //case EnumAction.Update: { } break;
                case EnumAction.Delete: { Delete(server, request); } break;
            }
            _server.Update(server);
            return new ActionServerResult() { IsSuccess = true };
        }
        public bool Delete(Server server, ActionServerQuery request)
        {
            foreach (var i in request.ServerLogins)
            {
                var exsit = server.ServerLogins.FirstOrDefault(mbox => mbox.Id == i.Id);
                if (exsit == null)
                {
                    continue;
                }
                server.ServerLogins.Remove(exsit);
            }
            foreach (var i in request.ServerProjects)
            {
                var exist = server.ServerProjects.FirstOrDefault(m => m.ProjectId == i.ProjectId);
                if (exist == null)
                {

                }
                server.ServerProjects.Remove(exist);
            }
            return true;

        }
        public bool EditHandler(Server server, ActionServerQuery request)
        {
            foreach (var i in request.ServerLogins)
            {
                var exist = server.ServerLogins.FirstOrDefault(m => m.Login == i.Login || m.Name == i.Name);
                if (exist != null)
                {
                    continue;
                }
                server.ServerLogins.Add(i);
            }
            foreach (var i in request.ServerProjects)
            {
                var exist = server.ServerProjects.FirstOrDefault(mbox => mbox.ProjectId == i.ProjectId);
                if (exist != null)
                {
                }
                server.ServerProjects.Add(i);
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                server.Name = request.Name;
            }
            if (!string.IsNullOrEmpty(request.Ip))
            {
                server.Ip = request.Ip;
            }
            return true;
        }
    }
}
