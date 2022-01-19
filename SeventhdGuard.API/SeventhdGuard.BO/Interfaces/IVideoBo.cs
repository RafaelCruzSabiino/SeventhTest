using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;

namespace SeventhdGuard.BO.Interfaces
{
    public interface IVideoBo : IBaseBo<Video>
    {
        ResultInfo<Video> GetVideoByServer(int idServer);
    }
}
