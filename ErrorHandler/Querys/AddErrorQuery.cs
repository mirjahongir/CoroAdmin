using Domain.Entities.Projects;

using ErrorHandler.Responses;

using MediatR;


namespace ErrorHandler.Querys
{
    public class AddErrorQuery : IRequest<AddErrorResponse>
    {
        public Project Project { get; set; }
    }
}
