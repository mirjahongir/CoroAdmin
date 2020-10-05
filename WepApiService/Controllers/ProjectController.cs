using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Projects;
using ProjectHandler.Querys.Projects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repo;

namespace WepApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ErrorController : Controller
    {
        IRepository<Project, string> _project;
        IMediator _mediator;
        public ErrorController(IRepository<Project, string> project,
        IMediator mediator)
        {
            _project = project;
            _mediator = mediator;
        }
        [HttpPost]
        public Task AddError()
        {
            _project.Get()

        }
    }
    [Route("api/[controller]/[action]")]
    public class ProjectController : Controller
    {
        IMediator _mediator;
        IRepository<Project, string> _project;
        public ProjectController(IMediator mediator, IRepository<Project, string> project)
        {
            _mediator = mediator;
            _project = project;
        }
        [HttpGet]
        public async Task<Project> Get(string id)
        {
            var project = _project.Get(id);
            return project;
        }
        [HttpGet]
        public async Task<List<Project>> UserProects()
        {
            GetProjectsQuery query = new GetProjectsQuery(new List<string>());
            var result = await _mediator.Send(query);
            return result;

        }
       
        
    }



}
