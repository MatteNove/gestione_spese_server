using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;
using gestione_spese_server.Interfacce;

namespace gestione_spese_server.Mapper
{
    internal class MapperTipoSpesa : IMapperTipoSpesa
    {
        public TipoSpesa toTipoSpesa(RequestTipoSpesa requestTipoSpesa)
        {
            TipoSpesa tipoSpesa = new TipoSpesa();
            tipoSpesa.nome = requestTipoSpesa.nome;
            return tipoSpesa;
        }

        public ResponseTipoSpesa toResponseTipoSpesa(TipoSpesa tipoSpesa)
        {
            ResponseTipoSpesa responseTipoSpesa = new ResponseTipoSpesa();
            responseTipoSpesa.idTipoSpesa = tipoSpesa.idTipoSpesa;
            responseTipoSpesa.nome = tipoSpesa.nome;
            return responseTipoSpesa;
        }
    }
}
