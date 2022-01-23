using SeventhdGuard.BO.Base;
using SeventhdGuard.BO.Interfaces;
using SeventhdGuard.COMMON;
using SeventhdGuard.DAO;
using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SeventhdGuard.BO
{
    public class ReciclarBo : BaseBo<Reciclar, ReciclarDao>, IReciclarBo
    {
        #region "Public Methods"

        public async void RecyclerVideo(Reciclar entity, int days)
        {
            await Process(entity, days);
        }

        public Task Process(Reciclar entity, int days)
        {
            if (string.IsNullOrEmpty(Verify().Item.Id))
            {
                var resultBegin = BeginProcess(entity);

                if (resultBegin.Success)
                {
                    var resultVideo = new VideoBo().GetVideoByDate(DateTime.Now.AddDays(-days));

                    if (resultVideo.Items.Any())
                    {
                        foreach (var video in resultVideo.Items)
                        {
                            new Arquivo().Delete(string.Format("\\{0}", new ServidorBo().Get(video.IdServer).Item.Ip), string.Format("{0}.mp4", video.Id));
                            new VideoBo().Delete(video.IdServer, video.Id);
                        }
                    }

                    EndProcess(entity.Id, DateTime.Now);
                }
            }

            return null;
        }

        public ResultInfo<Reciclar> Verify()
        {
            ResultInfo<Reciclar> resultInfo = new();

            try
            {
                resultInfo.Item = Dao.Verify();
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo BeginProcess(Reciclar entity)
        {
            ResultInfo resultInfo = new();

            try
            {
                resultInfo.RowsAffected = Dao.BeginProcess(entity);

                if (resultInfo.RowsAffected <= 0)
                {
                    throw new Exception("Erro ao iniciar!");
                }
            }
            catch (Exception ex)
            {
                resultInfo.ExceptionMapper(ex);
            }

            return resultInfo;
        }

        public ResultInfo EndProcess(string id, DateTime dataFinished)
        {
            ResultInfo resultInfo = new();

            try
            {
                resultInfo.RowsAffected = Dao.EndProcess(id, dataFinished);

                if (resultInfo.RowsAffected <= 0)
                {
                    throw new Exception("Erro ao encerrar!");
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
