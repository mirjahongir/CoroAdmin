using Domain.Entities.Projects;
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
    public class AddPropsQueryHandler : IRequestHandler<AddPropsQuery, AddPropsResponse>
    {
        IRepository<User, string> _user;
        IRepository<Project, string> _project;
        public AddPropsQueryHandler(IRepository<User, string> user, IRepository<Project, string> project)
        {
            _user = user;
            _project = project;
        }
        public async Task<AddPropsResponse> Handle(AddPropsQuery request, CancellationToken cancellationToken)
        {
            foreach (var i in request.Users)
            {
                try
                {
                    var user = _user.Get(i);
                    if (user == null)
                    {
                        continue;

                    }
                    if (user.UserServers == null)
                    {
                        user.UserServers = new System.Collections.Generic.List<UserServer>();
                    }
                    if (user.UserProjects == null)
                    {
                        user.UserProjects = new System.Collections.Generic.List<UserProject>();
                    }
                    switch (request.PropsName)
                    {
                        case "project":
                            {
                                AddProject(request, user);
                            }
                            break;
                        case "server": { AddServer(request, user); } break;
                    }
                }
                catch (Exception ext)
                {

                }
            }
            return new AddPropsResponse() { IsSuccess = true };

        }
        public void AddServer(AddPropsQuery request, User user)
        {
            if (user.UserServers.FirstOrDefault(m => m.ServerId == request.Id) != null)
            {
                return;
            }
            user.UserServers.Add(new UserServer()
            {
                DateTime = DateTime.Now,
                AddUserId = request.AddUserId,
                ServerId = request.Id,
                ServerName = request.Name
            });
            _user.Update(user);

        }
        public void AddProject(AddPropsQuery request, User user)
        {
            if (user.UserProjects.FirstOrDefault(m => m.ProjectId == request.Id) != null) return;
            user.UserProjects.Add(new UserProject() { AddDate = DateTime.Now, ProjectId = request.Id, ProjectName = request.Name, AddUserId = request.AddUserId });
            _user.Update(user);
        }
    }
}
