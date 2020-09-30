using Domain.Entities.Projects;


using ProjectHandler.Querys.Projects;

using MediatR;

using MongoDB.Driver;

using Repo;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectHandler.Handlers.Projects
{
    public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, List<Project>>
    {
        //IRepository<Project, string> _project;
        public IMongoDatabase Database { get { return _data; } }
        IMongoDatabase _data;
        public IMongoCollection<Project> Collection { get { return _db; } }
        public IMongoCollection<Project> _db;
        public GetProjectsHandler(IRepository<Project, string> project,
            IMongoDatabase data
            )
        {
            _data = data;
            _db = _data.GetCollection<Project>(typeof(Project).Name.ToLower());
        }

        public async Task<List<Project>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var filter = Builders<Project>.Filter;
            var query = filter.In("_id", request.Projects);
            return _db.Find(query).ToList();

        }
    }
}
