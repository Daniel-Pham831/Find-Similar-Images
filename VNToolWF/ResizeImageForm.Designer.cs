namespace VNToolWF
{
    partial class ResizeImageForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLarge = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dimensionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetDimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShouldReplace = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnResizeAll = new System.Windows.Forms.Button();
            this.txtBoxTargetResizeInput = new System.Windows.Forms.TextBox();
            this.btnSetTargetSize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labReadme = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileItemBindingSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.dgvLarge);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 431);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Large Images";
            // 
            // dgvLarge
            // 
            this.dgvLarge.AllowUserToDeleteRows = false;
            this.dgvLarge.AllowUserToResizeColumns = false;
            this.dgvLarge.AllowUserToResizeRows = false;
            this.dgvLarge.AutoGenerateColumns = false;
            this.dgvLarge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLarge.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvLarge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLarge.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.dimensionsDataGridViewTextBoxColumn,
            this.TargetPercent,
            this.TargetDimensions,
            this.ShouldReplace,
            this.pathDataGridViewTextBoxColumn});
            this.dgvLarge.DataSource = this.fileItemBindingSource;
            this.dgvLarge.Location = new System.Drawing.Point(6, 19);
            this.dgvLarge.Name = "dgvLarge";
            this.dgvLarge.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLarge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLarge.Size = new System.Drawing.Size(691, 393);
            this.dgvLarge.TabIndex = 0;
            this.dgvLarge.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLarge_CellDoubleClick);
            this.dgvLarge.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLarge_CellEndEdit);
            this.dgvLarge.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvLarge_EditingControlShowing);
            this.dgvLarge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // dimensionsDataGridViewTextBoxColumn
            // 
            this.dimensionsDataGridViewTextBoxColumn.DataPropertyName = "dimensions";
            this.dimensionsDataGridViewTextBoxColumn.HeaderText = "Current Dimensions (W x H)";
            this.dimensionsDataGridViewTextBoxColumn.Name = "dimensionsDataGridViewTextBoxColumn";
            this.dimensionsDataGridViewTextBoxColumn.ReadOnly = true;
            this.dimensionsDataGridViewTextBoxColumn.Width = 135;
            // 
            // TargetPercent
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.TargetPercent.DefaultCellStyle = dataGridViewCellStyle3;
            this.TargetPercent.HeaderText = "Target Resize In Percent (%)";
            this.TargetPercent.MaxInputLength = 3;
            this.TargetPercent.Name = "TargetPercent";
            this.TargetPercent.ToolTipText = "Range from 0 - 100";
            this.TargetPercent.Width = 104;
            // 
            // TargetDimensions
            // 
            this.TargetDimensions.HeaderText = "Target Dimensions (W x H)";
            this.TargetDimensions.Name = "TargetDimensions";
            this.TargetDimensions.ReadOnly = true;
            this.TargetDimensions.Width = 133;
            // 
            // ShouldReplace
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "False";
            this.ShouldReplace.DefaultCellStyle = dataGridViewCellStyle4;
            this.ShouldReplace.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ShouldReplace.HeaderText = "Replace?";
            this.ShouldReplace.Name = "ShouldReplace";
            this.ShouldReplace.ToolTipText = "Replace the old image with the resized image";
            this.ShouldReplace.Width = 59;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            this.pathDataGridViewTextBoxColumn.Width = 54;
            // 
            // fileItemBindingSource
            // 
            this.fileItemBindingSource.DataSource = typeof(VNToolWF.FileItem);
            // 
            // btnResizeAll
            // 
            this.btnResizeAll.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResizeAll.Location = new System.Drawing.Point(721, 31);
            this.btnResizeAll.Name = "btnResizeAll";
            this.btnResizeAll.Size = new System.Drawing.Size(189, 60);
            this.btnResizeAll.TabIndex = 2;
            this.btnResizeAll.Text = "Resize ALL Images";
            this.btnResizeAll.UseVisualStyleBackColor = true;
            this.btnResizeAll.Click += new System.EventHandler(this.btnResizeAll_Click);
            // 
            // txtBoxTargetResizeInput
            // 
            this.txtBoxTargetResizeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.txtBoxTargetResizeInput.Location = new System.Drawing.Point(721, 133);
            this.txtBoxTargetResizeInput.MaxLength = 3;
            this.txtBoxTargetResizeInput.Name = "txtBoxTargetResizeInput";
            this.txtBoxTargetResizeInput.Size = new System.Drawing.Size(93, 31);
            this.txtBoxTargetResizeInput.TabIndex = 4;
            this.txtBoxTargetResizeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSetTargetSize
            // 
            this.btnSetTargetSize.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSetTargetSize.Location = new System.Drawing.Point(820, 133);
            this.btnSetTargetSize.Name = "btnSetTargetSize";
            this.btnSetTargetSize.Size = new System.Drawing.Size(90, 31);
            this.btnSetTargetSize.TabIndex = 5;
            this.btnSetTargetSize.Text = "Set ";
            this.btnSetTargetSize.UseVisualStyleBackColor = true;
            this.btnSetTargetSize.Click += new System.EventHandler(this.btnSetTargetSize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.Location = new System.Drawing.Point(728, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select images\r\nEnter the target size (in percentage)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labReadme);
            this.groupBox4.Location = new System.Drawing.Point(721, 170);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(194, 273);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Readme";
            // 
            // labReadme
            // 
            this.labReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labReadme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labReadme.Location = new System.Drawing.Point(3, 16);
            this.labReadme.Name = "labReadme";
            this.labReadme.Size = new System.Drawing.Size(188, 254);
            this.labReadme.TabIndex = 0;
            this.labReadme.Text = "Choose your desire \"Target Resize In Percent\" for each image.\r\n\r\nTarget Resize In" +
    " Percent = 100% means will stay the same.\r\n";
            // 
            // ResizeImageForm
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetTargetSize);
            this.Controls.Add(this.txtBoxTargetResizeInput);
            this.Controls.Add(this.btnResizeAll);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResizeImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Resizer";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileItemBindingSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLarge;
        private System.Windows.Forms.BindingSource fileItemBindingSource;
        private System.Windows.Forms.Button btnResizeAll;
        private System.Windows.Forms.TextBox txtBoxTargetResizeInput;
        private System.Windows.Forms.Button btnSetTargetSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dimensionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetDimensions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShouldReplace;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labReadme;
    }
}