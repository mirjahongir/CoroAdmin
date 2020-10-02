using Domain.Entities.Users;

using MediatR;

using Repo;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using UserHandler.Querys;
using UserHandler.Responses;

namespace UserHandler.Handlers
{
    public class RemovePropsQueryHandler : IRequestHandler<RemoveQuery, RemoveResult>
    {
        IRepository<User, string> _user;
        //IRepository<,string>
        public RemovePropsQueryHandler(IRepository<User, string> user)
        {
            _user = user;
        }

        public async Task<RemoveResult> Handle(RemoveQuery request, CancellationToken cancellationToken)
        {
            foreach (var i in request.Users)
            {
                var user = _user.Get(i);

                switch (request.PropsName)
                {
                    case "server": { RemoveServer(request, user); } break;
                    case "project": { RemoveProject(request, user); } break;
                }
                _user.Update(user);
            }
            return new RemoveResult() { IsSuccess = true };
        }
        public bool RemoveServer(RemoveQuery request, User user)
        {
            var server = user.UserServers.FirstOrDefault(mbox => mbox.ServerId == request.Id);
            if(server== null)
            {
                return false;
            }
            user.UserServers.Remove(server);
            return true;
        }
        public bool RemoveProject(RemoveQuery request, User user)
        {
            var project = user.UserProjects.FirstOrDefault(m => m.ProjectId == request.Id);
            if(project== null)
            {
                return false;
            }
            user.UserProjects.Remove(project);
            return true;
        }
    }
}
