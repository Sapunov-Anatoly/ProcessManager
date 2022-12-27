namespace ProcessManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.processDataGridView = new System.Windows.Forms.DataGridView();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.startProcessCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopProcessCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processMemoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.processDataGridView)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // processDataGridView
            // 
            this.processDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.processDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.processIdColumn,
            this.processNameColumn,
            this.processMemoryColumn});
            this.processDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.processDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.processDataGridView.Location = new System.Drawing.Point(12, 27);
            this.processDataGridView.Name = "processDataGridView";
            this.processDataGridView.RowHeadersVisible = false;
            this.processDataGridView.Size = new System.Drawing.Size(760, 522);
            this.processDataGridView.TabIndex = 0;
            this.processDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.processDataGridView_CellDoubleClick);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mainMenuStrip.AutoSize = false;
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startProcessCheckToolStripMenuItem,
            this.stopProcessCheckToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(9, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(300, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // startProcessCheckToolStripMenuItem
            // 
            this.startProcessCheckToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.startProcessCheckToolStripMenuItem.Enabled = false;
            this.startProcessCheckToolStripMenuItem.Name = "startProcessCheckToolStripMenuItem";
            this.startProcessCheckToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.startProcessCheckToolStripMenuItem.Text = "Пуск";
            this.startProcessCheckToolStripMenuItem.Click += new System.EventHandler(this.startProcessCheckToolStripMenuItem_Click);
            // 
            // stopProcessCheckToolStripMenuItem
            // 
            this.stopProcessCheckToolStripMenuItem.BackColor = System.Drawing.Color.LightCoral;
            this.stopProcessCheckToolStripMenuItem.Name = "stopProcessCheckToolStripMenuItem";
            this.stopProcessCheckToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.stopProcessCheckToolStripMenuItem.Text = "Пауза";
            this.stopProcessCheckToolStripMenuItem.Click += new System.EventHandler(this.stopProcessCheckToolStripMenuItem_Click);
            // 
            // processIdColumn
            // 
            this.processIdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.processIdColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.processIdColumn.HeaderText = "ID";
            this.processIdColumn.Name = "processIdColumn";
            this.processIdColumn.ReadOnly = true;
            this.processIdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // processNameColumn
            // 
            this.processNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.processNameColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.processNameColumn.FillWeight = 400F;
            this.processNameColumn.HeaderText = "Имя процесса";
            this.processNameColumn.Name = "processNameColumn";
            this.processNameColumn.ReadOnly = true;
            // 
            // processMemoryColumn
            // 
            this.processMemoryColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.processMemoryColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.processMemoryColumn.HeaderText = "Память (Мб)";
            this.processMemoryColumn.Name = "processMemoryColumn";
            this.processMemoryColumn.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.processDataGridView);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.processDataGridView)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView processDataGridView;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startProcessCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopProcessCheckToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn processIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processMemoryColumn;
    }
}

