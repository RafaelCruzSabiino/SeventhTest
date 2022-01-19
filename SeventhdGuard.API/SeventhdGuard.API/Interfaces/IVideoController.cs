using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.ENTITY;

namespace SeventhdGuard.API.Interfaces
{
    public interface IVideoController : IBaseController<Video>
    {
        StatusCodeResult GetVideoByServer(int idServer);
    }
}
