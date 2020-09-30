using Domain.Entities.Users;

using MediatR;

using Repo;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using UserHandler.Querys;
using UserHandler.Responses;

namespace UserHandler.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterQuery, RegisterResult>
    {
        IRepository<User, string> _user;
        public RegisterHandler(IRepository<User, string> user)
        {
            _user = user;
        }
        public async Task<RegisterResult> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            var user = _user.Find(m => m.UserName == request.UserName).FirstOrDefault();
            if (user == null)
            {

            }
            user = new User() { UserName = request.UserName, Password = request.Password, PhoneNumber = request.PhoneNumber, UserProjects = new List<UserProject>(), UserServers = new List<UserServer>() };
            _user.Add(user);
            return new RegisterResult()
            {

            };

        }
    }
}
