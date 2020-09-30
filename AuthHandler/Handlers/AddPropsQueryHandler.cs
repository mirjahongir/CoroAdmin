
using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

using UserHandler.Querys;
using UserHandler.Responses;

namespace UserHandler.Handlers
{
    public class AddPropsQueryHandler : IRequestHandler<AddPropsQuery, AddPropsResponse>
    {
        public Task<AddPropsResponse> Handle(AddPropsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
