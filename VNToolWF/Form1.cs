using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNToolWF
{
    public partial class Form1 : Form
    {
        public FileHandler FileHandler;
        public List<FileItem> DuplicatedItems;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileHandler = new FileHandler();
            // DO nothing
        }

        private void btnOpenDialog_MouseClick(object sender, MouseEventArgs e)
        {
            string path = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                FileHandler.ProcessFolder(path);

                ShowDataGridView(FileHandler.DuplicatedItems);
            }
        }

        private void ShowDataGridView(List<FileItem> duplicatedItems)
        {
            dgvTable.DataSource = duplicatedItems;

            for (int i = 0; i <= dgvTable.Columns.Count - 1; i++)
            {
                //dgvTable.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvTable.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
