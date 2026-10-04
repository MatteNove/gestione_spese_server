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
    [Route("gestione_spese_server/spesa")]
    internal class ControllerSpesa : ControllerBase
    {
        private readonly IServiceSpesa _iserviceSpesa;

        public ControllerSpesa(IServiceSpesa iserviceSpesa)
        {
            this._iserviceSpesa = iserviceSpesa;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ResponseSpesa>>> GetAll()
        {
            List<ResponseSpesa> responseSpesas = await _iserviceSpesa.GetAll();
            if (responseSpesas == null)
            {
                return NotFound();
            }
            return Ok(responseSpesas);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<ResponseSpesa>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("it must be a positive number");
            }

            ResponseSpesa responseSpesa = await _iserviceSpesa.GetById(id);
            if (responseSpesa == null)
            {
                return NotFound();
            }
            return Ok(responseSpesa);

        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseSpesa>> Create([FromBody] RequestSpesa requestSpesa)
        {
            ResponseSpesa responseSpesa = await _iserviceSpesa.Create(requestSpesa);
            if (responseSpesa == null)
            {
                return BadRequest();
            }
            return Ok(responseSpesa);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ResponseSpesa>> Update(int id, [FromBody] RequestSpesa requestSpesa)
        {
            if (id <= 0)
            {
                return BadRequest("it must be a positive number");
            }
            ResponseSpesa responseSpesa = await _iserviceSpesa.Update(id, requestSpesa);
            if (responseSpesa == null)
            {
                return NotFound();
            }
            return Ok(responseSpesa);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be a positive number");
            }

            bool delete = await _iserviceSpesa.Delete(id);
            if (delete == false)
            {
                return NotFound();
            }

            return Ok(delete);
        }


    }
}
