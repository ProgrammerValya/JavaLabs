using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{
    /// <summary>
    /// Пара с изменяемым ключом и значением
    /// </summary>
    internal class Pair : IComparable<Pair>
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public Pair(int key, int value)
        {
            Key = key;
            Value = value;
        }

        public Pair() { }

        /// <summary>
        /// Сравнивает по значениям
        /// </summary>
          /// <returns></returns>
        public int CompareTo(Pair other) => Value - other.Value;
    }
}
