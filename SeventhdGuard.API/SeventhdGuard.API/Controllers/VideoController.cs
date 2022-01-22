using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.API.Interfaces;
using SeventhdGuard.BO;
using SeventhdGuard.COMMON;
using SeventhdGuard.ENTITY;
using System;

namespace SeventhdGuard.API.Controllers
{
    [Route("api/servers")]
    [ApiController]
    public class VideoController : ControllerBase, IVideoController
    {
        #region "Variables"

        private VideoBo _videoBo;

        #endregion

        #region "Properties"

        private VideoBo VideoBo
        {
            get { return _videoBo ?? (_videoBo = new VideoBo()); }
        }

        #endregion

        #region "Public Methods"

        #region "GET"

        [HttpGet("{serverId}/videos/{videoId}")]
        public ObjectResult Get(string serverId, string videoId)
        {
            var result = VideoBo.Get(serverId, videoId);

            if (result.Success)
            {
                return Ok(result.Item);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{serverId}/videos")]
        public ObjectResult GetVideoByServer(string serverId)
        {
            var result = VideoBo.GetVideoByServer(serverId);

            if (result.Success) 
            {
                return Ok(result.Items);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{serverId}/videos/{videoId}/binary")]
        public ObjectResult Binary(string serverId, string videoId)
        {
            var result = new Arquivo().Get(string.Format("\\{0}", new ServidorBo().Get(serverId).Item.Ip), string.Format("{0}.mp4", videoId));

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Arquivo não encontrado!");
        }

        #endregion

        #region "POST"

        [HttpPost("{serverId}/videos")]
        public ObjectResult Add([FromBody] Video entity, string serverId)
        {
            entity.Id          = Guid.NewGuid().ToString();
            entity.IdServer    = serverId;
            entity.SizeInBytes = System.Convert.FromBase64String(entity.Arquivo).Length;

            var result = VideoBo.Add(entity);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        #endregion

        #region "DELETE"

        [HttpDelete("{serverId}/videos/{videoId}")]
        public ObjectResult Delete(string serverId, string videoId)
        {
            var result = VideoBo.Delete(serverId, videoId);

            if (result.Success) 
            {
                return Ok(result);
            }                         

            return BadRequest(result.Message);
        }

        #endregion

        #endregion      
    }
}
