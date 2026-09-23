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
            ResponseUtente responseUtente = await _iserviceUtente.Utente_GetById(id);
            if (responseUtente == null)
            {
                return NotFound($"Utente con ID {id} non trovato.");
            }
            return Ok(responseUtente);
        }
    }
}
