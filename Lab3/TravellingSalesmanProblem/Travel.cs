using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{
    /// <summary>
    /// Задача коммивояжера
    /// </summary>
    class Travel : IFintness, IExhaustive<int>
    {
        static private readonly int BITS_PER_CITY = 32;

        /// <summary> Количество городов </ summary>
        public int CountCities { get; private set; } = 4;

        /// <summary> Матрица смежности </ summary>
        private int[,] _matrix;

        /// <summary>
        /// Пара с ключом в качестве номера города
        /// и знаечнием
        /// </summary>
        private Pair[] _pairs;

        /// <summary> Текущий путь </ summary>
        private int[] _path;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name = "matr"> матрица смежности </ param>
        /// <param name = "count"> размер матрицы </ param>
        public Travel(int[,] matr, int count)
        {
            _matrix = matr;
            CountCities = count;

            _pairs = new Pair[CountCities];
            _path = new int[CountCities];
            for (int i = 0; i < CountCities; ++i)
            {
                _pairs[i] = new Pair();
            }
        }

        /// <summary>Размер генома в битах</summary>
        public int Arity => CountCities * BITS_PER_CITY;

        /// <summary>
        /// Получить длину пути по заданным городам
        /// </summary>
        /// <param name="citiesNums"></param>
        /// <returns>
        /// Длина или -1, если в пути есть одинаковые города
        /// </returns>
        public int GetPathLen(int[] citiesNums)
        {
            bool[] visited = new bool[CountCities];
            int len = 0;
            for (int i = 0; i < citiesNums.Length - 1; ++i)
            {
                if (visited[citiesNums[i]])
                    return -1;

                visited[citiesNums[i]] = true;
                len += _matrix[citiesNums[i], citiesNums[i + 1]];
            }
            if (visited[citiesNums[citiesNums.Length - 1]])
                return -1;

            len += _matrix[citiesNums[citiesNums.Length - 1], citiesNums[0]];
            return len;
        }

        /// <summary>
        /// The Fitnessness function
        /// </summary>
        /// <param name="genom"></param>
        /// <returns>
        /// Если сформированный путь короче, то результат выше
        /// </returns>
        public int Fitness(int[] genom)
        {
            var path = FormPath(genom);
            int len = GetPathLen(path);
            return len == -1 ? 0 : int.MaxValue - len;
        }

        /// <summary>
        /// Формирует путь по данному геному
        /// </summary>
        /// <param name="genom"></param>
        /// <returns></returns>
        public int[] FormPath(int[] genom)
        {
            // для каждого города устанавливаем соответствующий ген в естественном порядке
            for (int i = 0; i < CountCities; ++i)
            {
                _pairs[i].Key = i;
                _pairs[i].Value = genom[i];
            }

            // сортируем пары по значению генов
            Array.Sort(_pairs);

            // сделать путь 
            for (int i = 0; i < genom.Length; ++i)
            {
                //path[i] = genom[i] % CountCities;                 
                _path[i] = _pairs[i].Key;
            }            
            return _path;
        }

        /// <summary>
        /// Получает набор номеров городов
        /// </summary>
        /// <returns></returns>
        public int[] GetSet()
        {
            var citieNums = new int[CountCities];
            for (int i = 0; i < CountCities; ++i)
            {
                citieNums[i] = i;
            }
            return citieNums;
        }

        /// <summary>
        /// Получает коэффициент для алгоритмов перестановки
        /// </summary>
        /// <param name="perm"></param>
        /// <returns>
        /// Если сформированный путь короче, то результат выше
        /// </returns>
        public int OptimalСoef(int[] perm)
        {
            int len = GetPathLen(perm);
            return int.MaxValue - len;
        }
    }    
}
