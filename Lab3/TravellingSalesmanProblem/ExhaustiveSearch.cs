using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{

    class ExhaustiveSearch<T>
    {
        /// <summary>Генератор перестановок</summary>
        private MinArea.IPermutations<T> _perm;


        private IExhaustive<T> _exh;

        /// <summary>Проверка времени</summary>
        private ITimeCheck _time;

        public ExhaustiveSearch(
            MinArea.IPermutations<T> perm, 
            IExhaustive<T> exh,
            ITimeCheck time = null)
        {
            _perm = perm;
            _exh = exh;
            _time = time;
        }

        /// <summary>
        /// Найти оптиматльное количество перестановок
        /// </summary>
        /// <returns></returns>
        public T[] GetOptimal()
        {            
            T[] result = null;
            int maxK = 0;

            _time?.Start();

            _perm.Generate(_exh.GetSet(), perm =>
            {
                int k = _exh.OptimalСoef(perm);
                if (k > maxK)
                {
                    maxK = k;
                    result = (T[])perm.Clone();
                }
            });

            _time?.Stop();

            return result;
        }
    }
}
