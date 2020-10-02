using MediatR;
using System.Collections.Generic;
using UserHandler.Responses;

namespace UserHandler.Querys
{
    public class AddPropsQuery : IRequest<AddPropsResponse>
    {
        public string PropsName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string AddUserId { get; set; }
        public List<string> Users { get; set; }
    }
    
}
