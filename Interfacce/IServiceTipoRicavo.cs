using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;

namespace gestione_spese_server.Interfacce
{
    internal interface IServiceTipoRicavo
    {
        public Task<List<ResponseTipoRicavo>> GetAll();

        public Task<ResponseTipoRicavo> GetById(int id);

        public Task<ResponseTipoRicavo> Create(RequestTipoRicavo requestTipoRicavo);

        public Task<ResponseTipoRicavo> Update(int id, RequestTipoRicavo requestTipoRicavo);

        public Task<bool> Delete(int id);

    }
}
