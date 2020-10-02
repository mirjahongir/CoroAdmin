
using CoreResult;

using Domain.Entities.Servers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Repo;

using ServerHandler.Querys;
using ServerHandler.Responses;

using System.Threading.Tasks;

namespace WepApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ServerController : Controller
    {
        IMediator _media;
        IRepository<Server, string> _server;
        public ServerController(IMediator media, IRepository<Server, string> server)
        {
            _media = media;
            _server = server;
        }
        [HttpGet]
        public async Task<ResponseCore<AddServerResult>> AddServer([FromBody] AddServerQuery model)
        {
            return await _media.Send<AddServerResult>(model);
        }
        [HttpPut]
        public async Task<ResponseCore<ActionServerResult>> ActionServer([FromBody] ActionServerQuery model)
        {
            return await _media.Send(model);
        }
        [HttpDelete]
        public async Task DeleteServer(string id)
        {
            _server.Remove(id);
            return;
        }
        
    }


}
