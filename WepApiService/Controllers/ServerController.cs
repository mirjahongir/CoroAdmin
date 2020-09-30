
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace WepApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ServerController : Controller
    {
        IMediator _media;
        public ServerController(IMediator media)
        {
            _media = media;
        }
        
    }


}
