using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;

namespace gestione_spese_server.Interfacce
{
    internal interface IServiceRicavo
    {
        Task<List<ResponseRicavo>> GetAll();

        Task<ResponseRicavo> GetById(int id);

        Task<ResponseRicavo> Create(RequestRicavo requestRicavo);

        Task<ResponseRicavo> Update(int id, RequestRicavo requestRicavo);

        Task<bool> Delete(int id);
    }
}
