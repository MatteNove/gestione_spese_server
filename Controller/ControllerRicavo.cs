using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Interfacce;
using Microsoft.AspNetCore.Mvc;

namespace gestione_spese_server.Controller
{
    [ApiController]
    [Route("gestione_spese_server/ricavo")]
    internal class ControllerRicavo : ControllerBase
    {
        private readonly IServiceRicavo _iserviceRicavo;

        public ControllerRicavo(IServiceRicavo iserviceRicavo)
        {
            this._iserviceRicavo = iserviceRicavo;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ResponseRicavo>>> GetAll()
        {
            List<ResponseRicavo> responseRicavos = await _iserviceRicavo.GetAll();
            if (responseRicavos == null)
            {
                return NotFound();
            }
            return Ok(responseRicavos);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<ResponseRicavo>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("it must be a positive number");
            }
            
            ResponseRicavo responseRicavo = await _iserviceRicavo.GetById(id);
            if(responseRicavo == null)
               {
                  return NotFound();
               }
            return Ok(responseRicavo);
            
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseRicavo>> Create([FromBody] RequestRicavo requestRicavo) {
           ResponseRicavo responseRicavo = await _iserviceRicavo.Create(requestRicavo);
              if(responseRicavo == null)
                {
                    return BadRequest();
                }
           return Ok(responseRicavo);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ResponseRicavo>> Update(int id, [FromBody] RequestRicavo requestRicavo)
        {
            if (id <=0)
            {
                return BadRequest("it must be a positive number");
            }
            ResponseRicavo responseRicavo = await _iserviceRicavo.Update(id, requestRicavo);
            if (responseRicavo == null)
            {
                return NotFound();
            }
            return Ok(responseRicavo);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id <= 0 )
            {
                return BadRequest("Id must be a positive number");
            }

            bool delete = await _iserviceRicavo.Delete(id);
            if (delete == false)
            {
                return NotFound();
            }
            
            return Ok(delete);
        }
    }
}
