using AutoMapper;
using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using CongratulationAPI.Infrastructure.Repositoryes.BirthDayRepository;
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
    public class BirthDayService : IBirthDayService
    {
        private readonly IRepository<BirthDay> _repository;
        private readonly IBirthDayRepository _birthDayRepository;
        private readonly IMapper _mapper;

        public BirthDayService(IRepository<BirthDay> repository, IMapper mapper, IBirthDayRepository birthDayRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _birthDayRepository = birthDayRepository;
        }

        /// <inheritdoc />
        public Task AddAsync(BirthDayDtoAdd model)
        {
            var birthDay = _mapper.Map<BirthDay>(model);
            birthDay.CreationDate = DateTime.UtcNow;
            return _repository.AddAsync(birthDay);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id)
        {
            var birthDay = await _repository.GetByIdAsync(id);
            if(birthDay == null)
            {
                throw new Exception($"Не найден День рождения с id: {id}");
            }
            await _repository.DeleteAsync(birthDay);
        }

        /// <inheritdoc />
        public async Task<List<BirthDayDto>> GetAllBirthDays()
        {
            var result = await _birthDayRepository.GetAllBirthDaysWithCongratulations();
            if(result.Count > 0)
            {
                return _mapper.Map<List<BirthDayDto>>(result);
            }
            return new List<BirthDayDto>();
        }

        /// <inheritdoc />
        public async Task<List<BirthDayDto>> GetByDayAndMonth(int day, int month)
        {
            var result = await _birthDayRepository.FindByDayAndMonthAsync(day, month);
            if (result != null)
            {
                return _mapper.Map<List<BirthDayDto>>(result);
            }
            return new List<BirthDayDto>();

        }

        /// <inheritdoc />
        public async Task<BirthDayDto> Update(BirthDayDtoUpdate model)
        {
            var birthDay = _mapper.Map<BirthDay>(model);
            await _repository.UpdateAsync(birthDay);
            return _mapper.Map<BirthDayDto>(birthDay);
        }
    }
}
