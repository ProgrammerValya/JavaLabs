using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinArea
{
    /// <summary>
    /// Интерфейс для получения перестановок
    /// </summary>
    /// <typeparam name="T">Какой-либо тип элемента</typeparam>
    public interface IPermutations<T>
    {
        /// <summary>
        /// Генерирует N! перестановок из массива set и
        /// для каждой перестановки вызывает callback
        /// </summary>
        /// <param name="set">
        /// набор элементов из которых нужно составить перестановки
        /// </param>
        /// <param name="callback">
        /// функция, которая вызываетя для каждой перестановки
        /// </param>
        void Generate(T[] set, Action<T[]> callback);
    }

    /// <summary>
    /// Представляет интерфейс генерирующий перестановки рекурсивно
    /// </summary>

    public class Permutations<T> : IPermutations<T>
    {
        private T[] _set;
        private Action<T[]> _callback = null;

  
        public void Generate(T[] set, Action<T[]> callback)
        {
            _set = new T[set.Length];
            set.CopyTo(_set, 0);
            _callback = callback;
            GenerateRec(0, _set.Length);
        }

        /// <summary>
        /// генерирует перестановки рекурсивно
        /// </summary>
        /// <param name="k">С какой индекса мы начинаем</param>
        /// <param name="n">Количество</param>
        private void GenerateRec(int k, int n)
        {
            if (k == n)  //если перестановка составлена
            {
                _callback?.Invoke(_set);
            }
            else
            {
                for (int i = k; i < n; ++i)
                {
                    Utils.Swap(ref _set[i], ref _set[k]);
                    GenerateRec(k + 1, n);
                    Utils.Swap(ref _set[i], ref _set[k]);
                }
            }
        }
    }
}
