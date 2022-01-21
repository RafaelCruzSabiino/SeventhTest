using SeventhdGuard.DAO.Base;
using SeventhdGuard.ENTITY.Base;
using System;

namespace SeventhdGuard.BO.Base
{
    public abstract class BaseBo<TEntity, TDao> where TEntity : new() where TDao : BaseDao<TEntity>, new()
    {
        #region "Properties"

        protected TDao Dao { get; private set; }

        #endregion

        #region "Construct"

        protected BaseBo()
        {
            Dao = new TDao();
        }

        #endregion
    }
}
