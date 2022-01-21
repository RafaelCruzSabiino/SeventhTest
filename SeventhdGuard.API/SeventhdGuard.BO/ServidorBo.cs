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
            ResultInfo resultInfo = new ResultInfo();

            try
            {
                resultInfo.RowsAffected = Dao.Add(entity);

                if (resultInfo.RowsAffected <= 0)
                {
                    throw new Exception("Erro ao inserir!");
                }
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo Update(Servidor entity)
        {
            ResultInfo resultInfo = new ResultInfo();

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
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo Delete(string serverId)
        {
            ResultInfo resultInfo = new ResultInfo();

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
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo<Servidor> Get(string serverId)
        {
            ResultInfo<Servidor> resultInfo = new ResultInfo<Servidor>();

            try
            {
                resultInfo.Item = Dao.Get(serverId);
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo<Servidor> GetAll()
        {
            ResultInfo<Servidor> resultInfo = new ResultInfo<Servidor>();

            try
            {
                resultInfo.Items = Dao.GetAll();
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        #endregion
    }
}
