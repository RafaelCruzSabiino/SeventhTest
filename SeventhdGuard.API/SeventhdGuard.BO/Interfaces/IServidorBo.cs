using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;

namespace SeventhdGuard.BO.Interfaces
{
    public interface IServidorBo : IBaseBo<Servidor>
    {
        ResultInfo Update(Servidor entity, string serverId);
        ResultInfo Delete(string serverid);
        ResultInfo<Servidor> Get(string serverid);
    }
}
