using SeventhdGuard.ENTITY;

namespace SeventhdGuard.DAO.Interfaces
{
    public interface IServidorDao : IBaseDao<Servidor>
    {
        int Update(Servidor entity, string serverId);
        int Delete(string serverId);
        Servidor Get(string serverId);
    }
}
