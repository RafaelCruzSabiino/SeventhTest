using SeventhdGuard.ENTITY.Base;

namespace SeventhdGuard.BO.Interfaces
{
    public interface IBaseBo<TEntity>
    {
        ResultInfo Add(TEntity entity);
        ResultInfo Update(TEntity entity);        
        ResultInfo<TEntity> GetAll();
    }
}
