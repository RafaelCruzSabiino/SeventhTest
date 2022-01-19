using SeventhTest.ENTITY.Base;

namespace SeventhTest.BO.Interfaces
{
    public interface IBaseBo<TEntity>
    {
        ResultInfo Add(TEntity entity);
        ResultInfo Update(TEntity entity);
        ResultInfo Delete(int id);
        ResultInfo<TEntity> GetAll();
        ResultInfo<TEntity> Get(int id);
    }
}
