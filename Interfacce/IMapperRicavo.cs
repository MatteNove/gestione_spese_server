using System;
using System.Collections.Generic;
using System.Text;
using gestione_spese_server.DTOs;
using gestione_spese_server.Entity;

namespace gestione_spese_server.Interfacce
{
    internal interface IMapperRicavo
    {
        Ricavo toRicavo(RequestRicavo requestRicavo);

        ResponseRicavo toResponseRicavo(Ricavo ricavo);
    }
}
