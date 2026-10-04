using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;
using Microsoft.EntityFrameworkCore;

namespace gestione_spese_server.Service
{
    internal class ServiceSpesa : IServiceSpesa
    {
        private readonly DataContext _context;
        private readonly IMapperSpesa _mapper;

        private ServiceSpesa(DataContext _context, IMapperSpesa mapperSpesa)
        {
            this._context = _context;
            this._mapper = mapperSpesa;
        }

        public async Task<List<ResponseSpesa>> GetAll()
        {
            List<Spesa> spese = await _context.Spesa.ToListAsync();
            List<ResponseSpesa> responseSpese = new List<ResponseSpesa>();
            foreach (Spesa spesa in spese)
            {
                responseSpese.Add(_mapper.toResponseSpesa(spesa));
            }
            return responseSpese;
        }

        public async Task<ResponseSpesa> GetById(int id)
        {
            Spesa spesa = await _context.Spesa.FindAsync(id);

            if (spesa == null)
            {
                return null;
            }

            ResponseSpesa responseSpesa = _mapper.toResponseSpesa(spesa);
            return responseSpesa;
        }

        public async Task<ResponseSpesa> Create(RequestSpesa requestSpesa)
        {
            Spesa spesa = _mapper.toSpesa(requestSpesa);
            _context.Add(spesa);
            await _context.SaveChangesAsync();
            ResponseSpesa responseSpesa = _mapper.toResponseSpesa(spesa);
            return responseSpesa;
        }

        public async Task<ResponseSpesa> Update(int id, RequestSpesa requestSpesa)
        {
            Spesa spesa = await _context.Spesa.FindAsync(id);
            if (spesa == null)
            {
                return null;
            }
            spesa.descrizione = requestSpesa.descrizione;
            spesa.importo = requestSpesa.importo;
            spesa.dataSpesa = requestSpesa.dataSpesa;
            spesa.idTipoSpesa = requestSpesa.idTipoSpesa;
            await _context.SaveChangesAsync();
            ResponseSpesa responseSpesa = _mapper.toResponseSpesa(spesa);
            return responseSpesa;
        }

        public async Task<bool> Delete(int id)
        {
            Spesa spesa = await _context.Spesa.FindAsync(id);
            if (spesa == null)
            {
                return false;
            }
            _context.Spesa.Remove(spesa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
