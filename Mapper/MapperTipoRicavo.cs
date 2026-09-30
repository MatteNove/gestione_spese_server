using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Mapper
{
    internal class MapperTipoRicavo : IMapperTipoRicavo
    {
        public TipoRicavo toTipoRicavo(RequestTipoRicavo requestTipoRicavo)
        {
            TipoRicavo tipoRicavo = new TipoRicavo();
            tipoRicavo.nome = requestTipoRicavo.nome;
            return tipoRicavo;
        }

        public ResponseTipoRicavo toResponseTipoRicavo(TipoRicavo tipoRicavo)
        {
            ResponseTipoRicavo responseTipoRicavo = new ResponseTipoRicavo();
            responseTipoRicavo.idTipoRicavo = tipoRicavo.idTipoRicavo;
            responseTipoRicavo.nome = tipoRicavo.nome;
            return responseTipoRicavo;
        }
    }
}
