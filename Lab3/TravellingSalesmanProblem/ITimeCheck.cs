using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{
    /// <summary>
    /// Интерфейс для записи времени
    /// </summary>
    interface ITimeCheck
    {
        /// <summary>
        /// Начинает отсчет
        /// </summary>
        void Start();

        /// <summary>
        /// Перезапускает счет
        /// </summary>
        void Restart();

        /// <summary>
        /// Останавливает счет
        /// </summary>
        void Stop();

        /// <summary> Получает время в миллисекундах </ summary>
        /// <returns></returns>
        long GetTime();
    }
}
