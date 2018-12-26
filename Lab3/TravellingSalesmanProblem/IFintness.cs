using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{
    /// <summary>
    /// Интерфейс для решения задачи генетическим алгоритмом
    /// </summary>
    interface IFintness
    {
        /// <summary>
        /// Количество генов в геноме
        /// </summary>
        int Arity { get; }

        /// <summary>
        /// Фитнес-функция
        /// Возвращает более высокое значение, если значение генома ближе к идеальному
        /// </summary>
        /// <param name="genom"></param>
        /// <returns></returns>
        int Fitness(int[] genom);
    }
}
