using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace VNToolWF
{
    public partial class Form1 : Form
    {
        public FileHandler FileHandler;

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

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = dialog.FileName;
                FileHandler.ProcessFolder(path);
                ShowDataGridView(FileHandler.DuplicatedItems);
            }

        }

        private void ShowDataGridView(List<FileItem> duplicatedItems)
        {
            dgvTable.DataSource = duplicatedItems;

            dgvTable.AutoResizeColumns();
        }

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1) return;

            FileItem fileItem = GetCorrectFileNameFromDataGridViewRow(rowIndex);
            List<string> filePaths = FileHandler.GetFilePathsFromFileNames(fileItem.name);

            CommandHandler.ExecuteCommand(filePaths);
        }

        private FileItem GetCorrectFileNameFromDataGridViewRow(int rowIndex)
        {
            DataGridViewRow row = dgvTable.Rows[rowIndex];

            while ((row.DataBoundItem as FileItem).name == "")
            {
                row = dgvTable.Rows[--rowIndex];
                if (rowIndex < 0)
                    return null;
            }

            return (row.DataBoundItem as FileItem);
        }

        private void dgvTable_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (IsAnyRowSeleted())
                {
                    DialogResult d = MessageBox.Show("Are you sure that you want to delete these?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        DeleteSeletedRow();
                    }
                }
            }
        }

        private void DeleteSeletedRow()
        {
            List<FileItem> selectedFileItems = GetAllSelectedFileItems();

            List<string> shouldDeletedFilePaths = FileItem.GetAllPaths(selectedFileItems);

            foreach (var path in shouldDeletedFilePaths)
            {
                File.Delete(FileHandler.GetFullPath(path));
            }

            FileHandler.ProcessFolder();
            ShowDataGridView(FileHandler.DuplicatedItems);
        }

        private List<FileItem> GetAllSelectedFileItems()
        {
            List<FileItem> selectedFileItems = new List<FileItem>();

            for (int i = 0; i < dgvTable.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvTable.Columns.Count - 1; j++)
                {
                    if (dgvTable.Rows[i].Cells[j].Selected)
                    {
                        selectedFileItems.Add(dgvTable.Rows[i].DataBoundItem as FileItem);
                        break;
                    }
                }
            }

            return selectedFileItems;
        }

        private bool IsAnyRowSeleted()
        {
            for (int i = 0; i < dgvTable.Rows.Count -1; i++)
            {
                if (dgvTable.Rows[i].Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Selected) != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
