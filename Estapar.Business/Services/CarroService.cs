using Estapar.Interfaces.Repositories;
using Estapar.Interfaces.Services;
using Estapar.Model.Entity;
using Estapar.Model.ViewModel;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.Business.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _CarroRepository;

        public CarroService(ICarroRepository CarroRepository)
        {
            _CarroRepository = CarroRepository;
        }

        public async Task<IEnumerable<CarroViewModel>> GetCarros()
        {
            var m = await _CarroRepository.GetCarros();
            var mappedList = new List<CarroViewModel>();
            m.ToList().ForEach(e => mappedList.Add(new CarroViewModel().PopulateWith(e)));
            return mappedList;
        }

        /// <summary>
        /// Insere carro na base de dados
        /// </summary>
        /// <param name="marca">Marca do carro</param>
        /// <param name="modelo">Modelo do carro</param>
        /// <param name="placa">Placa do carro</param>
        /// <returns></returns>
        public async Task InsertCarros(string marca, string modelo, string placa)
        {
            CarroModel m = new CarroModel { CRR_MARCA = marca, CRR_MODELO = modelo, CRR_PLACA = placa };
            await _CarroRepository.InsertCarros(m);
        }

        /// <summary>
        /// desativa o Carro na base
        /// </summary>
        /// <param name="id">Id do Carro</param>
        /// <returns></returns>
        public async Task DeleteCarros(string id) => await _CarroRepository.DeleteCarros(id);

        /// <summary>
        /// Busca Carro pelo seu id
        /// </summary>
        /// <returns>Id do Carro</returns>
        public async Task<CarroViewModel> GetCarroById(string id)
        {
            var m = await _CarroRepository.GetCarroById(id);
            var mappedEntity = new CarroViewModel().PopulateWith(m);
            return mappedEntity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marca">Marca do carro</param>
        /// <param name="modelo">Modelo do carro</param>
        /// <param name="placa">Placa do carro</param>
        /// <param name="id">Id do Carro a ser atualizado</param>
        /// <returns></returns>
        public async Task UpdatetCarros(string marca, string modelo, string placa, string id)
        {
            CarroModel m = new CarroModel { CRR_MARCA = marca, CRR_MODELO = modelo, CRR_PLACA = placa, CRR_ID = Convert.ToInt32(id) };
            await _CarroRepository.UpdatetCarros(m);
        }
    }
}
