using MediatR;

using UserHandler.Responses;

namespace UserHandler.Querys
{
    public class RegisterQuery : IRequest<RegisterResult>
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ComfirmPassword { get; set; }
        
    }
    
}
