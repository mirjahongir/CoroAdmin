
using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using UserHandler.Handlers;
using UserHandler.Querys;
using UserHandler.Responses;

namespace WepApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        IMediator _mediator;
        IMapper _mapper;
        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public Task<LoginResult> Login([FromBody] LoginQuery model)
        {
            return _mediator.Send<LoginResult>(model);
        }
        public async Task<LoginResult> Register([FromBody] RegisterQuery model)
        {
            var registerResult = await _mediator.Send<RegisterResult>(model);
            if (registerResult.IsSuccess)
            {
                var loginQuery = _mapper.Map<RegisterQuery, LoginQuery>(model);
                return await _mediator.Send<LoginResult>(loginQuery);
            }
            return null;
        }
        public Task<AddPropsResponse> AddUserProps([FromBody] AddPropsQuery model)
        {
            return _mediator.Send<AddPropsResponse>(model);
        }
        public Task<RemoveResult> RemoveUserProps([FromBody] RemoveQuery model)
        {
            return _mediator.Send<RemoveResult>(model);
        }

    }


}
