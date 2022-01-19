using SeventhdGuard.BO.Base;
using SeventhdGuard.BO.Interfaces;
using SeventhdGuard.DAO;
using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;
using System;

namespace SeventhdGuard.BO
{
    public class VideoBo : BaseBo<Video, VideoDao>, IVideoBo
    {
        #region "Public Methods"

        public ResultInfo Add(Video entity)
        {
            try
            {
                entity.Id     = new Guid().ToString();
                resultInfo.Id = Dao.Add(entity);

                if (resultInfo.Id <= 0)
                {
                    throw new Exception("Erro ao inserir");
                }
            }
            catch (Exception ex)
            {
                ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo Update(Video entity)
        {
            try
            {
                resultInfo.RowsAffected = Dao.Update(entity);

                if (resultInfo.RowsAffected <= 0)
                {
                    throw new Exception("Erro ao Alterar");
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

        public ResultInfo<Video> Get(int id)
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

        public ResultInfo<Video> GetAll()
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

        public ResultInfo<Video> GetVideoByServer(int idServer)
        {
            try
            {
                resultInfoModel.Items = Dao.GetVideoByServer(idServer);
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
