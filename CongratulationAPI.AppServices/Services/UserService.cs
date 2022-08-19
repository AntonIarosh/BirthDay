using AutoMapper;
using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.User;
using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using CongratulationAPI.Infrastructure.Repositoryes.BirthDayRepository;
using CongratulationAPI.Infrastructure.Repositoryes.UserRepository;
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
        private readonly IRepository<User> _repository;
        private readonly IUserRepository _userRepository;
        private readonly IBirthDayRepository _birthDayRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper, IBirthDayRepository birthDayRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _birthDayRepository = birthDayRepository;
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public Task AddAsync(UserDtoAdd model)
        {
            var user = _mapper.Map<User>(model);
            user.CreationDate = DateTime.UtcNow;

            DateTime dR = user.Date;
            int day = dR.Day;
            int month = dR.Month;
            Guid userBirthDay;

            BirthDay holiday = _birthDayRepository.FindByDayAndMonth(day, month);

            if(holiday == null)
            {
                BirthDay birthDay = new BirthDay();
                birthDay.CreationDate = DateTime.UtcNow;
                birthDay.Day = day;
                birthDay.Month = month;
                if (user.Date > DateTime.Now)
                {
                    birthDay.IsPased = false;
                } else
                {
                    birthDay.IsPased = true;
                }
                userBirthDay = _birthDayRepository.AddAsyncAndReturnId(birthDay);
                user.BirthDayId = userBirthDay;
            } else
            {
                user.BirthDayId = holiday.Id;
            }

           /* BirthDay birth = new BirthDay();
            birth.Day = day;
            birth.Month = month;
            birth.CreationDate = DateTime.UtcNow;
            _birthDayRepository.AddAsync(birth);*/

            return _repository.AddAsync(user);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            if(user == null)
            {
                throw new Exception($"Не найден День рождения с id: {id}");
            }
            await _repository.DeleteAsync(user);
        }

        /// <inheritdoc />
        public async Task<List<UserDto>> GetAllUsers()
        {
            var result = await _userRepository.GetAllUsersWithUsersKnowsKnowsToMeAndCongratulations();
            if(result.Count > 0)
            {
                return _mapper.Map<List<UserDto>>(result);
            }
            return new List<UserDto>();
        }

        /// <inheritdoc />
        public async Task<List<UserDto>> GetUsersBetweenDays(int days)
        {
            var result = await _userRepository.FindBirthDayPlusAndMinusDaysAsync(days);

            if (result.Count > 0)
            {
                return _mapper.Map<List<UserDto>>(result);
            }
            return new List<UserDto>();
        }

        /// <inheritdoc />
        public async Task<UserDto> Update(UserDtoUpdate model)
        {
            var user = _mapper.Map<User>(model);
            await _repository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        /// <inheritdoc />
        public async Task<List<UserDto>> GetUsersByFIO(string name, string secondName, string lastName)
        {
            var result = await _userRepository.FindByFIO(name, secondName, lastName);
            if (result.Count > 0)
            {
                return _mapper.Map<List<UserDto>>(result);
            }
            return new List<UserDto>();
        }

        /// <inheritdoc />
        public async Task<List<UserDto>> GetUsersByEmail(string email)
        {
            var result = await _userRepository.FindByEmail(email);
            if (result.Count > 0)
            {
                return _mapper.Map<List<UserDto>>(result);
            }
            return new List<UserDto>();
        }
    }
}
