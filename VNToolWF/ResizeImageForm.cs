using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNToolWF
{
    public partial class ResizeImageForm : Form
    {
        public ResizeImageForm()
        {
            InitializeComponent();
        }

        private void btnResizeAll_Click(object sender, EventArgs e)
        {

        }

        public void SetLargeDGV(List<FileItem> data)
        {
            if(dgvLarge.DataSource != data)
                dgvLarge.DataSource = data;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dgvLarge.AutoResizeColumns();
            dgvLarge.ClearSelection();

            foreach (DataGridViewRow row in dgvLarge.Rows)
            {
                row.Cells["ShouldReplace"].Value = true;
            }

            dgvLarge.Show();
        }

        private void dgvLarge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvLarge_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgvLarge_KeyPress);
            if (dgvLarge.CurrentCell.ColumnIndex == dgvLarge.Columns["TargetPercent"].Index) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgvLarge_KeyPress);
                }
            }
        }

        private void dgvLarge_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvLarge.Columns["TargetPercent"].Index)
                return;

            string targetPercent = dgvLarge.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            SetTargetDimensions(e.RowIndex, targetPercent);
        }

        private void SetTargetDimensions(int rowIndex,string targetPercentage)
        {
            try
            {
                float targetResize = float.Parse(targetPercentage);
                SetTargetDimensions(rowIndex, targetResize);
            }
            catch
            {
                MessageBox.Show("ONLY ALLOW DIGITS!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetTargetDimensions(int rowIndex, float targetPercentage)
        {
            Tuple<int, int> targetDimension = GetTargetDimensions(targetPercentage, dgvLarge.Rows[rowIndex].DataBoundItem as FileItem);
            dgvLarge.Rows[rowIndex].Cells["TargetDimensions"].Value = $"{targetDimension.Item1}x{targetDimension.Item2}";
            dgvLarge.Rows[rowIndex].Cells["TargetPercent"].Value = targetPercentage;
        }

        private Tuple<int, int> GetTargetDimensions(float targetPercent,FileItem fileItem)
        {
            targetPercent /= 100f;

            return new Tuple<int, int>((int)(fileItem.Dimensions.Item1 * targetPercent),(int)( fileItem.Dimensions.Item2 * targetPercent));
        }

        private void btnSetTargetSize_Click(object sender, EventArgs e)
        {
            try
            {
                SetTargetDimensionsForAllSelectedRows(float.Parse(txtBoxTargetResizeInput.Text));
            }
            catch
            {
                MessageBox.Show("ONLY ALLOW DIGITS!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetTargetDimensionsForAllSelectedRows(float targetResize)
        {
            foreach (DataGridViewRow row in dgvLarge.SelectedRows)
            {
                SetTargetDimensions(row.Index, targetResize);
            }
        }
    }
}
