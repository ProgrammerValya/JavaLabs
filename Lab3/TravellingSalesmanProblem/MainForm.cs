using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingSalesmanProblem
{
    public partial class MainForm : Form
    {
        private Random random = new Random();

        public MainForm()
        {
            InitializeComponent();
            
        }
                       

        private void nmrcCountCities_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                nmrcCountCities.Update();
                var val = nmrcCountCities.Value;
            }
        }

        private void nmrcCountCities_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(nmrcCountCities.Value);
                if (count > 1)
                {
                    dtGrdVwCitiesMatrix.RowCount = dtGrdVwCitiesMatrix.ColumnCount =
                        count;
                }
            }
            catch { }
        }

        /// <summary>
        /// Генерирует случайную матрицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandMatr_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtGrdVwCitiesMatrix.RowCount; ++i)
            {                
                for (int j = 0; j < i; ++j)
                {
                    dtGrdVwCitiesMatrix[i, j].Value =
                        dtGrdVwCitiesMatrix[j, i].Value =
                            random.Next(1, byte.MaxValue);
                }
                dtGrdVwCitiesMatrix[i, i].Value = "-";
            }
        }

        /// <summary>
        /// Устанавливает также введенное значение матрицы [i, j] в [j, i]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtGrdVwCitiesMatrix_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == e.ColumnIndex)
            {
                dtGrdVwCitiesMatrix[e.ColumnIndex, e.RowIndex].Value = "-";
            }
            else
            {
                dtGrdVwCitiesMatrix[e.RowIndex, e.ColumnIndex].Value =
                dtGrdVwCitiesMatrix[e.ColumnIndex, e.RowIndex].Value;
            }
                
        }

        /// <summary>
        ///Проверяет введенное значение в матрице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtGrdVwCitiesMatrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int val = Convert.ToInt32(dtGrdVwCitiesMatrix[e.ColumnIndex, e.RowIndex].Value);
                dtGrdVwCitiesMatrix[e.ColumnIndex, e.RowIndex].Value = Math.Abs(val);

            }
            catch
            {
                dtGrdVwCitiesMatrix[e.ColumnIndex, e.RowIndex].Value =
                    dtGrdVwCitiesMatrix[e.RowIndex, e.ColumnIndex].Value;
            }
        }

        /// <summary>
        /// Получает матрицу формы dataGridView
        /// </summary>
        /// <param name="n">Размер матрицы</param>
        /// <returns></returns>
        private int[,] GetMatrix(out int n)
        {
            n = dtGrdVwCitiesMatrix.RowCount;
            var matr = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    matr[i, j] = matr[j, i] = (int)dtGrdVwCitiesMatrix[i, j].Value;
                }
                matr[i, i] = 0;
            }
            return matr;
        }


        /// <summary>
        /// Найдите кратчайший путь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindPath_Click(object sender, EventArgs e)
        {
            nmrcCountGen.Enabled = nmrcCountChildren.Enabled =
               chBxUseMutations.Enabled = nmrcFreqMut.Enabled =
               txtBxPathLenGen.Enabled = txtBxTimeGen.Enabled = true;

            btnFindPath.Enabled = true;


            ///------------
            txtBxTimeExh.Enabled = txtBxPathLenExh.Enabled = true;

            btnFindPath.Enabled = true;
            ///---------------


            txtBxPathLenGen.Clear();
            txtBxPathLenExh.Clear();
            txtBxTimeExh.Clear();
            txtBxTimeGen.Clear();

            // получаем матрицу
            int n;
            int[,] matr = GetMatrix(out n);
            var travel = new Travel(matr, n);

            //генетический алгоритм 
            { 

                var timeGen = new TimeCheck();

                var genetic = new GeneticBase(travel, timeGen);
                // установить параметры
                genetic.CountGenerations = Convert.ToInt32(nmrcCountGen.Value);
                genetic.CountEntitiesInGeneration = Convert.ToInt32(nmrcCountChildren.Value);
                genetic.UseMutation = chBxUseMutations.Checked;
                if (nmrcFreqMut.Enabled)
                    genetic.MunationPercent = Convert.ToDouble(nmrcFreqMut.Value);

                // найден геном
                int[] genom = genetic.Run();

                if (genom != null)
                {
                    // перевести геном в путь
                    int[] path = travel.FormPath(genom);
                    int pathLen = travel.GetPathLen(path);
                    txtBxPathLenGen.Text = pathLen.ToString();
                }
                else
                {
                    txtBxPathLenGen.Text = "-";
                }
                txtBxTimeGen.Text = timeGen.GetTime().ToString();
        }

            //перебор
            {
                var timeExh = new TimeCheck();

                var ex = new ExhaustiveSearch<int>(new MinArea.Permutations<int>(), travel, timeExh);
                // Получить кратчайший путь
                int[] exPath = ex.GetOptimal();
                int exLen = travel.GetPathLen(exPath);
                txtBxPathLenExh.Text = exLen.ToString();

                txtBxTimeExh.Text = timeExh.GetTime().ToString();
            }
        }

        /// <summary>
        /// Блокирует поле мутации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chBxUseMutations_CheckedChanged(object sender, EventArgs e)
        {
            nmrcFreqMut.Enabled = chBxUseMutations.Checked;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Задача комивояжера\n" +
                "Решение возможно найти генетический алгоритмом или перебором\n" +
                "При решении перебором необходимо указать кол-во городов не более 10",
                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblUsedAlg_Click(object sender, EventArgs e)
        {

        }
    }
}
