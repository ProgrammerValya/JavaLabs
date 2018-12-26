using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{
    /// <summary>
    /// Генетический алгоритм
    /// </summary>
    class GeneticBase
    {
        static private readonly int BIT_PER_GEN = 32;

        /// <summary>The Fitnessness function</summary>
        private IFintness _fintness;

        /// <summary>Длина генома в битах</summary>
        private int _genomLength;

        /// <summary>
        /// Количество генов в биноме
        /// Один ген имеет 'BIT_PER_GEN' битов
        /// </summary>
        private int _countGens;

        /// <summary>Родитель</summary>
        private int[][] _parentGenoms;

        /// <summary>Ребенок</summary>
        private int[][] _childrenGenoms;


        private Random random = new Random();

        /// <summary>Проверка времени</summary>
        private ITimeCheck _timeCheck;

        /// <summary>Количество генераций работающего алгоритма=</summary>
        public int CountGenerations { get; set; }

        /// <summary>Количество детей в каждом поколении</summary>
        public int CountEntitiesInGeneration { get; set; }

        /// <summary>Будут ли использованы мутации</summary>
        public bool UseMutation { get; set; }

        /// <summary>Частота мутаций</summary>
        public double MunationPercent { get; set; }

        public GeneticBase(IFintness fintness, ITimeCheck timeCheck = null)
        {
            _fintness = fintness;
            _genomLength = fintness.Arity;
            _countGens = (int) Math.Ceiling((double)_genomLength / BIT_PER_GEN);
            _timeCheck = timeCheck;
        }

        /// <summary>
        /// Турнирный отбор. (Парный турнир)
        /// </summary>
        private void DoSelection()
        {
            // на каждого ребенка
            for (int i = 0; i < CountEntitiesInGeneration; ++i)
            {
                // выбрать двух случайных родителей
                int ind1 = random.Next(CountEntitiesInGeneration);
                int ind2 = random.Next(CountEntitiesInGeneration);

                // принять значение Finnes Finction
                int fr1 = _fintness.Fitness(_parentGenoms[ind1]);
                int fr2 = _fintness.Fitness(_parentGenoms[ind2]);

                // установить текущим потомкам выбранного родителя
                // с лучшим значением фитнес-функции
                _childrenGenoms[i] = fr1 > fr2 ? (int[])_parentGenoms[ind1].Clone() :
                    (int[])_parentGenoms[ind2].Clone();                
            }
        }

        /// <summary>
        /// Скрещивание два генома
        /// </summary>
        /// <param name="genom1"></param>
        /// <param name="genom2"></param>
        private void CrossGenoms(int[] genom1, int[] genom2)
        {
            for (int i = 0; i < _countGens; ++i)
            {
                int mask = random.Next();
                int swapMask = (genom1[i] ^ genom2[i]) & mask; //исключающее ИЛИ для 2 геномов + побитовая операция И для маски и геномов
                genom1[i] ^= swapMask;
                genom2[i] ^= swapMask;
            }
        }

        /// <summary>
        /// Скрещивание детского поколения
        /// </summary>
        private void CrossGeneration()
        {
            for (int i = 0; i < CountEntitiesInGeneration / 2; ++i)
            {
                int ind1 = i * 2;
                int ind2 = ind1 + 1;
                CrossGenoms(_childrenGenoms[ind1], _childrenGenoms[ind2]);
            }
        }

        /// <summary>
        /// Мутировать геном случайно
        /// </summary>
        /// <param name="genom"></param>
        private void MutateGenom(int[] genom)
        {
            // изменить один бит в геноме
            int ind = random.Next(_countGens);
            int offset = random.Next(BIT_PER_GEN);
            int mask = 1 << offset;
            genom[ind] ^= mask;
        }

        /// <summary>
        /// Мутировать детское поколение
        /// </summary>
        private void MutateGeneration()
        {
            foreach (var genom in _childrenGenoms)
            {
                if (random.NextDouble() <= MunationPercent)
                    MutateGenom(genom);
                
            }
        }

        /// <summary>
        /// Создает случайный геном
        /// </summary>
        /// <returns></returns>
        private int[] GenerateRandomGenom()
        {
            var res = new int[_countGens];
            for (int i = 0; i < res.Length; ++i)
            {
                res[i] = random.Next();
            }
            return res;
        }

        /// <summary>
        /// Создает первое поколение родителей
        /// </summary>
        private void CreateFirstGeneration()
        {
            for (int i = 0; i < _parentGenoms.Length; ++i)
            {
                _parentGenoms[i] = GenerateRandomGenom();
            }
        }

        private void WriteToFile()
        {
            for (int i = 0; i < _parentGenoms.Length; ++i)
            {
                _parentGenoms[i] = GenerateRandomGenom();
            }
        }

        /// <summary>
        /// Запускает алгоритм
        /// </summary>
        /// <returns>лучший геном</returns>
        public int[] Run()
        {
            FileStream file1 = new FileStream("test.txt", FileMode.Create); 
            StreamWriter writer = new StreamWriter(file1); 
            
           
            
            _parentGenoms = new int[CountEntitiesInGeneration][];
            _childrenGenoms = new int[CountEntitiesInGeneration][];

            _timeCheck?.Start();

            CreateFirstGeneration();

            writer.Write("Первое поколение"+'\n');
            for (int i = 0; i < _parentGenoms.GetLength(0); i++)
            {
                for (int j = 0; j < _countGens; j++)
                    writer.Write(_parentGenoms[i][j]+" ");
                writer.WriteLine();
            }

            for (int currGen = 0; currGen+1 < CountGenerations; ++currGen)
            {
               

                DoSelection();
                CrossGeneration();

                writer.Write("\n Поколение № " + (currGen + 2) + '\n');
                foreach (var genom in _childrenGenoms)
                {
                    foreach (int item in genom)
                        writer.Write(item+" ");
                    writer.WriteLine();
                }

                if (UseMutation)
                {
                    MutateGeneration();


                    writer.Write("Поколение № " + (currGen+2) + " после мутации \n");
                    foreach (var genom in _childrenGenoms)
                    {
                        foreach (int item in genom)
                            writer.Write(item + " ");
                        writer.WriteLine();
                    }
                }
                   
                var tmp = _parentGenoms;
                _parentGenoms = _childrenGenoms;
                _childrenGenoms = tmp;
            }

            // выбрать лучший
            int bestFitnessness = 0;
            int[] bestGenom = null;
            foreach (var genom in _parentGenoms)
            {
                int FitnessRes = _fintness.Fitness(genom);
                if (FitnessRes > bestFitnessness)
                {
                    bestFitnessness = FitnessRes;
                    bestGenom = genom;
                }
            }

            _timeCheck?.Stop();

            writer.Close();
            return bestGenom;
        }
    }
}
