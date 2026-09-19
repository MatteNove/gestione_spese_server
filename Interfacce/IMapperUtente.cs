using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;

namespace gestione_spese_server.Interfacce
{
    internal interface IMapperUtente
    {
        Utente toUtente(RequestUtente requestUtente);
        ResponseUtente toResponseUtente(Utente utente);
    }
}
