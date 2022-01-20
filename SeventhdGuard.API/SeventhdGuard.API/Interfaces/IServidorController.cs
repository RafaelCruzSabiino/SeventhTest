using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.ENTITY;

namespace SeventhdGuard.API.Interfaces
{
    public interface IServidorController
    {
        ObjectResult Add([FromBody] Servidor entity);
        ObjectResult Delete(string serverId);
        ObjectResult Get(string serverId);
        ObjectResult GetAll();
        bool ServerVerify(string serverId);
    }
}
