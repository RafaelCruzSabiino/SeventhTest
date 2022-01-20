using System.Collections.Generic;

namespace SeventhdGuard.DAO.Interfaces
{
    public interface IBaseDao<TEntity>
    {
        int Add(TEntity entity);
        int Update(TEntity entity);        
        IEnumerable<TEntity> GetAll();        
    }
}
