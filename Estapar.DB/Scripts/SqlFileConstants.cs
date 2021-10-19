using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.DB.Scripts
{
    public static class SqlFileConstants
    {
        #region Manobrista

        public static readonly string GET_MANOBRISTAS = "Scripts.SelectManobristas.sql";
        public static readonly string INSERT_MANOBRISTAS = "Scripts.InsertManobristas.sql";
        public static readonly string DELETE_MANOBRISTAS = "Scripts.DeleteManobristas.sql";
        public static readonly string GET_MANOBRISTA_BY_ID = "Scripts.SelectManobristasById.sql";
        public static readonly string UPDATE_MANOBRISTAS = "Scripts.UpdateManobristas.sql";

        #endregion

        #region Carros

        public static readonly string DELETE_CARROS = "Scripts.DeleteCarros.sql";
        public static readonly string INSERT_CARROS = "Scripts.InsertCarros.sql";
        public static readonly string GET_CARROS = "Scripts.SelectCarros.sql";
        public static readonly string GET_CARRO_BY_ID = "Scripts.SelectCarrosById.sql";
        public static readonly string UPDATE_CARROS = "Scripts.UpdateCarros.sql";

        #endregion

        #region Movimentacoes

        public static readonly string GET_MOVIMENTACOES = "Scripts.SelectMovimentacoes.sql";
        public static readonly string UPDATE_MOVIMENTACOES = "Scripts.UpdateMovimentacoes.sql";

        #endregion
    }
}
