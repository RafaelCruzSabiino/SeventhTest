using System.Collections.Generic;

namespace SeventhdGuard.DAO.Interfaces
{
    public interface IBaseDao<TEntity>
    {
        int Add(TEntity entity);    
        IEnumerable<TEntity> GetAll();        
    }
}
