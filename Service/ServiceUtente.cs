using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Mapper;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Service
{
    internal class ServiceUtente : IServiceUtente
    {
        private readonly DataContext _context;
        private readonly MapperUtente _mapper;

        
        public ServiceUtente(DataContext context, MapperUtente mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseUtente> Utente_GetById(int id)
        {
            Utente utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return null;
            }
            return _mapper.toResponseUtente(utente);

        }
    }
}
