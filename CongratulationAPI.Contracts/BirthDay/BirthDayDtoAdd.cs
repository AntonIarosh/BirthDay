
namespace CongratulationAPI.Contracts.BirthDay
{
    public class BirthDayDtoAdd
    {
        /// <summary>
        /// Клнкретный день даты Дня рождения
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Клнкретный месяц даты Дня рождения
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Флаг - прошёл ли День рождения сейчас или нет
        /// </summary>
        public bool IsPased { get; set; }
    }
}
