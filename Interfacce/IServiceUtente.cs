using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using gestione_spese_server.DTOs;

namespace gestione_spese_server.Interfacce
{
    public interface IServiceUtente
    {
        Task<ResponseUtente?> GetById(int id);

        Task<ResponseUtente> Create(RequestUtente requestUtente);

        Task<ResponseUtente?> Update(int id, RequestUtente requestUtente);

        Task<bool> Delete(int id);
    }
}
