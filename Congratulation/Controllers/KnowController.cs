using CongratulationAPI.AppServices.Services;
using CongratulationAPI.Contracts.Know;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Congratulation.Controllers
{
    /// <summary>
    /// Контроллер обрабатывающий сущность Знакомых
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class KnowController : ControllerBase
    {
        private readonly IKnowService _knowService;

        private readonly ILogger<KnowController> _logger;

        /// <summary>
        /// Конструктор с инициализацие поля логирования
        /// </summary>
        /// <param name="logger"> реализация интерфейса логирования </param>
        public KnowController(ILogger<KnowController> logger, IKnowService knowService)
        {
            _logger = logger;
            _knowService = knowService;
        }

        /// <summary>
        /// Получить всех Знакомых
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _knowService.GetAllKnows();
            return Ok(result);
        }

        /// <summary>
        /// Добавление нового Знакомого
        /// </summary>
        /// <param name="model"> модель сущности Знакомого</param>
        /// <returns> код ответа 201</returns>
        [HttpPost] 
        public async Task<IActionResult> Add([FromBody] KnowDtoAdd model)
        {
            if(!ModelState.IsValid)
            { 
            // обработка невалидности   
            }
            await _knowService.AddAsync(model);
            return Created(uri: string.Empty, value: null);
        }

        /// <summary>
        /// Обновление данных Знакомого
        /// </summary>
        /// <param name="model"> модель сущности Знакомого </param>
        /// <returns>код ответа 200</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] KnowDtoUpdate model)
        {
            var result = await _knowService.Update(model);
            return Ok(result);
        }

        /// <summary>
        /// Удаление Знакомого
        /// </summary>
        /// <param name="id"> Идентификатор Знакомого</param>
        /// <returns> код ответа 200</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]Guid id)
        {
            await _knowService.DeleteAsync(id);
            return Ok();
        }
    }
}
