using SeventhdGuard.BO.Base;
using SeventhdGuard.BO.Interfaces;
using SeventhdGuard.DAO;
using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;
using System;

namespace SeventhdGuard.BO
{
    public class ServidorBo : BaseBo<Servidor, ServidorDao>, IServidorBo
    {
        #region "Public Methods"

        public ResultInfo Add(Servidor entity)
        {
            try
            {
                entity.Id               = Guid.NewGuid().ToString();
                resultInfo.RowsAffected = Dao.Add(entity);

                if (resultInfo.RowsAffected <= 0)
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

        public ResultInfo Delete(string serverId)
        {
            try
            {
                resultInfo.RowsAffected = Dao.Delete(serverId);

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

        public ResultInfo<Servidor> Get(string serverId)
        {
            try
            {
                resultInfoModel.Item = Dao.Get(serverId);
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
