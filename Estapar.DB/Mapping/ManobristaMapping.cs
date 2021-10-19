using Dapper.FluentMap.Mapping;
using Estapar.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.DB.Mapping
{
    public class ManobristaMapping : EntityMap<ManobristaModel>
    {
        public ManobristaMapping()
        {
            Map(campo => campo.MNB_ID).ToColumn("MNB_ID");
            Map(campo => campo.MNB_NOME).ToColumn("MNB_NOME");
            Map(campo => campo.MNB_CPF).ToColumn("MNB_CPF");
            Map(campo => campo.MNB_NASCIMENTO).ToColumn("MNB_NASCIMENTO");
            Map(campo => campo.MNB_ATIVO).ToColumn("MNB_ATIVO");
        }
    }
}
