using AutoMapper;
using CongratulationAPI.Contracts.Congratulation;
using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using CongratulationAPI.Infrastructure.Repositoryes.CongratulationRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongratulationAPI.AppServices.Services
{
    /// <summary>
    /// Сервис по работе с Днём рождения
    /// <inheritdoc />
    /// </summary>
    public class CongratulationService : ICongratulationService
    {
        private readonly IRepository<Congratulation> _repository;
        private readonly ICongratulationRepository _congratulationRepository;
        private readonly IMapper _mapper;

        public CongratulationService(IRepository<Congratulation> repository, IMapper mapper, ICongratulationRepository congratulationRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _congratulationRepository = congratulationRepository;
        }

        /// <inheritdoc />
        public Task AddAsync(CongratulationDtoAdd model)
        {
            var congratulation = _mapper.Map<Congratulation>(model);
            congratulation.CreationDate = DateTime.UtcNow;
            return _repository.AddAsync(congratulation);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id)
        {
            var congratulation = await _repository.GetByIdAsync(id);
            if(congratulation == null)
            {
                throw new Exception($"Не найден День рождения с id: {id}");
            }
            await _repository.DeleteAsync(congratulation);
        }

        /// <inheritdoc />
        public async Task<List<CongratulationDto>> GetAllCongratulations()
        {
            var result = await _congratulationRepository.GetAllCongratulationsWithUsersFromUsersAndBirthDays();
            if(result.Count > 0)
            {
                return _mapper.Map<List<CongratulationDto>>(result);
            }
            return new List<CongratulationDto>();
        }

        /// <inheritdoc />
        public async Task<CongratulationDto> Update(CongratulationDtoUpdate model)
        {
            var congratulation = _mapper.Map<Congratulation>(model);
            await _repository.UpdateAsync(congratulation);
            return _mapper.Map<CongratulationDto>(congratulation);
        }
    }
}
