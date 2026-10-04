using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Service
{
    internal class ServiceTipoSpesa : IServiceTipoSpesa
    {
        private readonly DataContext _context;
        private readonly IMapperTipoSpesa _mapper;

        private ServiceTipoSpesa(DataContext context, IMapperTipoSpesa mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<ResponseTipoSpesa>> GetAll()
        {
            List<ResponseTipoSpesa> response = new List<ResponseTipoSpesa>();
            List<TipoSpesa> tipiSpesa = await _context.TipoSpesa.ToListAsync();
            foreach (TipoSpesa tipoSpesa in tipiSpesa)
            {
                response.Add(_mapper.toResponseTipoSpesa(tipoSpesa));
            }
            return response;
        }

        public async Task<ResponseTipoSpesa> GetById(int id)
        {
            TipoSpesa tipoSpesa = await _context.TipoSpesa.FindAsync(id);
            if (tipoSpesa == null)
            {
                return null;
            }
            return _mapper.toResponseTipoSpesa(tipoSpesa);
        }

        public async Task<ResponseTipoSpesa> Create(RequestTipoSpesa requestTipoSpesa)
        {
            TipoSpesa tipoSpesa = _mapper.toTipoSpesa(requestTipoSpesa);
            _context.Add(tipoSpesa);
            await _context.SaveChangesAsync();
            return _mapper.toResponseTipoSpesa(tipoSpesa);
        }

        public async Task<ResponseTipoSpesa> Update(int id, RequestTipoSpesa requestTipoSpesa)
        {
            TipoSpesa tipoSpesa = await _context.TipoSpesa.FindAsync(id);
            if (tipoSpesa == null)
            {
                return null;
            }
            tipoSpesa.nome = requestTipoSpesa.nome;
            await _context.SaveChangesAsync();
            return _mapper.toResponseTipoSpesa(tipoSpesa);
        }

        public async Task<bool> Delete(int id)
        {
            TipoSpesa tipoSpesa = await _context.TipoSpesa.FindAsync(id);
            if (tipoSpesa == null)
            {
                return false;
            }
            _context.Remove(tipoSpesa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
