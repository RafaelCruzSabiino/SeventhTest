using SeventhdGuard.ENTITY;
using System;
using System.Collections.Generic;

namespace SeventhdGuard.DAO.Interfaces
{
    public interface IVideoDao : IBaseDao<Video>
    {
        int Delete(string serverId, string videoId);
        Video Get(string serverId, string videoId);
        IEnumerable<Video> GetVideoByServer(string idServer);
        IEnumerable<Video> GetVideoByDate(DateTime date);
    }
}
