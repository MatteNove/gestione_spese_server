using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Interfacce;
using gestione_spese_server.Service;
using Microsoft.AspNetCore.Mvc;

namespace gestione_spese_server.Controller
{
    [ApiController]
    [Route("gestione_spese_server/tipo_spesa")]
    internal class ControllerTipoSpesa : ControllerBase
    {
        private readonly IServiceTipoSpesa _iserviceTipoSpesa;

        public ControllerTipoSpesa(IServiceTipoSpesa iserviceTipoSpesa)
        {
            this._iserviceTipoSpesa = iserviceTipoSpesa;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ResponseTipoSpesa>>> GetAll()
        {
            List<ResponseTipoSpesa> responseTipoSpesas = await _iserviceTipoSpesa.GetAll();
            if (responseTipoSpesas == null)
            {
                return NotFound();
            }
            return Ok(responseTipoSpesas);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<ResponseTipoSpesa>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("it must be a positive number");
            }

            ResponseTipoSpesa responseTipoSpesa = await _iserviceTipoSpesa.GetById(id);
            if (responseTipoSpesa == null)
            {
                return NotFound();
            }
            return Ok(responseTipoSpesa);

        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseTipoSpesa>> Create([FromBody] RequestTipoSpesa requestTipoSpesa)
        {
            ResponseTipoSpesa responseTipoSpesa = await _iserviceTipoSpesa.Create(requestTipoSpesa);
            if (responseTipoSpesa == null)
            {
                return BadRequest();
            }
            return Ok(responseTipoSpesa);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ResponseTipoSpesa>> Update(int id, [FromBody] RequestTipoSpesa requestTipoSpesa)
        {
            if (id <= 0)
            {
                return BadRequest("it must be a positive number");
            }
            ResponseTipoSpesa responseTipoSpesa = await _iserviceTipoSpesa.Update(id, requestTipoSpesa);
            if (responseTipoSpesa == null)
            {
                return NotFound();
            }
            return Ok(responseTipoSpesa);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be a positive number");
            }

            bool delete = await _iserviceTipoSpesa.Delete(id);
            if (delete == false)
            {
                return NotFound();
            }

            return Ok(delete);
        }
    }
}
