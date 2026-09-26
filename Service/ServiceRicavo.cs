using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace gestione_spese_server.Service
{
    internal class ServiceRicavo : IServiceRicavo
    {
        private readonly DataContext _context;
        private readonly IMapperRicavo _mapper;

        private ServiceRicavo(DataContext _context, IMapperRicavo mapperRicavo)
        {
            this._context = _context;
            this._mapper = mapperRicavo;
        }

        public async Task<List<ResponseRicavo>> GetAll()
        {
            List<Ricavo> ricavi = await _context.Ricavo.ToListAsync();
            List<ResponseRicavo> responseRicavi = new List<ResponseRicavo>();
            foreach (Ricavo ricavo in ricavi)
            {
                responseRicavi.Add(_mapper.toResponseRicavo(ricavo));
            }
            return responseRicavi;
        }

        public async Task<ResponseRicavo> GetById(int id)
        {
            Ricavo ricavo = await _context.Ricavo.FindAsync(id);

            if (ricavo == null)
            {
                return null;
            }

            ResponseRicavo responseRicavo = _mapper.toResponseRicavo(ricavo);
            return responseRicavo;
        }

        public async Task<ResponseRicavo> Create(RequestRicavo requestRicavo)
        {
            Ricavo ricavo = _mapper.toRicavo(requestRicavo);
            _context.Add(ricavo);
            await _context.SaveChangesAsync();
            ResponseRicavo responseRicavo = _mapper.toResponseRicavo(ricavo);
            return responseRicavo;
        }

        public async Task<ResponseRicavo> Update(int id, RequestRicavo requestRicavo)
        {
            Ricavo ricavo = await _context.Ricavo.FindAsync(id);
            if (ricavo == null)
            {
                return null;
            }
            ricavo.descrizione = requestRicavo.descrizione;
            ricavo.importo = requestRicavo.importo;
            ricavo.dataRicavo = requestRicavo.dataRicavo;
            await _context.SaveChangesAsync();
            ResponseRicavo responseRicavo = _mapper.toResponseRicavo(ricavo);
            return responseRicavo;
        }

        public async Task<bool> Delete(int id)
        {
            Ricavo ricavo = await _context.Ricavo.FindAsync(id);
            if (ricavo == null)
            {
                return false;
            }
            _context.Ricavo.Remove(ricavo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}