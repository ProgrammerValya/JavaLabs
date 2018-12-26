using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{
    /// <summary>
    /// Интерфейс для решения задачи с помощью перебора вариантов
    /// </summary>
    interface IExhaustive<T>
    {
        /// <summary>
        /// Получить массив с которым будет работать алгоритм
        /// </summary>
        /// <returns></returns>
        T[] GetSet();

        /// <summary>
        /// Если перестановка болеее оптимальна, чем функция
        /// мы должны вернуть больший коэффициент(неотрицательный)
        /// </summary>
        /// <param name="perm"></param>
        /// <returns>Оптимальный коэффициент</returns>
        int OptimalСoef(T[] perm);
    }
}
