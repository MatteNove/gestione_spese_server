using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;

namespace gestione_spese_server.Interfacce
{
    internal interface IServiceSpesa
    {
        Task<List<ResponseSpesa>> GetAll();

        Task<ResponseSpesa> GetById(int id);

        Task<ResponseSpesa> Create(RequestSpesa requestSpesa);

        Task<ResponseSpesa> Update(int id, RequestSpesa requestSpesa);

        Task<bool> Delete(int id);
    }
}
