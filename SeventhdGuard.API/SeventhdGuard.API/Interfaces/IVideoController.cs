using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.ENTITY;

namespace SeventhdGuard.API.Interfaces
{
    public interface IVideoController
    {
        ObjectResult Add([FromBody] Video entity, string serverId);
        ObjectResult Delete(string serverId, string videoId);
        ObjectResult Get(string serverId, string videoId);
        ObjectResult GetVideoByServer(string serverId);
    }
}
