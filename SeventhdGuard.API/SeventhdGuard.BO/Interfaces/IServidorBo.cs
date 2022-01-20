using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;

namespace SeventhdGuard.BO.Interfaces
{
    public interface IServidorBo : IBaseBo<Servidor>
    {
        ResultInfo Delete(string serverid);
        ResultInfo<Servidor> Get(string serverid);
    }
}
