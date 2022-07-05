using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNToolWF
{
    internal static class DGVUtils
    {
        private static Color groupColor1 = Color.White;
        private static Color groupColor2 = Color.CadetBlue;

        public static void OpenWinMergeCompare(DataGridView dgv, int rowIndex, List<List<string>> itemGroups)
        {
            FileItem fileItem = dgv.Rows[rowIndex].DataBoundItem as FileItem;

            CommandHandler.ExecuteWinMergeCommand(itemGroups[fileItem.groupIndex]);
        }

        public static void ClearAllData(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Refresh();
        }

        public static void HandleKeyEvents(DataGridView dgv, KeyEventArgs e)
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

        public static bool IsAnyRowSeleted(DataGridView dgv)
        {
            return dgv.SelectedRows.Count != 0;
        }

        public static void DeleteSeletedRow(ref DataGridView dgv)
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

        public static List<FileItem> GetAllSelectedFileItems(DataGridView dgv)
        {
            List<FileItem> selectedFileItems = new List<FileItem>();

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                selectedFileItems.Add(row.DataBoundItem as FileItem);
            }

            return selectedFileItems;
        }

        public static void ChangeDGVGroupColor(ref DataGridView dgv)
        {
            int currentGroupIndex = -1;
            bool shouldChangeColor = false;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                FileItem currentFileItem = row.DataBoundItem as FileItem;
                if (currentGroupIndex != currentFileItem.groupIndex)
                {
                    shouldChangeColor = !shouldChangeColor;
                    currentGroupIndex = currentFileItem.groupIndex;
                }

                row.DefaultCellStyle.BackColor = shouldChangeColor ? groupColor1 : groupColor2;
            }

            dgv.Refresh();
            dgv.AutoResizeColumns();
        }

        public static void ShowDataGridView(ref DataGridView dgvToShow, List<FileItem> dataToShow)
        {
            dgvToShow.DataSource = dataToShow;

            dgvToShow.AutoResizeColumns();
            dgvToShow.ClearSelection();
        }

        public static void UpdateDGVData(ref DataGridView dgv)
        {
            List<FileItem> newDataToShow = new List<FileItem>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                FileItem newFileItem = new FileItem((row.DataBoundItem as FileItem).path);
                newDataToShow.Add(newFileItem);
            }

            ShowDataGridView(ref dgv, newDataToShow);
        }
    }
}
