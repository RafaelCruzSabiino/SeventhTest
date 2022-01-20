using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;

namespace SeventhdGuard.BO.Interfaces
{
    public interface IVideoBo : IBaseBo<Video>
    {
        ResultInfo Delete(string serverId, string videoId);
        ResultInfo<Video> Get(string serverId, string videoId);
        ResultInfo<Video> GetVideoByServer(string idServer);
    }
}
