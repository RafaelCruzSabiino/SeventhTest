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
                var resultServer = new ServidorBo().Get(entity.IdServer);

                if (resultServer.Item != null && !string.IsNullOrEmpty(resultServer.Item.Id))
                {
                    entity.Id               = Guid.NewGuid().ToString();
                    resultInfo.RowsAffected = Dao.Add(entity);

                    if (resultInfo.RowsAffected <= 0)
                    {
                        throw new Exception("Erro ao inserir");
                    }
                }
                else 
                {
                    throw new Exception("Servidor não encontrado");
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

        public ResultInfo Delete(string serverId, string videoId)
        {
            try
            {
                resultInfo.RowsAffected = Dao.Delete(serverId, videoId);

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

        public ResultInfo<Video> Get(string serverId, string videoId)
        {
            try
            {
                resultInfoModel.Item = Dao.Get(serverId, videoId);
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

        public ResultInfo<Video> GetVideoByServer(string idServer)
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
