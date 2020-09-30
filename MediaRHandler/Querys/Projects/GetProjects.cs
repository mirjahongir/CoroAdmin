using Domain.Entities.Projects;
using MediatR;
using System.Collections.Generic;

namespace ProjectHandler.Querys.Projects
{
   public class GetProjectsQuery:IRequest<List<Project>>
    {
        public GetProjectsQuery(List<string> ids)
        {
            Projects = ids;
        }
        public List<string> Projects { get; private set; }
    }
}
