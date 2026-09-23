using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using gestione_spese_server.DTOs;

namespace gestione_spese_server.Interfacce
{
    public interface IServiceUtente
    {
        Task<ResponseUtente> Utente_GetById(int id);
    }
}
