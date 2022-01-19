using SeventhTest.ENTITY;
using SeventhTest.ENTITY.Base;

namespace SeventhTest.BO.Interfaces
{
    public interface IVideoBo : IBaseBo<Video>
    {
        ResultInfo<Video> GetVideoByServer(int idServer);
    }
}
