using Domain.Entities.Servers;
using Domain.Enums;

using MediatR;

using ServerHandler.Responses;

using System.Collections.Generic;

namespace ServerHandler.Querys
{
    public class ActionServerQuery:IRequest<ActionServerResult>
    {
        public EnumAction Action { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Id { get; set; }
        public List<ServerLogins> ServerLogins { get; set; }
        public List<ServerProjects> ServerProjects { get; set; }

    }
}
