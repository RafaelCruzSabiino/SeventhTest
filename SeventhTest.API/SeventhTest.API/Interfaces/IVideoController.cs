using Microsoft.AspNetCore.Mvc;
using SeventhTest.ENTITY;

namespace SeventhTest.API.Interfaces
{
    public interface IVideoController : IBaseController<Video>
    {
        StatusCodeResult GetVideoByServer(int idServer);
    }
}
