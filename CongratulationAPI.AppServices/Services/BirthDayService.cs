using AutoMapper;
using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
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
        private readonly IRepository<BirthDay> _birthDayRepository;
        private readonly IMapper _mapper;

        public BirthDayService(IRepository<BirthDay> birthDayRepository, IMapper mapper)
        {
            _birthDayRepository = birthDayRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public Task AddAsync(BirthDayDtoAdd model)
        {
            var birthDay = _mapper.Map<BirthDay>(model);
            birthDay.CreationDate = DateTime.UtcNow;
            return _birthDayRepository.AddAsync(birthDay);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id)
        {
            var birthDay = await _birthDayRepository.GetByIdAsync(id);
            if(birthDay == null)
            {
                throw new Exception($"Не найден День рождения с id: {id}");
            }
            await _birthDayRepository.DeleteAsync(birthDay);
        }

        /// <inheritdoc />
        public async Task<List<BirthDayDto>> GetAllBirthDays()
        {
            var result = await _birthDayRepository.GetAll()
                .Include(obj=>obj.Congratulations)
                .ToListAsync();
            if(result.Count > 0)
            {
                return _mapper.Map<List<BirthDayDto>>(result);
            }
            return new List<BirthDayDto>();
        }

        /// <inheritdoc />
        public async Task<BirthDayDto> Update(BirthDayDtoUpdate model)
        {
            var birthDay = _mapper.Map<BirthDay>(model);
            await _birthDayRepository.UpdateAsync(birthDay);
            return _mapper.Map<BirthDayDto>(birthDay);
        }
    }
}
