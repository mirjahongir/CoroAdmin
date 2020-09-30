using MediatR;

using UserHandler.Responses;

namespace UserHandler.Querys
{
    public class RemoveQuery : IRequest<RemoveResult>
    {
        public string PropsName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
}
