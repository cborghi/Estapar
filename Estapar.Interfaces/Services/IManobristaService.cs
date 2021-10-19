using Estapar.Model.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estapar.Interfaces.Services
{
    public interface IManobristaService
    {
        /// <summary>
        /// Busca todos manobristas cadastrados
        /// </summary>
        /// <returns>Lista com manobristas</returns>
        Task<IEnumerable<ManobristaViewModel>>GetManobristas();

        /// <summary>
        /// Insere manobrista na base de dados
        /// </summary>
        /// <param name="nome">Nome do manobrista</param>
        /// <param name="cpf">Cpf do manobrista</param>
        /// <param name="nasc">Data de Nascimento do manobrista</param>
        /// <returns></returns>
        Task InsertManobristas(string nome, string cpf, string nasc);
        
        /// <summary>
        /// desativa o manobrista na base
        /// </summary>
        /// <param name="id">Id do Manobrista</param>
        /// <returns></returns>
        Task DeleteManobristas(string id);

        /// <summary>
        /// Busca manobrista pelo seu id
        /// </summary>
        /// <returns>Id do manobrista</returns>
        Task<ManobristaViewModel> GetManobristaById(string id);        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome">Nome do manobrista</param>
        /// <param name="cpf">Cpf do manobrista</param>
        /// <param name="nasc">Data de Nascimento do manobrista</param>
        /// <param name="id">Id do manobrista a ser atualizado</param>
        /// <returns></returns>
        Task UpdatetManobristas(string nome, string cpf, string nasc, string id);
    }
}
