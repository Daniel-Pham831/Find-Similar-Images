namespace VNToolWF
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDuplicated = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labReadme = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labProcess = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSimilar = new System.Windows.Forms.DataGridView();
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvLarge = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeInKiloByteDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeInKiloByteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicated)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimilar)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.dgvDuplicated);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files with duplicated name";
            // 
            // dgvDuplicated
            // 
            this.dgvDuplicated.AllowUserToAddRows = false;
            this.dgvDuplicated.AllowUserToDeleteRows = false;
            this.dgvDuplicated.AllowUserToResizeColumns = false;
            this.dgvDuplicated.AllowUserToResizeRows = false;
            this.dgvDuplicated.AutoGenerateColumns = false;
            this.dgvDuplicated.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDuplicated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuplicated.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.nameDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.sizeInKiloByteDataGridViewTextBoxColumn});
            this.dgvDuplicated.DataSource = this.fileItemBindingSource;
            this.dgvDuplicated.Location = new System.Drawing.Point(6, 19);
            this.dgvDuplicated.Name = "dgvDuplicated";
            this.dgvDuplicated.ReadOnly = true;
            this.dgvDuplicated.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDuplicated.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDuplicated.Size = new System.Drawing.Size(676, 251);
            this.dgvDuplicated.TabIndex = 0;
            this.dgvDuplicated.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDuplicated_CellDoubleClick);
            this.dgvDuplicated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTable_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labReadme);
            this.groupBox4.Location = new System.Drawing.Point(697, 146);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(194, 298);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Readme";
            // 
            // labReadme
            // 
            this.labReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labReadme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labReadme.Location = new System.Drawing.Point(3, 16);
            this.labReadme.Name = "labReadme";
            this.labReadme.Size = new System.Drawing.Size(188, 279);
            this.labReadme.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labProcess);
            this.groupBox3.Location = new System.Drawing.Point(697, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 83);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // labProcess
            // 
            this.labProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.labProcess.Location = new System.Drawing.Point(3, 16);
            this.labProcess.Name = "labProcess";
            this.labProcess.Size = new System.Drawing.Size(188, 64);
            this.labProcess.TabIndex = 0;
            this.labProcess.Text = "Processing...";
            this.labProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.dgvSimilar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(0, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 320);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Similar Images";
            // 
            // dgvSimilar
            // 
            this.dgvSimilar.AllowUserToAddRows = false;
            this.dgvSimilar.AllowUserToDeleteRows = false;
            this.dgvSimilar.AllowUserToResizeColumns = false;
            this.dgvSimilar.AllowUserToResizeRows = false;
            this.dgvSimilar.AutoGenerateColumns = false;
            this.dgvSimilar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSimilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimilar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvSimilar.DataSource = this.fileItemBindingSource;
            this.dgvSimilar.Location = new System.Drawing.Point(6, 19);
            this.dgvSimilar.Name = "dgvSimilar";
            this.dgvSimilar.ReadOnly = true;
            this.dgvSimilar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSimilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSimilar.Size = new System.Drawing.Size(676, 282);
            this.dgvSimilar.TabIndex = 0;
            this.dgvSimilar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSimilar_CellDoubleClick);
            this.dgvSimilar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSimilar_KeyDown);
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOpenDialog.Location = new System.Drawing.Point(697, 12);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(194, 39);
            this.btnOpenDialog.TabIndex = 1;
            this.btnOpenDialog.Text = "Open Folder";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnOpenDialog_MouseClick);
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.dgvLarge);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox5.Location = new System.Drawing.Point(0, 573);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(688, 320);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Large Images";
            // 
            // dgvLarge
            // 
            this.dgvLarge.AllowUserToAddRows = false;
            this.dgvLarge.AllowUserToDeleteRows = false;
            this.dgvLarge.AllowUserToResizeColumns = false;
            this.dgvLarge.AllowUserToResizeRows = false;
            this.dgvLarge.AutoGenerateColumns = false;
            this.dgvLarge.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvLarge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLarge.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.groupIndexDataGridViewTextBoxColumn,
            this.sizeInKiloByteDataGridViewTextBoxColumn1,
            this.pathDataGridViewTextBoxColumn1});
            this.dgvLarge.DataSource = this.fileItemBindingSource;
            this.dgvLarge.Location = new System.Drawing.Point(6, 19);
            this.dgvLarge.Name = "dgvLarge";
            this.dgvLarge.ReadOnly = true;
            this.dgvLarge.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLarge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLarge.Size = new System.Drawing.Size(676, 282);
            this.dgvLarge.TabIndex = 0;
            this.dgvLarge.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLarge_CellDoubleClick);
            this.dgvLarge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLarge_KeyDown);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "groupIndex";
            this.Column2.HeaderText = "Group Index";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "groupIndex";
            this.Column1.HeaderText = "Group Index";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // groupIndexDataGridViewTextBoxColumn
            // 
            this.groupIndexDataGridViewTextBoxColumn.DataPropertyName = "dimensions";
            this.groupIndexDataGridViewTextBoxColumn.HeaderText = "Dimensions (WxH)";
            this.groupIndexDataGridViewTextBoxColumn.Name = "groupIndexDataGridViewTextBoxColumn";
            this.groupIndexDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupIndexDataGridViewTextBoxColumn.Width = 130;
            // 
            // sizeInKiloByteDataGridViewTextBoxColumn1
            // 
            this.sizeInKiloByteDataGridViewTextBoxColumn1.DataPropertyName = "sizeInKiloByte";
            this.sizeInKiloByteDataGridViewTextBoxColumn1.HeaderText = "Size (KB)";
            this.sizeInKiloByteDataGridViewTextBoxColumn1.Name = "sizeInKiloByteDataGridViewTextBoxColumn1";
            this.sizeInKiloByteDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // pathDataGridViewTextBoxColumn1
            // 
            this.pathDataGridViewTextBoxColumn1.DataPropertyName = "path";
            this.pathDataGridViewTextBoxColumn1.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn1.Name = "pathDataGridViewTextBoxColumn1";
            this.pathDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // fileItemBindingSource
            // 
            this.fileItemBindingSource.DataSource = typeof(VNToolWF.FileItem);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "path";
            this.dataGridViewTextBoxColumn2.HeaderText = "Path";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sizeInKiloByte";
            this.dataGridViewTextBoxColumn3.HeaderText = "Size (KB)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sizeInKiloByteDataGridViewTextBoxColumn
            // 
            this.sizeInKiloByteDataGridViewTextBoxColumn.DataPropertyName = "sizeInKiloByte";
            this.sizeInKiloByteDataGridViewTextBoxColumn.HeaderText = "Size KB";
            this.sizeInKiloByteDataGridViewTextBoxColumn.Name = "sizeInKiloByteDataGridViewTextBoxColumn";
            this.sizeInKiloByteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(901, 887);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnOpenDialog);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNTool - Find Duplicate Files";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicated)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimilar)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDuplicated;
        private System.Windows.Forms.Button btnOpenDialog;
        private System.Windows.Forms.BindingSource fileItemBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSimilar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labProcess;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labReadme;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvLarge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeInKiloByteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupIndexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeInKiloByteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn1;
    }
}

