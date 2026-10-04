using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;

namespace gestione_spese_server.Interfacce
{
    internal interface IServiceTipoSpesa
    {
        public Task<List<ResponseTipoSpesa>> GetAll();

        public Task<ResponseTipoSpesa> GetById(int id);

        public Task<ResponseTipoSpesa> Create(RequestTipoSpesa requestTipoSpesa);

        public Task<ResponseTipoSpesa> Update(int id, RequestTipoSpesa requestTipoSpesa);

        public Task<bool> Delete(int id);
    }
}
