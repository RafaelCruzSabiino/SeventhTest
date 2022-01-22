using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.ENTITY;

namespace SeventhdGuard.API.Interfaces
{
    public interface IServidorController
    {
        ObjectResult Add([FromBody] Servidor entity);
        ObjectResult Update([FromBody] Servidor entity, string serverId);
        ObjectResult Delete(string serverId);
        ObjectResult Get(string serverId);
        ObjectResult GetAll();
        StatusCodeResult VerifyServer(string serverId);
    }
}
