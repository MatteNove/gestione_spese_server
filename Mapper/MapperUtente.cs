using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.Entity;
using gestione_spese_server.DTOs;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Mapper
{
    internal class MapperUtente : IMapperUtente
    {
        public Utente toUtente(RequestUtente requestUtente)
        {
            if (requestUtente == null)
            {
                return null;
            }
            Utente utente = new Utente();
            utente.nome = requestUtente.nome;
            utente.cognome = requestUtente.cognome;
            utente.dataNascita = requestUtente.dataNascita;
            return utente;
        }

        public ResponseUtente toResponseUtente(Utente utente)
        {
            if (utente == null)
            {
                return null;
            }
            ResponseUtente responseUtente = new ResponseUtente();
            responseUtente.nome = utente.nome;
            responseUtente.cognome = utente.cognome;
            responseUtente.dataNascita = utente.dataNascita;
            return responseUtente;
        }
    }
}
