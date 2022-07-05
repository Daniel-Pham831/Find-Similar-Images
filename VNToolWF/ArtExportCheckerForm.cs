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
    public partial class ArtExportCheckerForm : Form
    {
        private readonly string readmeText = "Choose the correct Resource Folder." +
            "\n\nCtrl + Click or Shift + Click to select multiple files." +
            "\n\n\"Enter\" to open WinMerge Compare (maximum 3 images)." +
            "\n\n\"Delete\" to delete seleted images." +
            "\n\nRight click to ignore the folder path." +
            "\n\nOpen dirIgnore.txt if you want to modify ignore by yourself.";
        public FileHandler fileHandler;
        private FileItem currentSelectedData;

        // Forms
        private ResizeImageForm resizerForm;

        public ArtExportCheckerForm()
        {
            InitializeComponent();
        }

        private void ArtExportChecker_Load(object sender, EventArgs e)
        {
            fileHandler = new FileHandler();
            fileHandler.OnFindAllDuplicatedFinished += ShowDuplicatedDGV;
            fileHandler.OnFindAllLargeImagesFinished += ShowLargeImagesDGV;
            fileHandler.OnNewSimilarAdded += ShowSimilarDGV;
            fileHandler.OnFindAllSimilarFinished += OnProcessSimilarImagesCompleted;
            SetLabelText(ref labProcess,"");
            SetLabelText(ref labReadme, readmeText);

            currentSelectedData = null;
        }

        private void ShowLargeImagesDGV()
        {
            DGVUtils.ShowDataGridView(ref dgvLarge, fileHandler.LargeItems);
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
                DGVUtils.ShowDataGridView(ref dgvSimilar, fileHandler.SimilarImages);
                DGVUtils.ChangeDGVGroupColor(ref dgvSimilar);
            });
        }

        private void ShowDuplicatedDGV()
        {
            DGVUtils.ShowDataGridView(ref dgvDuplicated, fileHandler.DuplicatedItems);
            DGVUtils.ChangeDGVGroupColor(ref dgvDuplicated);
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
                    DGVUtils.ClearAllData(dgvDuplicated);
                    DGVUtils.ClearAllData(dgvSimilar);
                    DGVUtils.ClearAllData(dgvLarge);

                    fileHandler.ProcessFolder(path);
                }
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            DGVUtils.HandleKeyEvents(sender as DataGridView, e);
        }

        private void dgvDuplicated_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVUtils.OpenWinMergeCompare(sender as DataGridView, e.RowIndex, fileHandler.DuplicatedGroups);
        }

        private void dgvSimilar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVUtils.OpenWinMergeCompare(sender as DataGridView, e.RowIndex, fileHandler.SimilarGroups);
        }

        private void dgvLarge_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVUtils.OpenWinMergeCompare(sender as DataGridView, e.RowIndex, fileHandler.LargeGroups);
        }

        private void ArtExportChecker_Click(object sender, EventArgs e)
        {
            dgvDuplicated.ClearSelection();
            dgvSimilar.ClearSelection();
            dgvLarge.ClearSelection();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                showcmsIgnoreOnDVG(sender as DataGridView, e);
            }
        }

        private void showcmsIgnoreOnDVG(DataGridView dgv, MouseEventArgs e)
        {
            currentSelectedData = null;
            var hti = dgv.HitTest(e.X, e.Y);

            if (hti.RowIndex != -1)
            {
                dgv.ClearSelection();
                dgv.Rows[hti.RowIndex].Selected = true;
                dgv.CurrentCell = dgv.Rows[hti.RowIndex].Cells[0];
                currentSelectedData = dgv.Rows[hti.RowIndex].DataBoundItem as FileItem;

                cmsIgnore.Show(dgv, new Point(e.X, e.Y));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fileHandler.IgnoreFolder(currentSelectedData.path);
        }

        private void btnOpenResizer_MouseClick(object sender, MouseEventArgs e)
        {
            List<FileItem> data = dgvLarge.DataSource as List<FileItem>;

            if (data != null)
            {
                resizerForm = new ResizeImageForm(fileHandler,this);
                resizerForm.SetLargeDGV(data,fileHandler);
                resizerForm.Show();
            }
            else
            {
                MessageBox.Show("There are no large images", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
