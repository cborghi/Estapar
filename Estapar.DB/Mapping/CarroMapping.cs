using Dapper.FluentMap.Mapping;
using Estapar.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.DB.Mapping
{
    class CarroMapping : EntityMap<CarroModel>
    {
        public CarroMapping()
        {
            Map(campo => campo.CRR_ID).ToColumn("CRR_ID");
            Map(campo => campo.CRR_MARCA).ToColumn("CRR_MARCA");
            Map(campo => campo.CRR_MODELO).ToColumn("CRR_MODELO");
            Map(campo => campo.CRR_PLACA).ToColumn("CRR_PLACA");
            Map(campo => campo.CRR_ATIVO).ToColumn("CRR_ATIVO");
        }
    }
}