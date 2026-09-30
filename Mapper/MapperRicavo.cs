using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Mapper
{
    internal class MapperRicavo : IMapperRicavo
    {
        public Ricavo toRicavo(RequestRicavo requestRicavo)
        {
            if(requestRicavo == null)
            {
                return null;
            }

            Ricavo ricavo = new Ricavo();
            ricavo.importo = requestRicavo.importo;
            ricavo.descrizione = requestRicavo.descrizione;
            ricavo.dataRicavo = requestRicavo.dataRicavo;
            ricavo.idUtente = requestRicavo.UtenteId;
            ricavo.idTipoRicavo = requestRicavo.idTipoRicavo;
            return ricavo;

        }

        public ResponseRicavo toResponseRicavo(Ricavo ricavo)
        {
            if(ricavo == null)
            {
                return null;
            }
            ResponseRicavo responseRicavo = new ResponseRicavo();
            responseRicavo.idRicavo = ricavo.idRicavo; 
            responseRicavo.importo = ricavo.importo;
            responseRicavo.descrizione = ricavo.descrizione;
            responseRicavo.dataRicavo = ricavo.dataRicavo;
            responseRicavo.idUtente = ricavo.idUtente;
            responseRicavo.idTipoRicavo = ricavo.idTipoRicavo;
            return responseRicavo;
        }
    }
}
