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

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            FileItem fileItem = GetCorrectFileNameFromDataGridViewRow(rowIndex);

            List<string> filePaths = FileHandler.GetFilePathsFromFileNames(fileItem.name);

            string winMergePath = @"C:\Program Files (x86)\WinMerge\WinMergeU.exe";

            ExecuteCommand(winMergePath, filePaths);
        }

        static void ExecuteCommand(string toolPath, List<string> arguments)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";

            toolPath = "\"" + toolPath + "\"";
            string paths = "";
            foreach (var argument in arguments)
            {
                paths += "\"" + argument + "\" ";
            }

            string command = "/C " + "\"" + toolPath + " " + paths + "\"" ;
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();

            process.WaitForExit();
        }


        private FileItem GetCorrectFileNameFromDataGridViewRow(int rowIndex)
        {
            DataGridViewRow row = dgvTable.Rows[rowIndex];

            while((row.DataBoundItem as FileItem).name == "")
            {
                row = dgvTable.Rows[--rowIndex];
                if (rowIndex < 0)
                    return null;
            }

            return (row.DataBoundItem as FileItem);
        }
    }
}
