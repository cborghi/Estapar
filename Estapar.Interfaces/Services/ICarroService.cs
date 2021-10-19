using Estapar.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.Interfaces.Services
{
    public interface ICarroService
    {
        /// <summary>
        /// Busca todos carros cadastrados
        /// </summary>
        /// <returns>Lista com carros</returns>
        Task<IEnumerable<CarroViewModel>> GetCarros();

        /// <summary>
        /// Insere carro na base de dados
        /// </summary>
        /// <param name="marca">Marca do carro</param>
        /// <param name="modelo">Modelo do carro</param>
        /// <param name="placa">Placa do carro</param>
        /// <returns></returns>
        Task InsertCarros(string marca, string modelo, string placa);

        /// <summary>
        /// desativa o carro na base
        /// </summary>
        /// <param name="id">Id do carro</param>
        /// <returns></returns>
        Task DeleteCarros(string id);

        /// <summary>
        /// Busca carros pelo seu id
        /// </summary>
        /// <returns>Id do carro</returns>
        Task<CarroViewModel> GetCarroById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marca">Marca do carro</param>
        /// <param name="modelo">Modelo do carro</param>
        /// <param name="placa">Placa do carro</param>
        /// <param name="id">Id do carro a ser atualizado</param>
        /// <returns></returns>
        Task UpdatetCarros(string marca, string modelo, string placa, string id);
    }
}
