using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinArea
{
    /// <summary>
    /// Класс вспомогательных функций
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Меняет два значения
        /// </summary>


        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }        
    }
}
