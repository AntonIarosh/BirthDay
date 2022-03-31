using AutoMapper;
using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.Know;
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
    public class KnowService : IKnowService
    {
        private readonly IRepository<Know> _knowRepository;
        private readonly IMapper _mapper;

        public KnowService(IRepository<Know> knowRepository, IMapper mapper)
        {
            _knowRepository = knowRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public Task AddAsync(KnowDtoAdd model)
        {
            var know = _mapper.Map<Know>(model);
            know.CreationDate = DateTime.UtcNow;
            return _knowRepository.AddAsync(know);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id)
        {
            var know = await _knowRepository.GetByIdAsync(id);
            if(know == null)
            {
                throw new Exception($"Не найден День рождения с id: {id}");
            }
            await _knowRepository.DeleteAsync(know);
        }

        /// <inheritdoc />
        public async Task<List<KnowDto>> GetAllKnows()
        {
            var result = await _knowRepository.GetAll()
                .Include(obj=>obj.FromUser)
                .Include(obj => obj.KnowUser)
                .ToListAsync();
            if(result.Count > 0)
            {
                return _mapper.Map<List<KnowDto>>(result);
            }
            return new List<KnowDto>();
        }

        /// <inheritdoc />
        public async Task<KnowDto> Update(KnowDtoUpdate model)
        {
            var know = _mapper.Map<Know>(model);
            await _knowRepository.UpdateAsync(know);
            return _mapper.Map<KnowDto>(know);
        }
    }
}
