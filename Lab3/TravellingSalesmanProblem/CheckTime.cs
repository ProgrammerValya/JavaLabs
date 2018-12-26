using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TravellingSalesmanProblem
{
    /// <summary>
    /// Проверяет время работы
    /// </summary>
    class TimeCheck : ITimeCheck
    {
        private Stopwatch sw = new Stopwatch();

        public long GetTime() => sw.ElapsedMilliseconds;

        public void Restart() => sw.Restart();

        public void Start() => sw.Start();

        public void Stop() => sw.Stop();
    }
}
