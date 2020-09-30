using MediatR;

using UserHandler.Responses;

namespace UserHandler.Querys
{
    public class AddPropsQuery : IRequest<AddPropsResponse>
    {
        public string PropsName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
}
