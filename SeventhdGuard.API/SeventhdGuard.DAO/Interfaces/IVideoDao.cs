using SeventhdGuard.ENTITY;
using System.Collections.Generic;

namespace SeventhdGuard.DAO.Interfaces
{
    public interface IVideoDao : IBaseDao<Video>
    {
        IEnumerable<Video> GetVideoByServer(int idServer);
    }
}
