using SeventhTest.BO.Base;
using SeventhTest.BO.Interfaces;
using SeventhTest.DAO;
using SeventhTest.ENTITY;
using SeventhTest.ENTITY.Base;
using System;

namespace SeventhTest.BO
{
    public class ServidorBo : BaseBo<Servidor, ServidorDao>, IBaseBo<Servidor>
    {
        #region "Public Methods"
        
        public ResultInfo Add(Servidor entity)
        {            
            try
            {
                entity.Id     = new Guid().ToString();
                resultInfo.Id = Dao.Add(entity);

                if (resultInfo.Id <= 0) 
                {
                    throw new Exception("Erro ao inserir!");
                }
            }
            catch (Exception ex) 
            {
                ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo Update(Servidor entity)
        {
            try
            {
                resultInfo.RowsAffected = Dao.Update(entity);

                if (resultInfo.RowsAffected <= 0)
                {
                    throw new Exception("Erro ao alterar!");
                }
            }
            catch (Exception ex)
            {
                ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo Delete(int id)
        {
            try
            {
                resultInfo.RowsAffected = Dao.Delete(id);

                if (resultInfo.RowsAffected <= 0)
                {
                    throw new Exception("Erro ao deletar!");
                }
            }
            catch (Exception ex)
            {
                ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo<Servidor> Get(int id)
        {
            try
            {
                resultInfoModel.Item = Dao.Get(id);
            }
            catch (Exception ex)
            {
                ExceptionMapperModel(ex);
            }

            return resultInfoModel;
        }

        public ResultInfo<Servidor> GetAll()
        {
            try
            {
                resultInfoModel.Items = Dao.GetAll();
            }
            catch (Exception ex)
            {
                ExceptionMapperModel(ex);
            }

            return resultInfoModel;
        }

        #endregion

    }
}
