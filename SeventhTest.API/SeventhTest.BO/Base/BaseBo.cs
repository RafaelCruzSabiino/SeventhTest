using SeventhTest.DAO.Base;
using SeventhTest.ENTITY.Base;
using System;

namespace SeventhTest.BO.Base
{
    public abstract class BaseBo<TEntity, TDao> where TEntity : new() where TDao : BaseDao<TEntity>, new()
    {
        #region "Variables"

        protected ResultInfo<TEntity> resultInfoModel;
        protected ResultInfo          resultInfo;

        #endregion

        #region "Properties"

        protected TDao Dao { get; private set; }

        #endregion

        #region "Construct"

        protected BaseBo() 
        {
            resultInfoModel = new ResultInfo<TEntity>();
            resultInfo      = new ResultInfo(); 
            Dao = new TDao();
        }

        #endregion

        #region "Protected Methods"

        protected void ExceptionMapper(Exception ex) 
        {
            resultInfo.Exception = ex;
            resultInfo.Message   = ex.Message;
            resultInfo.Success   = false;
        }

        protected void ExceptionMapperModel(Exception ex)
        {
            resultInfoModel.Exception = ex; 
            resultInfoModel.Message   = ex.Message;
            resultInfoModel.Success   = false;    
        }

        #endregion
    }
}
