using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.API.Interfaces;
using SeventhdGuard.BO;
using SeventhdGuard.ENTITY;
using System;

namespace SeventhdGuard.API.Controllers
{
    [Route("api/servers")]
    [ApiController]
    public partial class ServidorController : ControllerBase, IServidorController
    {
        #region "Variables"

        private ServidorBo? _servidorBo;

        #endregion

        #region "Properties"

        private ServidorBo ServidorBo
        {
            get { return _servidorBo ?? (_servidorBo = new ServidorBo()); }
        }

        #endregion

        #region "Public Methods"

        #region "GET"

        [HttpGet("Listar")]
        public StatusCodeResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public StatusCodeResult Get(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "POST"

        [HttpPost]
        public StatusCodeResult Add([FromBody] Servidor entity)
        {
            var result = ServidorBo.Add(entity);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        #endregion

        #region "DELETE"

        [HttpDelete("Remover")]
        public StatusCodeResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
