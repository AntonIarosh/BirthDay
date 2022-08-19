using CongratulationAPI.AppServices.Services;
using CongratulationAPI.Contracts.BirthDay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Congratulation.Controllers
{
    /// <summary>
    /// Контроллер обрабатывающий сущность Дня рождения 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BirthDayController : ControllerBase
    {
        private readonly IBirthDayService _birthDayService;

        private readonly ILogger<BirthDayController> _logger;

        /// <summary>
        /// Конструктор с инициализацие поля логирования
        /// </summary>
        /// <param name="logger"> реализация интерфейса логирования </param>
        public BirthDayController(ILogger<BirthDayController> logger, IBirthDayService birthDayService)
        {
            _logger = logger;
            _birthDayService = birthDayService;
        }

        /// <summary>
        /// Получить всех Дней рождений
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _birthDayService.GetAllBirthDays();
            return Ok(result);
        }

        /// <summary>
        /// Получить Дни Рождения на текущую дату
        /// </summary>
        /// <param name="day"> дата дня рождения</param>
        /// <param name="month"> месяц рождения </param>
        /// <returns>список Дней Рождения на сегодня</returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetByDayAndMonth([FromQuery] int day, [FromQuery] int month)
        {
            var result = await _birthDayService.GetByDayAndMonth(day, month);
            return Ok(result);
        }

        /// <summary>
        /// Добавление нового Дня рождения
        /// </summary>
        /// <param name="model"> модель сущности Дня рождения</param>
        /// <returns> код ответа 201</returns>
        [HttpPost] 
        public async Task<IActionResult> Add([FromBody] BirthDayDtoAdd model)
        {
            if(!ModelState.IsValid)
            { 
            // обработка невалидности   
            }
            await _birthDayService.AddAsync(model);
            return Created(uri: string.Empty, value: null);
        }

        /// <summary>
        /// Обновление данных Дня рождения
        /// </summary>
        /// <param name="model"> модель сущности Дня рождения </param>
        /// <returns>код ответа 200</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BirthDayDtoUpdate model)
        {
            var result = await _birthDayService.Update(model);
            return Ok(result);
        }

        /// <summary>
        /// Удаление Дня рождения
        /// </summary>
        /// <param name="id"> Идентификатор Дня рождения</param>
        /// <returns> код ответа 200</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]Guid id)
        {
            await _birthDayService.DeleteAsync(id);
            return Ok();
        }

    }
}
