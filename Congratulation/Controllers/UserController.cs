using CongratulationAPI.AppServices.Services;
using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.User;
using CongratulationAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Congratulation.Controllers
{
    /// <summary>
    /// Контроллер обрабатывающий сущность Пользователя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Конструктор с инициализацие поля логирования
        /// </summary>
        /// <param name="logger"> реализация интерфейса логирования </param>
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Получить всех Пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        /// <summary>
        /// Получить всех Пользователей дни рождения которых, находярся в промежутке указанных дней
        /// </summary>
        /// <param name="days"> Дни для диапазона</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> UsersBetweenDays([FromQuery] int days)
        {
            var result = await _userService.GetUsersBetweenDays(days);
            return Ok(result);
        }

        /// <summary>
        /// Получить всех Пользователей по их ФИО
        /// </summary>
        /// <param name="name"> Имя для поиска</param>
        /// <param name="secondName"> Фамилия для поиска</param>
        /// <param name="lastName"> Отчество для поиска</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> UsersByFIO([FromQuery] string name, string secondName, string lastName)
        {
            var result = await _userService.GetUsersByFIO(name, secondName, lastName);
            return Ok(result);
        }

        /// <summary>
        /// Получить всех Пользователей по их Эмейлу
        /// </summary>
        /// <param name="email"> Эмейл для поиска</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> UsersByEmail([FromQuery] string email)
        {
            var result = await _userService.GetUsersByEmail(email);
            return Ok(result);
        }

        /// <summary>
        /// Добавление нового Пользователя
        /// </summary>
        /// <param name="model"> модель сущности Пользователяя</param>
        /// <returns> код ответа 201</returns>
        [HttpPost] 
        public async Task<IActionResult> Add([FromBody] UserDtoAdd model)
        {
            if(!ModelState.IsValid)
            { 
            // обработка невалидности   
            }
            await _userService.AddAsync(model);
            return Created(uri: string.Empty, value: null);
        }

        /// <summary>
        /// Обновление данных Пользователя
        /// </summary>
        /// <param name="model"> модель сущности Пользователя </param>
        /// <returns>код ответа 200</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDtoUpdate model)
        {
            var result = await _userService.Update(model);
            return Ok(result);
        }

        /// <summary>
        /// Удаление Пользователя
        /// </summary>
        /// <param name="id"> Идентификатор Пользователя</param>
        /// <returns> код ответа 200</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
