using Microsoft.AspNetCore.Mvc;
using SeventhTest.API.Interfaces;
using SeventhTest.BO;
using SeventhTest.ENTITY;

namespace SeventhTest.API.Controllers
{
    [Route("api/server")]
    [ApiController]
    public class ServidorController : ControllerBase, IBaseController<Servidor>
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

        #region "GET"

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

        [HttpDelete("Remover")]
        public StatusCodeResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("Listar")]
        public StatusCodeResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("Recuperar")]
        public StatusCodeResult Get(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
