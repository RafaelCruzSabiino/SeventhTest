using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.API.Interfaces;
using SeventhdGuard.BO;
using SeventhdGuard.ENTITY;

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

        #endregion

        #region "POST"

        [HttpPost("{serverId}/videos")]
        public ObjectResult Add([FromBody] Video entity, string serverId)
        {
            entity.IdServer = serverId;
            var result      = VideoBo.Add(entity);

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
