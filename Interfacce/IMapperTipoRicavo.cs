using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;

namespace gestione_spese_server.Interfacce
{
    internal interface IMapperTipoRicavo
    {
        TipoRicavo toTipoRicavo(RequestTipoRicavo requestTipoRicavo);
        ResponseTipoRicavo toResponseTipoRicavo(TipoRicavo tipoRicavo);

    }
}
