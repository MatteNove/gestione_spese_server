using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Service
{
    internal class ServiceTipoRicavo : IServiceTipoRicavo
    {
        private readonly DataContext _context;
        private readonly IMapperTipoRicavo _mapper;

        private ServiceTipoRicavo(DataContext context, IMapperTipoRicavo mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<ResponseTipoRicavo>> GetAll()
        {
            List<ResponseTipoRicavo> response = new List<ResponseTipoRicavo>();
            List<TipoRicavo> tipiRicavo = await _context.TipoRicavo.ToListAsync();
            foreach (TipoRicavo tipoRicavo in tipiRicavo)
            {
                response.Add(_mapper.toResponseTipoRicavo(tipoRicavo));
            }
            return response;
        }

        public async Task<ResponseTipoRicavo> GetById(int id)
        {
            TipoRicavo tipoRicavo = await _context.TipoRicavo.FindAsync(id);
            if (tipoRicavo == null)
            {
                return null;
            }
            return _mapper.toResponseTipoRicavo(tipoRicavo);
        }

        public async Task<ResponseTipoRicavo> Create(RequestTipoRicavo requestTipoRicavo)
        {
            TipoRicavo tipoRicavo = _mapper.toTipoRicavo(requestTipoRicavo);
            _context.Add(tipoRicavo);
            await _context.SaveChangesAsync();
            return _mapper.toResponseTipoRicavo(tipoRicavo);
        }

        public async Task<ResponseTipoRicavo> Update(int id, RequestTipoRicavo requestTipoRicavo)
        {
            TipoRicavo tipoRicavo = await _context.TipoRicavo.FindAsync(id);
            if (tipoRicavo == null)
            {
                return null;
            }
            tipoRicavo.nome = requestTipoRicavo.nome;
            await _context.SaveChangesAsync();
            return _mapper.toResponseTipoRicavo(tipoRicavo);
        }

        public async Task<bool> Delete(int id)
        {
            TipoRicavo tipoRicavo = await _context.TipoRicavo.FindAsync(id);
            if (tipoRicavo == null)
            {
                return false;
            }
            _context.Remove(tipoRicavo);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
