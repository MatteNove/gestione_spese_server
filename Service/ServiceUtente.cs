using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Mapper;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Service
{
    public class ServiceUtente : IServiceUtente
    {
        private readonly DataContext _context;
        private readonly IMapperUtente _mapper;

        private ServiceUtente(DataContext context, IMapperUtente mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseUtente> GetById(int id)
        {
            Utente utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return null;
            }
            return _mapper.toResponseUtente(utente);

        }

        public async Task<ResponseUtente> Create(RequestUtente requestUtente)
        {
            Utente utente = _mapper.toUtente(requestUtente);
            _context.Utente.Add(utente);
            await _context.SaveChangesAsync();
            ResponseUtente responseUtente = _mapper.toResponseUtente(utente);
            return responseUtente;

        }

        public async Task<ResponseUtente> Update(int id, RequestUtente requestUtente)
        {
            Utente utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return null;
            }
            utente.nome = requestUtente.nome;
            utente.cognome = requestUtente.cognome;
            utente.dataNascita = requestUtente.dataNascita;
            await _context.SaveChangesAsync();
            ResponseUtente responseUtente = _mapper.toResponseUtente(utente);
            return responseUtente;
        }

        public async Task<bool> Delete(int id)
        {
            Utente utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return false;
            }
            _context.Utente.Remove(utente);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
