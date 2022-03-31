using CongratulationAPI.AppServices.Services;
using CongratulationAPI.Contracts.Congratulation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Congratulation.Controllers
{
    /// <summary>
    /// Контроллер обрабатывающий сущность Поздравления
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CongratulationController : ControllerBase
    {
        private readonly ICongratulationService _сongratulationService;

        private readonly ILogger<CongratulationController> _logger;

        /// <summary>
        /// Конструктор с инициализацие поля логирования
        /// </summary>
        /// <param name="logger"> реализация интерфейса логирования </param>
        public CongratulationController(ILogger<CongratulationController> logger, ICongratulationService сongratulationService)
        {
            _logger = logger;
            _сongratulationService = сongratulationService;
        }

        /// <summary>
        /// Получить всех Поздравлений
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _сongratulationService.GetAllCongratulations();
            return Ok(result);
        }

        /// <summary>
        /// Добавление нового Поздравления
        /// </summary>
        /// <param name="model"> модель сущности Поздравления</param>
        /// <returns> код ответа 201</returns>
        [HttpPost] 
        public async Task<IActionResult> Add([FromBody] CongratulationDtoAdd model)
        {
            if(!ModelState.IsValid)
            { 
            // обработка невалидности   
            }
            await _сongratulationService.AddAsync(model);
            return Created(uri: string.Empty, value: null);
        }

        /// <summary>
        /// Обновление данных Поздравления
        /// </summary>
        /// <param name="model"> модель сущности Поздравления </param>
        /// <returns>код ответа 200</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CongratulationDtoUpdate model)
        {
            var result = await _сongratulationService.Update(model);
            return Ok(result);
        }

        /// <summary>
        /// Удаление Поздравления
        /// </summary>
        /// <param name="id"> Идентификатор Поздравления</param>
        /// <returns> код ответа 200</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]Guid id)
        {
            await _сongratulationService.DeleteAsync(id);
            return Ok();
        }
    }
}
