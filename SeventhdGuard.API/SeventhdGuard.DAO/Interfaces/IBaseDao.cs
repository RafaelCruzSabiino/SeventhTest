using System.Collections.Generic;

namespace SeventhdGuard.DAO.Interfaces
{
    public interface IBaseDao<TEntity>
    {
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
    }
}
