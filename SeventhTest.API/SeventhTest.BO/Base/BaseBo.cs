using SeventhTest.DAO.Base;

namespace SeventhTest.BO.Base
{
    public abstract class BaseBo<TEntity, TDao> where TEntity : new() where TDao : BaseDao<TEntity>, new()
    {
        #region "Properties"

        protected TDao Dao { get; set; }

        #endregion

        #region "Construct"

        protected BaseBo() 
        {
            Dao = new TDao();
        }

        #endregion
    }
}
