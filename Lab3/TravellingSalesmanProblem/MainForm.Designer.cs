namespace TravellingSalesmanProblem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtGrdVwCitiesMatrix = new System.Windows.Forms.DataGridView();
            this.nmrcCountCities = new System.Windows.Forms.NumericUpDown();
            this.btnRandMatr = new System.Windows.Forms.Button();
            this.lblGenAlg = new System.Windows.Forms.Label();
            this.lblExhaustive = new System.Windows.Forms.Label();
            this.lblGenParams = new System.Windows.Forms.Label();
            this.lblCountGen = new System.Windows.Forms.Label();
            this.nmrcCountGen = new System.Windows.Forms.NumericUpDown();
            this.lblCountChildrenInGen = new System.Windows.Forms.Label();
            this.nmrcCountChildren = new System.Windows.Forms.NumericUpDown();
            this.lblUseMutations = new System.Windows.Forms.Label();
            this.chBxUseMutations = new System.Windows.Forms.CheckBox();
            this.lblShortestPathLen = new System.Windows.Forms.Label();
            this.txtBxPathLenGen = new System.Windows.Forms.TextBox();
            this.txtBxPathLenExh = new System.Windows.Forms.TextBox();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtBxTimeGen = new System.Windows.Forms.TextBox();
            this.txtBxTimeExh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nmrcFreqMut = new System.Windows.Forms.NumericUpDown();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwCitiesMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCountCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCountGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCountChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcFreqMut)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGrdVwCitiesMatrix
            // 
            this.dtGrdVwCitiesMatrix.AllowUserToAddRows = false;
            this.dtGrdVwCitiesMatrix.AllowUserToDeleteRows = false;
            this.dtGrdVwCitiesMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGrdVwCitiesMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwCitiesMatrix.Location = new System.Drawing.Point(12, 12);
            this.dtGrdVwCitiesMatrix.Name = "dtGrdVwCitiesMatrix";
            this.dtGrdVwCitiesMatrix.Size = new System.Drawing.Size(396, 327);
            this.dtGrdVwCitiesMatrix.TabIndex = 0;
            this.dtGrdVwCitiesMatrix.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdVwCitiesMatrix_CellEndEdit);
            this.dtGrdVwCitiesMatrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdVwCitiesMatrix_CellValueChanged);
            // 
            // nmrcCountCities
            // 
            this.nmrcCountCities.Location = new System.Drawing.Point(106, 350);
            this.nmrcCountCities.Name = "nmrcCountCities";
            this.nmrcCountCities.Size = new System.Drawing.Size(61, 20);
            this.nmrcCountCities.TabIndex = 1;
            this.nmrcCountCities.ValueChanged += new System.EventHandler(this.nmrcCountCities_ValueChanged);
            this.nmrcCountCities.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nmrcCountCities_KeyPress);
            // 
            // btnRandMatr
            // 
            this.btnRandMatr.Location = new System.Drawing.Point(190, 347);
            this.btnRandMatr.Name = "btnRandMatr";
            this.btnRandMatr.Size = new System.Drawing.Size(218, 23);
            this.btnRandMatr.TabIndex = 2;
            this.btnRandMatr.Text = "Случайное заполнение";
            this.btnRandMatr.UseVisualStyleBackColor = true;
            this.btnRandMatr.Click += new System.EventHandler(this.btnRandMatr_Click);
            // 
            // lblGenAlg
            // 
            this.lblGenAlg.AutoSize = true;
            this.lblGenAlg.Location = new System.Drawing.Point(546, 182);
            this.lblGenAlg.Name = "lblGenAlg";
            this.lblGenAlg.Size = new System.Drawing.Size(128, 13);
            this.lblGenAlg.TabIndex = 3;
            this.lblGenAlg.Text = "Генетический алгоритм";
            // 
            // lblExhaustive
            // 
            this.lblExhaustive.AutoSize = true;
            this.lblExhaustive.Location = new System.Drawing.Point(704, 182);
            this.lblExhaustive.Name = "lblExhaustive";
            this.lblExhaustive.Size = new System.Drawing.Size(51, 13);
            this.lblExhaustive.TabIndex = 4;
            this.lblExhaustive.Text = "Перебор";
            // 
            // lblGenParams
            // 
            this.lblGenParams.AutoSize = true;
            this.lblGenParams.Location = new System.Drawing.Point(454, 40);
            this.lblGenParams.Name = "lblGenParams";
            this.lblGenParams.Size = new System.Drawing.Size(200, 13);
            this.lblGenParams.TabIndex = 5;
            this.lblGenParams.Text = "Параметры генетического алгоритма";
            // 
            // lblCountGen
            // 
            this.lblCountGen.AutoSize = true;
            this.lblCountGen.Location = new System.Drawing.Point(454, 66);
            this.lblCountGen.Name = "lblCountGen";
            this.lblCountGen.Size = new System.Drawing.Size(110, 13);
            this.lblCountGen.TabIndex = 6;
            this.lblCountGen.Text = "Кол-во полколений: ";
            // 
            // nmrcCountGen
            // 
            this.nmrcCountGen.Location = new System.Drawing.Point(624, 64);
            this.nmrcCountGen.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrcCountGen.Name = "nmrcCountGen";
            this.nmrcCountGen.Size = new System.Drawing.Size(84, 20);
            this.nmrcCountGen.TabIndex = 7;
            // 
            // lblCountChildrenInGen
            // 
            this.lblCountChildrenInGen.AutoSize = true;
            this.lblCountChildrenInGen.Location = new System.Drawing.Point(454, 92);
            this.lblCountChildrenInGen.Name = "lblCountChildrenInGen";
            this.lblCountChildrenInGen.Size = new System.Drawing.Size(164, 13);
            this.lblCountChildrenInGen.TabIndex = 8;
            this.lblCountChildrenInGen.Text = "Кол-во особоей в полколении: ";
            // 
            // nmrcCountChildren
            // 
            this.nmrcCountChildren.Location = new System.Drawing.Point(624, 90);
            this.nmrcCountChildren.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrcCountChildren.Name = "nmrcCountChildren";
            this.nmrcCountChildren.Size = new System.Drawing.Size(84, 20);
            this.nmrcCountChildren.TabIndex = 9;
            // 
            // lblUseMutations
            // 
            this.lblUseMutations.AutoSize = true;
            this.lblUseMutations.Location = new System.Drawing.Point(454, 116);
            this.lblUseMutations.Name = "lblUseMutations";
            this.lblUseMutations.Size = new System.Drawing.Size(131, 13);
            this.lblUseMutations.TabIndex = 10;
            this.lblUseMutations.Text = "Использовать мутации: ";
            // 
            // chBxUseMutations
            // 
            this.chBxUseMutations.AutoSize = true;
            this.chBxUseMutations.Location = new System.Drawing.Point(624, 116);
            this.chBxUseMutations.Name = "chBxUseMutations";
            this.chBxUseMutations.Size = new System.Drawing.Size(15, 14);
            this.chBxUseMutations.TabIndex = 11;
            this.chBxUseMutations.UseVisualStyleBackColor = true;
            this.chBxUseMutations.CheckedChanged += new System.EventHandler(this.chBxUseMutations_CheckedChanged);
            // 
            // lblShortestPathLen
            // 
            this.lblShortestPathLen.AutoSize = true;
            this.lblShortestPathLen.Location = new System.Drawing.Point(456, 209);
            this.lblShortestPathLen.Name = "lblShortestPathLen";
            this.lblShortestPathLen.Size = new System.Drawing.Size(71, 13);
            this.lblShortestPathLen.TabIndex = 12;
            this.lblShortestPathLen.Text = "Длина пути: ";
            // 
            // txtBxPathLenGen
            // 
            this.txtBxPathLenGen.Location = new System.Drawing.Point(565, 206);
            this.txtBxPathLenGen.Name = "txtBxPathLenGen";
            this.txtBxPathLenGen.Size = new System.Drawing.Size(89, 20);
            this.txtBxPathLenGen.TabIndex = 13;
            // 
            // txtBxPathLenExh
            // 
            this.txtBxPathLenExh.Location = new System.Drawing.Point(690, 206);
            this.txtBxPathLenExh.Name = "txtBxPathLenExh";
            this.txtBxPathLenExh.Size = new System.Drawing.Size(89, 20);
            this.txtBxPathLenExh.TabIndex = 14;
            // 
            // btnFindPath
            // 
            this.btnFindPath.Location = new System.Drawing.Point(801, 40);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(75, 23);
            this.btnFindPath.TabIndex = 15;
            this.btnFindPath.Text = "Найти путь";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(456, 235);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(69, 13);
            this.lblTime.TabIndex = 16;
            this.lblTime.Text = "Время (мс): ";
            // 
            // txtBxTimeGen
            // 
            this.txtBxTimeGen.Location = new System.Drawing.Point(565, 232);
            this.txtBxTimeGen.Name = "txtBxTimeGen";
            this.txtBxTimeGen.Size = new System.Drawing.Size(89, 20);
            this.txtBxTimeGen.TabIndex = 17;
            // 
            // txtBxTimeExh
            // 
            this.txtBxTimeExh.Location = new System.Drawing.Point(690, 232);
            this.txtBxTimeExh.Name = "txtBxTimeExh";
            this.txtBxTimeExh.Size = new System.Drawing.Size(89, 20);
            this.txtBxTimeExh.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Частота мутаций:";
            // 
            // nmrcFreqMut
            // 
            this.nmrcFreqMut.DecimalPlaces = 2;
            this.nmrcFreqMut.Enabled = false;
            this.nmrcFreqMut.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nmrcFreqMut.Location = new System.Drawing.Point(624, 136);
            this.nmrcFreqMut.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrcFreqMut.Name = "nmrcFreqMut";
            this.nmrcFreqMut.Size = new System.Drawing.Size(84, 20);
            this.nmrcFreqMut.TabIndex = 20;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(801, 82);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 24;
            this.btnHelp.Text = "Помощь";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Кол-во городов:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 431);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.nmrcFreqMut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxTimeExh);
            this.Controls.Add(this.txtBxTimeGen);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnFindPath);
            this.Controls.Add(this.txtBxPathLenExh);
            this.Controls.Add(this.txtBxPathLenGen);
            this.Controls.Add(this.lblShortestPathLen);
            this.Controls.Add(this.chBxUseMutations);
            this.Controls.Add(this.lblUseMutations);
            this.Controls.Add(this.nmrcCountChildren);
            this.Controls.Add(this.lblCountChildrenInGen);
            this.Controls.Add(this.nmrcCountGen);
            this.Controls.Add(this.lblCountGen);
            this.Controls.Add(this.lblGenParams);
            this.Controls.Add(this.lblExhaustive);
            this.Controls.Add(this.lblGenAlg);
            this.Controls.Add(this.btnRandMatr);
            this.Controls.Add(this.nmrcCountCities);
            this.Controls.Add(this.dtGrdVwCitiesMatrix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Задача комивояжера";
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwCitiesMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCountCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCountGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCountChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcFreqMut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGrdVwCitiesMatrix;
        private System.Windows.Forms.NumericUpDown nmrcCountCities;
        private System.Windows.Forms.Button btnRandMatr;
        private System.Windows.Forms.Label lblGenAlg;
        private System.Windows.Forms.Label lblExhaustive;
        private System.Windows.Forms.Label lblGenParams;
        private System.Windows.Forms.Label lblCountGen;
        private System.Windows.Forms.NumericUpDown nmrcCountGen;
        private System.Windows.Forms.Label lblCountChildrenInGen;
        private System.Windows.Forms.NumericUpDown nmrcCountChildren;
        private System.Windows.Forms.Label lblUseMutations;
        private System.Windows.Forms.CheckBox chBxUseMutations;
        private System.Windows.Forms.Label lblShortestPathLen;
        private System.Windows.Forms.TextBox txtBxPathLenGen;
        private System.Windows.Forms.TextBox txtBxPathLenExh;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtBxTimeGen;
        private System.Windows.Forms.TextBox txtBxTimeExh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmrcFreqMut;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label2;
    }
}

