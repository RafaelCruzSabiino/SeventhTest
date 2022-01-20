using SeventhdGuard.ENTITY;

namespace SeventhdGuard.DAO.Interfaces
{
    public interface IServidorDao : IBaseDao<Servidor>
    {
        int Delete(string serverId);
        Servidor Get(string serverId);
    }
}
