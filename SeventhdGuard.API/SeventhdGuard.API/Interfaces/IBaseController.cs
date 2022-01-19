using Microsoft.AspNetCore.Mvc;

namespace SeventhdGuard.API.Interfaces
{
    public interface IBaseController<TEntity>
    {
        StatusCodeResult Add([FromBody] TEntity entity);
        StatusCodeResult Delete(int id);
        StatusCodeResult GetAll();
        StatusCodeResult Get(int id);
    }
}
