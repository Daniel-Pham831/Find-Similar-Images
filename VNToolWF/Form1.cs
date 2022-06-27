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
        private readonly string readmeText = "Choose the correct Resource Folder." +
            "\n\nCtrl + Click or Shift + Click to select multiple files." +
            "\n\n\"Enter\" to open WinMerge Compare (maximum 3 images)." +
            "\n\n\"Delete\" to delete seleted images.";
        public FileHandler fileHandler;
        private Color color1 = Color.White;
        private Color color2 = Color.MediumAquamarine;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileHandler = new FileHandler();
            fileHandler.OnFindAllDuplicatedFinished += ShowDuplicatedDGV;
            fileHandler.OnFindAllLargeImagesFinished += ShowLargeImagesDGV;
            fileHandler.OnNewSimilarAdded += ShowSimilarDGV;
            fileHandler.OnFindAllSimilarFinished += OnProcessSimilarImagesCompleted;
            SetLabelText(ref labProcess,"");
            SetLabelText(ref labReadme, readmeText);
        }

        private void ShowLargeImagesDGV()
        {
            ShowDataGridView(ref dgvLarge, fileHandler.LargeItems);
            ChangeDGVGroupColor(ref dgvLarge);
        }

        private void OnProcessSimilarImagesCompleted()
        {
            Invoke((Action)delegate {
                SetLabelText(ref labProcess, "Done!");
            });
        }

        private void SetLabelText(ref Label label,string text)
        {
            label.Text = text;
            label.Refresh();
        }

        private void ShowSimilarDGV()
        {
            Invoke((Action)delegate {
                ShowDataGridView(ref dgvSimilar, fileHandler.SimilarImages);
                ChangeDGVGroupColor(ref dgvSimilar);
            });
        }

        private void ShowDuplicatedDGV()
        {
            ShowDataGridView(ref dgvDuplicated, fileHandler.DuplicatedItems);
            ChangeDGVGroupColor(ref dgvDuplicated);
        }

        private void btnOpenDialog_MouseClick(object sender, MouseEventArgs e)
        {
            string path = "";

            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    path = dialog.FileName;
                    SetLabelText(ref labProcess, "Processing...");
                    fileHandler.ProcessFolder(path);
                }
            }
        }

        private void ShowDataGridView(ref DataGridView dgvToShow, List<FileItem> dataToShow)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataToShow;
            dgvToShow.DataSource = bs;

            dgvToShow.AutoResizeColumns();
            dgvToShow.ClearSelection();
        }

        private void ChangeDGVGroupColor(ref DataGridView dgv)
        {
            int currentGroupIndex = -1;
            bool shouldChangeColor = false;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                FileItem currentFileItem = row.DataBoundItem as FileItem;
                if(currentGroupIndex != currentFileItem.groupIndex)
                {
                    shouldChangeColor = !shouldChangeColor;
                    currentGroupIndex = currentFileItem.groupIndex;
                }

                row.DefaultCellStyle.BackColor = shouldChangeColor ? color1 : color2;
            }

            dgv.Refresh();
            dgv.AutoResizeColumns();
        }

        private void dgvTable_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyEvents(dgvDuplicated, e);
        }

        private void dgvSimilar_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyEvents(dgvSimilar, e);
        }

        private void dgvLarge_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyEvents(dgvLarge, e);
        }

        private void HandleKeyEvents(DataGridView dgv, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (IsAnyRowSeleted(dgv))
                    {
                        DialogResult d = MessageBox.Show("Are you sure that you want to delete these?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (d == DialogResult.Yes)
                        {
                            DeleteSeletedRow(ref dgv);
                        }
                    }
                    break;

                case Keys.Enter:
                    if (IsAnyRowSeleted(dgv))
                    {
                        List<FileItem> selectedFileItems = GetAllSelectedFileItems(dgv);
                        List<string> fullPaths = FileItem.GetAllPaths(selectedFileItems);

                        CommandHandler.ExecuteWinMergeCommand(fullPaths);
                    }
                    break;
            }
        }

        private void DeleteSeletedRow(ref DataGridView dgv)
        {
            List<FileItem> selectedFileItems = GetAllSelectedFileItems(dgv);

            List<string> shouldDeletedFilePaths = FileItem.GetAllPaths(selectedFileItems);

            foreach (var path in shouldDeletedFilePaths)
            {
                File.Delete(path);
            }

            foreach (DataGridViewRow item in dgv.SelectedRows)
            {
                dgv.Rows.RemoveAt(item.Index);
            }
        }

        private List<FileItem> GetAllSelectedFileItems(DataGridView dgv)
        {
            List<FileItem> selectedFileItems = new List<FileItem>();

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                selectedFileItems.Add(row.DataBoundItem as FileItem);
            }

            return selectedFileItems;
        }

        private bool IsAnyRowSeleted(DataGridView dgv)
        {
            return dgv.SelectedRows.Count != 0;
        }

        private void dgvDuplicated_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDGVDoubleClicked(sender as DataGridView, e.RowIndex, fileHandler.DuplicatedGroups);
        }

        private void dgvSimilar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDGVDoubleClicked(sender as DataGridView, e.RowIndex, fileHandler.SimilarGroups);
        }
        private void dgvLarge_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDGVDoubleClicked(sender as DataGridView, e.RowIndex, fileHandler.LargeGroups);
        }

        private void OnDGVDoubleClicked(DataGridView dgv,int rowIndex,List<List<string>> itemGroups)
        {
            FileItem fileItem = dgv.Rows[rowIndex].DataBoundItem as FileItem;

            CommandHandler.ExecuteWinMergeCommand(itemGroups[fileItem.groupIndex]);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            dgvDuplicated.ClearSelection();
            dgvSimilar.ClearSelection();
            dgvLarge.ClearSelection();
        }
    }
}
