using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.API.Interfaces;
using SeventhdGuard.BO;
using SeventhdGuard.ENTITY;
using System;
using System.Threading.Tasks;

namespace SeventhdGuard.API.Controllers
{
    [Route("api/recycler")]
    [ApiController]
    public class ReciclarController : ControllerBase, IReciclarController
    {
        #region "Variables"

        private ReciclarBo _reciclarBo;

        #endregion

        #region "Properties"

        private ReciclarBo ReciclarBo
        {
            get { return _reciclarBo ?? (_reciclarBo = new ReciclarBo()); }
        }

        #endregion

        #region "Public Methods"

        #region "GET"        

        [HttpGet("status")]
        public ObjectResult Verify()
        {
            var result         = ReciclarBo.Verify();
            result.Item.Status = string.IsNullOrEmpty(result.Item.Id) ? "not running" : "running";

            return Ok(result.Item);
        }

        #endregion

        #region "DELETE"

        [HttpDelete("process/{days}")]
        public StatusCodeResult RecyclerVideo(int days)
        {
            ReciclarBo.RecyclerVideo(new Reciclar() { Id = Guid.NewGuid().ToString(), Type = "Video" }, days);

            return StatusCode(202);
        }

        #endregion

        #endregion
    }
}
