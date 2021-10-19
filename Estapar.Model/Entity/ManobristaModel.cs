using System;

namespace Estapar.Model.Entity
{
    public class ManobristaModel
    {
        /// <summary>
        /// Id unico do manobrista
        /// </summary>
        public int MNB_ID { get; set; }
        /// <summary>
        /// Nome do manobrista
        /// </summary>
        public string MNB_NOME { get; set; }
        /// <summary>
        /// Cpf do manobrista
        /// </summary>
        public string MNB_CPF { get; set; }
        /// <summary>
        /// Data de nascimento do manobrista
        /// </summary>
        public DateTime MNB_NASCIMENTO { get; set; }
        /// <summary>
        /// Determina se manobrista deve ser exibido ou não
        /// </summary>
        public bool MNB_ATIVO { get; set; }
    }
}
