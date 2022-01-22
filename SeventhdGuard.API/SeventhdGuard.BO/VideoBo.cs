using SeventhdGuard.BO.Base;
using SeventhdGuard.BO.Interfaces;
using SeventhdGuard.COMMON;
using SeventhdGuard.DAO;
using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;
using System;
using System.Linq;

namespace SeventhdGuard.BO
{
    public class VideoBo : BaseBo<Video, VideoDao>, IVideoBo
    {
        #region "Public Methods"

        public ResultInfo Add(Video entity)
        {
            ResultInfo resultInfo = new ResultInfo();

            try
            {
                var resultServer = new ServidorBo().Get(entity.IdServer);

                if (resultServer.Item != null && !string.IsNullOrEmpty(resultServer.Item.Id))
                {                   
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
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }        

        public ResultInfo Delete(string serverId, string videoId)
        {
            ResultInfo resultInfo = new ResultInfo();

            try
            {
                if (!new Arquivo().Delete(string.Format("\\{0}", serverId), string.Format("{0}.mp4", videoId)))
                {
                    throw new Exception("Erro ao deletar arquivo!");
                }

                resultInfo.RowsAffected = Dao.Delete(serverId, videoId);

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

        public ResultInfo<Video> Get(string serverId, string videoId)
        {
            ResultInfo<Video> resultInfo = new ResultInfo<Video>();

            try
            {
                resultInfo.Item         = Dao.Get(serverId, videoId);
                resultInfo.Item.Arquivo = System.Convert.ToBase64String(new Arquivo().Get(string.Format("\\{0}", serverId), string.Format("{0}.mp4", videoId)));
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo<Video> GetAll()
        {
            ResultInfo<Video> resultInfo = new ResultInfo<Video>();

            try
            {
                resultInfo.Items = Dao.GetAll();

                if (resultInfo.Items.Any()) 
                {
                    foreach (var video in resultInfo.Items) 
                    {
                        video.Arquivo = System.Convert.ToBase64String(new Arquivo().Get(string.Format("\\{0}", video.IdServer), string.Format("{0}.mp4", video.Id)));
                    }
                }                
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo<Video> GetVideoByServer(string idServer)
        {
            ResultInfo<Video> resultInfo = new ResultInfo<Video>();

            try
            {
                resultInfo.Items = Dao.GetVideoByServer(idServer);

                if (resultInfo.Items.Any())
                {
                    foreach (var video in resultInfo.Items)
                    {
                        video.Arquivo = System.Convert.ToBase64String(new Arquivo().Get(string.Format("\\{0}", video.IdServer), string.Format("{0}.mp4", video.Id)));
                    }
                }
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
