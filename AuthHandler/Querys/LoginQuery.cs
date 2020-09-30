using MediatR;
using UserHandler.Responses;

namespace UserHandler.Querys
{
    public class LoginQuery : IRequest<LoginResult>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        
    }
}
