using Estapar.Interfaces.Repositories;
using Estapar.Interfaces.Services;
using Estapar.Model.Entity;
using Estapar.Model.ViewModel;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estapar.Business.Services
{
    public class ManobristaService : IManobristaService
    {
        private readonly IManobristaRepository _manobristaRepository;

        public ManobristaService(IManobristaRepository manobristaRepository)
        {
            _manobristaRepository = manobristaRepository;
        }

        public async Task<IEnumerable<ManobristaViewModel>> GetManobristas()
        {
            var m = await _manobristaRepository.GetManobristas();
            var mappedList = new List<ManobristaViewModel>();
            m.ToList().ForEach(e => mappedList.Add(new ManobristaViewModel().PopulateWith(e)));
            return mappedList;
        }

        /// <summary>
        /// Insere manobrista na base de dados
        /// </summary>
        /// <param name="nome">Nome do manobrista</param>
        /// <param name="cpf">Cpf do manobrista</param>
        /// <param name="nasc">Data de Nascimento do manobrista</param>
        /// <returns></returns>
        public async Task InsertManobristas(string nome, string cpf, string nasc)
        {
            ManobristaModel m = new ManobristaModel { MNB_NOME = nome, MNB_CPF = cpf, MNB_NASCIMENTO = Convert.ToDateTime(nasc) };
            await _manobristaRepository.InsertManobristas(m);
        }

        /// <summary>
        /// desativa o manobrista na base
        /// </summary>
        /// <param name="id">Id do Manobrista</param>
        /// <returns></returns>
        public async Task DeleteManobristas(string id) => await _manobristaRepository.DeleteManobristas(id);

        /// <summary>
        /// Busca manobrista pelo seu id
        /// </summary>
        /// <returns>Id do manobrista</returns>
        public async Task<ManobristaViewModel> GetManobristaById(string id)
        {
            var m = await _manobristaRepository.GetManobristaById(id);
            var mappedEntity = new ManobristaViewModel().PopulateWith(m);
            return mappedEntity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome">Nome do manobrista</param>
        /// <param name="cpf">Cpf do manobrista</param>
        /// <param name="nasc">Data de Nascimento do manobrista</param>
        /// <param name="id">Id do manobrista a ser atualizado</param>
        /// <returns></returns>
        public async Task UpdatetManobristas(string nome, string cpf, string nasc, string id)
        {
            ManobristaModel m = new ManobristaModel { MNB_NOME = nome, MNB_CPF = cpf, MNB_NASCIMENTO = Convert.ToDateTime(nasc), MNB_ID = Convert.ToInt32(id) };
            await _manobristaRepository.UpdatetManobristas(m);
        }
    }
}
