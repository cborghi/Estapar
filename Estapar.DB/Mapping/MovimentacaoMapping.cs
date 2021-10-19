using Dapper.FluentMap.Mapping;
using Estapar.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.DB.Mapping
{
    public class MovimentacaoMapping : EntityMap<MovimentacaoModel>
    {
        public MovimentacaoMapping()
        {
            Map(campo => campo.MVM_ID).ToColumn("MVM_ID");
            Map(campo => campo.MNB_ID_ENTRADA).ToColumn("MNB_ID_ENTRADA");
            Map(campo => campo.MVM_DATA_ENTRADA).ToColumn("MVM_DATA_ENTRADA");
            Map(campo => campo.MVM_DATA_ENTREGA).ToColumn("MVM_DATA_ENTREGA");
            Map(campo => campo.CRR_ID).ToColumn("CRR_ID");
            Map(campo => campo.CRR_PLACA).ToColumn("CRR_PLACA");
            Map(campo => campo.MNB_ID_SAIDA).ToColumn("MNB_ID_SAIDA");
            Map(campo => campo.MNB_NOME_ENTRADA).ToColumn("MNB_NOME_ENTRADA");
            Map(campo => campo.MNB_NOME_SAIDA).ToColumn("MNB_NOME_SAIDA");
        }
    }
}