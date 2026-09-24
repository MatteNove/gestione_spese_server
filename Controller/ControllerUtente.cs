using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using gestione_spese_server.Interfacce;
using gestione_spese_server.DTOs;

namespace gestione_spese_server.Controller
{
    [ApiController]
    [Route("gestione_spese_server/utente")]
    public class ControllerUtente : ControllerBase
    {
        private readonly IServiceUtente _iserviceUtente;

        public ControllerUtente(IServiceUtente serviceUtente)
        {
            _iserviceUtente = serviceUtente;
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<ResponseUtente>> GetById(int id)
        {
            ResponseUtente responseUtente = await _iserviceUtente.GetById(id);
            if (responseUtente == null)
            {
                return NotFound($"Utente con ID {id} non trovato.");
            }
            return Ok(responseUtente);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseUtente>> Create([FromBody] RequestUtente requesteUtente)
        {
            ResponseUtente responseUtente = await _iserviceUtente.Create(requesteUtente);
            if (responseUtente == null)
            {
                return BadRequest("Errore nella creazione dell'utente.");
            }
            return Ok(responseUtente);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ResponseUtente>> Update(int id, [FromBody] RequestUtente requesteUtente)
        {
            ResponseUtente responseUtente = await _iserviceUtente.Update(id, requesteUtente);
            if (responseUtente == null)
            {
                return NotFound($"Utente con ID {id} non trovato.");
            }
            return Ok(responseUtente);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool delete = await _iserviceUtente.Delete(id);
            if (delete == false)
            {
                return NotFound($"Utente con ID {id} non trovato.");
            }
            return Ok(delete);
        }
    }
}
