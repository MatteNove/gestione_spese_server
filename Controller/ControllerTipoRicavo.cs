using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Interfacce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestione_spese_server.Controller
{
    [ApiController]
    [Route("gestione_spese_server/tipo_ricavo")]
    internal class ControllerTipoRicavo : ControllerBase
    {
        
    
            private readonly IServiceTipoRicavo _iserviceTipoRicavo;

            public ControllerTipoRicavo(IServiceTipoRicavo iserviceTipoRicavo)
            {
                this._iserviceTipoRicavo = iserviceTipoRicavo;
            }

            [HttpGet("getAll")]
            public async Task<ActionResult<List<ResponseTipoRicavo>>> GetAll()
            {
                List<ResponseTipoRicavo> responseTipoRicavos = await _iserviceTipoRicavo.GetAll();
                if (responseTipoRicavos == null)
                {
                    return NotFound();
                }
                return Ok(responseTipoRicavos);
            }

            [HttpGet("getById/{id}")]
            public async Task<ActionResult<ResponseTipoRicavo>> GetById(int id)
            {
                if (id <= 0)
                {
                    return BadRequest("it must be a positive number");
                }

                ResponseTipoRicavo responseTipoRicavo = await _iserviceTipoRicavo.GetById(id);
                if (responseTipoRicavo == null)
                {
                    return NotFound();
                }
                return Ok(responseTipoRicavo);

            }

            [HttpPost("create")]
            public async Task<ActionResult<ResponseTipoRicavo>> Create([FromBody] RequestTipoRicavo requestTipoRicavo)
            {
                ResponseTipoRicavo responseTipoRicavo = await _iserviceTipoRicavo.Create(requestTipoRicavo);
                if (responseTipoRicavo == null)
                {
                    return BadRequest();
                }
                return Ok(responseTipoRicavo);
            }

            [HttpPut("update/{id}")]
            public async Task<ActionResult<ResponseTipoRicavo>> Update(int id, [FromBody] RequestTipoRicavo requestTipoRicavo)
            {
                if (id <= 0)
                {
                    return BadRequest("it must be a positive number");
                }
                ResponseTipoRicavo responseTipoRicavo = await _iserviceTipoRicavo.Update(id, requestTipoRicavo);
                if (responseTipoRicavo == null)
                {
                    return NotFound();
                }
                return Ok(responseTipoRicavo);
            }

            [HttpDelete("delete/{id}")]
            public async Task<ActionResult<bool>> Delete(int id)
            {
                if (id <= 0)
                {
                    return BadRequest("Id must be a positive number");
                }

                bool delete = await _iserviceTipoRicavo.Delete(id);
                if (delete == false)
                {
                    return NotFound();
                }

                return Ok(delete);
            }
        }
}
