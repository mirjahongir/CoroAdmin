
using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

using UserHandler.Querys;
using UserHandler.Responses;

namespace UserHandler.Handlers
{
    public class RemovePropsQueryHandler : IRequestHandler<RemoveQuery, RemoveResult>
    {
        public Task<RemoveResult> Handle(RemoveQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
