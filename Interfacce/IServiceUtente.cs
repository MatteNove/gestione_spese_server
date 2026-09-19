using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using gestione_spese_server.DTOs;

namespace gestione_spese_server.Interfacce
{
    internal interface IServiceUtente
    {
        //Task<List<ResponseUtente>> Utenti_GetAll();
        Task<ResponseUtente> Utente_GetById(int id);
    }
}
