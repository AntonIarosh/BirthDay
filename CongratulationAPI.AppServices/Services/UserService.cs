using AutoMapper;
using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.User;
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
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<BirthDay> _birthDayRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper, IRepository<BirthDay> birthDayRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _birthDayRepository = birthDayRepository;
        }

        /// <inheritdoc />
        public Task AddAsync(UserDtoAdd model)
        {
            var user = _mapper.Map<User>(model);
            user.CreationDate = DateTime.UtcNow;

            DateTime dR = user.Date;
            int day = dR.Day;
            int month = dR.Month;

           /* BirthDay birth = new BirthDay();
            birth.Day = day;
            birth.Month = month;
            birth.CreationDate = DateTime.UtcNow;
            _birthDayRepository.AddAsync(birth);*/

            return _userRepository.AddAsync(user);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null)
            {
                throw new Exception($"Не найден День рождения с id: {id}");
            }
            await _userRepository.DeleteAsync(user);
        }

        /// <inheritdoc />
        public async Task<List<UserDto>> GetAllUsers()
        {
            var result = await _userRepository.GetAll()
                .Include(obj=>obj.Knows)
                .Include(obj => obj.KnowsToMe)
                .Include(obj => obj.Congratulations)
                .ToListAsync();
            if(result.Count > 0)
            {
                return _mapper.Map<List<UserDto>>(result);
            }
            return new List<UserDto>();
        }

        /// <inheritdoc />
        public async Task<UserDto> Update(UserDtoUpdate model)
        {
            var user = _mapper.Map<User>(model);
            await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }
    }
}
