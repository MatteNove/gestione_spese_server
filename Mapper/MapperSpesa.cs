using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Mapper
{
    internal class MapperSpesa : IMapperSpesa
    {
        public Spesa toSpesa(RequestSpesa requestSpesa)
        {
            if (requestSpesa == null)
            {
                return null;
            }

            Spesa spesa = new Spesa();
            spesa.importo = requestSpesa.importo;
            spesa.descrizione = requestSpesa.descrizione;
            spesa.dataSpesa = requestSpesa.dataSpesa;
            spesa.idUtente = requestSpesa.UtenteId;
            spesa.idTipoSpesa = requestSpesa.idTipoSpesa;
            return spesa;

        }

        public ResponseSpesa toResponseSpesa(Spesa spesa)
        {
            if (spesa == null)
            {
                return null;
            }
            ResponseSpesa responseSpesa = new ResponseSpesa();
            responseSpesa.idSpesa = spesa.idSpesa;
            responseSpesa.importo = spesa.importo;
            responseSpesa.descrizione = spesa.descrizione;
            responseSpesa.dataSpesa = spesa.dataSpesa;
            responseSpesa.idUtente = spesa.idUtente;
            responseSpesa.idTipoSpesa = spesa.idTipoSpesa;
            return responseSpesa;
        }
    }
}
