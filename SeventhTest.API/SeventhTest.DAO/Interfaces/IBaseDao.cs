using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeventhTest.DAO.Interfaces
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
