﻿using SeventhdGuard.BO.Base;
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
            ResultInfo resultInfo = new();

            try
            {
                var resultServer = new ServidorBo().Get(entity.IdServer);

                if (resultServer.Item != null && !string.IsNullOrEmpty(resultServer.Item.Id))
                {
                    var upload = new Arquivo().Upload(string.Format("\\{0}", resultServer.Item.Ip), string.Format("{0}.mp4", entity.Id), System.Convert.FromBase64String(entity.Arquivo));

                    if (!upload)
                    {
                        throw new Exception("Erro ao inserir arquivo");
                    }

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
            ResultInfo resultInfo = new();

            try
            {
                if (!new Arquivo().Delete(string.Format("\\{0}", new ServidorBo().Get(serverId).Item.Ip), string.Format("{0}.mp4", videoId)))
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
            ResultInfo<Video> resultInfo = new();

            try
            {
                resultInfo.Item = Dao.Get(serverId, videoId);

                var arquivo = new Arquivo().Get(string.Format("\\{0}", new ServidorBo().Get(serverId).Item.Ip), string.Format("{0}.mp4", videoId));

                if (arquivo != null)
                {
                    resultInfo.Item.Arquivo = System.Convert.ToBase64String(arquivo);
                }                    
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo<Video> GetAll()
        {
            ResultInfo<Video> resultInfo = new();

            try
            {
                resultInfo.Items = Dao.GetAll();

                if (resultInfo.Items.Any()) 
                {
                    foreach (var video in resultInfo.Items) 
                    {
                        var arquivo = new Arquivo().Get(string.Format("\\{0}", new ServidorBo().Get(video.IdServer).Item.Ip), string.Format("{0}.mp4", video.Id));

                        if (arquivo != null) 
                        {
                            video.Arquivo = System.Convert.ToBase64String(arquivo);
                        }                        
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
            ResultInfo<Video> resultInfo = new();

            try
            {
                resultInfo.Items = Dao.GetVideoByServer(idServer);

                if (resultInfo.Items.Any())
                {
                    foreach (var video in resultInfo.Items)
                    {
                        var arquivo = new Arquivo().Get(string.Format("\\{0}", new ServidorBo().Get(video.IdServer).Item.Ip), string.Format("{0}.mp4", video.Id));

                        if (arquivo != null) 
                        {
                            video.Arquivo = System.Convert.ToBase64String(arquivo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo<Video> GetVideoByDate(DateTime date)
        {
            ResultInfo<Video> resultInfo = new();

            try 
            {
                resultInfo.Items = Dao.GetVideoByDate(date);
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
