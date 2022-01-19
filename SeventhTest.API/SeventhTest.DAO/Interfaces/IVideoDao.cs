using SeventhTest.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeventhTest.DAO.Interfaces
{
    public interface IVideoDao : IBaseDao<Video>
    {
        IEnumerable<Video> GetVideoByServer(int idServer);
    }
}
