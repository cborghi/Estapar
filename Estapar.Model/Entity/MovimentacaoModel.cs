using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.Model.Entity
{
    public class MovimentacaoModel
    {
        public long MVM_ID { get; set; }
        public int? MNB_ID_ENTRADA { get; set; }
        public DateTime? MVM_DATA_ENTRADA { get; set; }
        public DateTime? MVM_DATA_ENTREGA { get; set; }
        public int? CRR_ID { get; set; }
        public string CRR_PLACA { get; set; }
        public int? MNB_ID_SAIDA { get; set; }
        public string MNB_NOME_ENTRADA { get; set; }
        public string MNB_NOME_SAIDA { get; set; }
    }
}
