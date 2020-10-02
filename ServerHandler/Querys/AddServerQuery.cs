using Domain.Entities.Servers;
using MediatR;
using ServerHandler.Responses;
using System.Collections.Generic;

namespace ServerHandler.Querys
{
    public class AddServerQuery : IRequest<AddServerResult>
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public string CreateUserId { get; set; }
        public List<ServerLogins> ServerLogins { get; set; }
        public List<ServerProjects> ServerProjects { get; set; }
    }
}
