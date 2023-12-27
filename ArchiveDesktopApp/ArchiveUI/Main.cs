using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ArchiveLib;

namespace ArchiveUI
{
    public partial class Main : Form
    {
        private List<ArchiveModel> _archives { get; set; }
        private ArchiveModel _selectedArchive { get; set; }
        private List<ArchiveLog> _logs { get; set; }
        private Archive _archive { get; set; }
        private bool _isNewArchive { get; set; }
        private bool _stop { get; set; }
        private int _selectedArchiveActionCount { get; set; }
        private long _selectedArchiveByteCount { get; set; }
        private bool _updateCountMessage { get; set; }

        public Main()
        {
            InitializeComponent();

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Logs")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Logs"));
            }

            this._stop = false;
            StopButton.Enabled = false;
            StopButton.Visible = false;
            LoadArchives();
            DisableArchiveDetails();
        }

        #region TAB Archives

        private void LoadArchives()
        {
            //https://www.akadia.com/services/dotnet_listview_sort_dataset.html
            _archives = DAL.GetArchives();
            ArchivesListView.Items.Clear();
            foreach (ArchiveModel archive in _archives)
            {
                var item = new ListViewItem(archive.ArchiveName);
                item.Tag = archive;
                var lastRun = archive.LastRunDateTime == DateTime.MinValue ? "n/a" : archive.LastRunDateTime.ToString();
                item.SubItems.Add(lastRun);
                var nextRun = archive.NextRunDateTime == DateTime.MinValue ? "n/a" : archive.NextRunDateTime.ToString();
                item.SubItems.Add(nextRun);
                var enabled = archive.Enabled ? "TRUE" : "FALSE";
                item.SubItems.Add(enabled);
                ArchivesListView.Items.Add(item);
            }
            _isNewArchive = true;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
            ClearArchiveDetails();
            DisableArchiveDetails();
            ClearLogs();
        }

        #endregion

        #region TAB Details

        private void ClearArchiveDetails()
        {
            det_ArchiveName.Clear();
            det_Description.Clear();
            det_Source.Clear();
            det_Backup.Clear();
            det_Enabled.SelectedIndex = 0;
            det_Schedule.Clear();
        }

        private bool DetailsAreValid()
        {
            bool result = false;

            if (!string.IsNullOrEmpty(det_ArchiveName.Text) &&
                (det_Source.Text != det_Backup.Text))
            {
                result = true;
            }

            return result;
        }

        private void DisableArchiveDetails()
        {
            SaveButton.Enabled = false;
            CancelButton.Enabled = false;
            det_ArchiveName.Enabled = false;
            det_Description.Enabled = false;
            det_Source.Enabled = false;
            det_Backup.Enabled = false;
            det_Enabled.Enabled = false;
            det_Schedule.Enabled = false;
        }

        private void EnableArchiveDetails()
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
            det_ArchiveName.Enabled = true;
            det_Description.Enabled = true;
            det_Source.Enabled = true;
            det_Backup.Enabled = true;
            det_Enabled.Enabled = true;
            det_Schedule.Enabled = true;
        }

        private void LoadArchiveDetails()
        {
            det_ArchiveName.Text = _selectedArchive.ArchiveName;
            det_Description.Text = _selectedArchive.Description;
            det_Source.Text = _selectedArchive.SourceRoot;
            det_Backup.Text = _selectedArchive.BackupRoot;
            det_Enabled.SelectedIndex = _selectedArchive.Enabled ? 0 : 1;
            det_Schedule.Text = _selectedArchive.Schedule;
            det_ActionCount.Text = _selectedArchive.ActionCount.ToString();
        }

        private void CountUp(int action = 0, long bytes = 0)
        {
            this._selectedArchiveActionCount += action;
            this._selectedArchiveByteCount += bytes;
            if (this._updateCountMessage)
            {
                UpdateCountDetails();
            }
        }

        private void CountDown(int action = 0, long bytes = 0)
        {
            this._selectedArchiveActionCount -= action;
            this._selectedArchiveByteCount -= bytes;
            UpdateCountDetails();
        }

        private void UpdateCountDetails()
        {
            try
            {
                det_ActionCount.Text = $"Actions: {this._selectedArchiveActionCount.ToString()} Data to be copied: {this.GetSizeString(this._selectedArchiveByteCount)}";
                det_ActionCount.Refresh();

                if (this._stop)
                {
                    this._archive.Stop = true;
                    this._stop = false;
                    StopButton.Enabled = false;
                    StopButton.Visible = false;
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
                throw;
            }
        }

        private string GetSizeString(long size)
        {
            string b = "";
            string k = "";
            string m = "";
            string g = "";
            string t = "";

            long bytes = size;
            long kilobytes = 0;
            long megabytes = 0;
            long gigabytes = 0;
            long terabytes = 0;

            b = $"{bytes.ToString()} bytes";
            if (bytes > 1000)
            {
                var kb = bytes / 1000;
                bytes -= kb * 1000;
                b = $"{bytes.ToString()} bytes";
                kilobytes += kb;
                k = $"{kilobytes.ToString()} kB, ";
                if (kilobytes > 1000)
                {
                    var mb = kilobytes / 1000;
                    kilobytes -= mb * 1000;
                    k = $"{kilobytes.ToString()} kB, ";
                    megabytes += mb;
                    m = $"{megabytes.ToString()} MB, ";
                    if (megabytes > 1000)
                    {
                        var gb = megabytes / 1000;
                        megabytes -= gb * 1000;
                        m = $"{megabytes.ToString()} MB, ";
                        gigabytes += gb;
                        g = $"{gigabytes.ToString()} GB, ";
                        if (gigabytes > 1000)
                        {
                            var tb = gigabytes / 1000;
                            gigabytes -= tb * 1000;
                            g = $"{gigabytes.ToString()} GB, ";
                            terabytes += tb;
                            t = $"{terabytes.ToString()} TB, ";
                        }
                    }
                }
            }
            return $"{t}{g}{m}{k}{b}";
        }

        #endregion

        #region TAB Logs

        private void LoadLogs(ArchiveModel archive)
        {
            this._logs = new List<ArchiveLog>();
            this._logs = DAL.GetLogs(archive);
            _logs.Reverse();
            foreach (ArchiveLog log in _logs)
            {
                var dt = log.LogDateTime;
                var text = dt.ToString("yyyy/MM/dd HH:mm:ss");
                var item = new ListViewItem(text);
                item.ToolTipText = $"{dt.ToLongDateString()} {dt.ToLongTimeString()}";
                item.Tag = log;
                LogsListView.Items.Add(item);
            }
        }

        private void ClearLogs()
        {
            LogsListView.Items.Clear();
            LogTextBox.Text = "";
        }

        #endregion

        #region UI Events

        private void ArchiveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearArchiveDetails();
            var list = (ListView)sender;
            if (list.SelectedItems.Count > 0)
            {
                var item = list.SelectedItems[0];
                _selectedArchive = (ArchiveModel)item.Tag;
                lblSelected.Text = item.Text;
                _isNewArchive = false;
                LoadLogs(_selectedArchive);
                EnableArchiveDetails();
                LoadArchiveDetails();
                EditButton.Enabled = true;
                DeleteButton.Enabled = true;
            }
            else
            {
                _logs = new List<ArchiveLog>();
                LogsListView.Items.Clear();
                _selectedArchive = new ArchiveModel();
                _isNewArchive = true;
                lblSelected.Text = "";
                DisableArchiveDetails();
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }

        private void SelectSource_FocusLeave(object sender, EventArgs e)
        {
            if (this.det_Source.Text == this.det_Backup.Text && this.det_Source.Text != "")
            {
                MessageBox.Show("Source and Backup may not be the same.", "ERROR");
                this.det_Source.Text = string.Empty;
            }
            if (!Directory.Exists(this.det_Source.Text) && this.det_Source.Text != "")
            {
                MessageBox.Show("Invalid directory.", "ERROR");
                this.det_Source.Text = string.Empty;
            }
        }

        private void SelectBackup_FocusLeave(object sender, EventArgs e)
        {
            if (this.det_Source.Text == this.det_Backup.Text && this.det_Backup.Text != "")
            {
                MessageBox.Show("Source and Backup may not be the same.", "ERROR");
                this.det_Backup.Text = string.Empty;
            }
            if (!Directory.Exists(this.det_Backup.Text) && this.det_Backup.Text != "")
            {
                MessageBox.Show("Invalid directory.", "ERROR");
                this.det_Backup.Text = string.Empty;
            }
        }

        private void SelectSource_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.Description = "Select Source Folder";
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.folderBrowserDialog1.SelectedPath == this.det_Backup.Text)
                {
                    MessageBox.Show("Source and Backup may not be the same.", "ERROR");
                    this.det_Source.Text = string.Empty;
                }
                else
                {
                    this.det_Source.Text = this.folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void SelectBackup_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.Description = "Select Backup Folder";
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.folderBrowserDialog1.SelectedPath == this.det_Source.Text)
                {
                    MessageBox.Show("Source and Backup may not be the same.", "ERROR");
                    this.det_Backup.Text = string.Empty;
                }
                else
                {
                    this.det_Backup.Text = this.folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!DetailsAreValid())
            {
                MessageBox.Show("Inputs for Archive are not valid");
                return;
            }

            if (this._isNewArchive)
            {
                DAL.UpdateLogDirectory(det_ArchiveName.Text, "");
                this._selectedArchive = new ArchiveModel()
                {
                    ArchiveName = det_ArchiveName.Text,
                    Description = det_Description.Text,
                    SourceRoot = det_Source.Text,
                    BackupRoot = det_Backup.Text,
                    Enabled = det_Enabled.SelectedIndex == 1 ? false : true,
                    Schedule = det_Schedule.Text,
                    ActionCount = 0
                };
                DAL.NewArchive(this._selectedArchive);
                this._selectedArchive = DAL.GetArchive();
            }
            else
            {
                if (_selectedArchive.ArchiveName != det_ArchiveName.Text)
                {
                    DAL.UpdateLogDirectory(_selectedArchive.ArchiveName, det_ArchiveName.Text);
                }
                this._selectedArchive.ArchiveName = det_ArchiveName.Text;
                this._selectedArchive.Description = det_Description.Text;
                this._selectedArchive.SourceRoot = det_Source.Text;
                this._selectedArchive.BackupRoot = det_Backup.Text;
                this._selectedArchive.Enabled = det_Enabled.SelectedIndex == 1 ? false : true;
                this._selectedArchive.Schedule = det_Schedule.Text;
                this._selectedArchive.ActionCount = 0;
                DAL.UpdateArchive(this._selectedArchive);
            }
            LoadArchives();
            TabControls.SelectedIndex = 0;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            ClearArchiveDetails();
            EnableArchiveDetails();
            _selectedArchive = new ArchiveModel();
            _isNewArchive = true;
            TabControls.SelectedIndex = 1;
            lblSelected.Text = "";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ClearArchiveDetails();
            DisableArchiveDetails();
            _selectedArchive = new ArchiveModel();
            TabControls.SelectedIndex = 0;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            this._stop = false;
            StopButton.Enabled = true;
            StopButton.Visible = true;
            //string curDir = Directory.GetCurrentDirectory();
            //for (int i = 0; i < ArchivesListView.Items.Count; i++)
            //{
            //    ArchiveModel item = (ArchiveModel)ArchivesListView.Items[i].Tag;
            //    if (item.Enabled)
            //    {
            //        string logPath = Path.Combine(curDir, "Logs", item.ArchiveName.Trim());
            //        Archive archive = new Archive(item.SourceRoot, item.BackupRoot, logPath);
            //        if (archive.DoArchive())
            //        {
            //            item.LastRunDateTime = DateTime.Now;
            //            DAL.UpdateArchive(item);
            //        }
            //    }
            //}
            //LoadArchives();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this.SaveButton.Visible = false;
            this.SaveButton.Refresh();

            this._archive.Stop = true;
            this._stop = false;
            StopButton.Enabled = false;
            StopButton.Visible = false;
            StopButton.Refresh();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            TabControls.SelectedIndex = 1;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DAL.DeleteArchive(_selectedArchive);
            DAL.DeleteLogs(_selectedArchive);
            LoadArchives();
        }

        private void LogsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            if (list.SelectedItems.Count > 0)
            {
                ArchiveLog log = (ArchiveLog)list.SelectedItems[0].Tag;
                LogTextBox.Text = DAL.GetLog(log.LogFilePath);
            }
            else
            {
                LogTextBox.Text = "";
            }
        }

        private void TabControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControls.SelectedIndex == 0)
            {
                if (_selectedArchive != null)
                {
                    for (int i = 0; i < ArchivesListView.Items.Count; i++)
                    {
                        var arc = (ArchiveModel)ArchivesListView.Items[i].Tag;
                        if (arc.Id == _selectedArchive.Id)
                        {
                            ArchivesListView.Items[i].Selected = true;
                        }
                        else
                        {
                            ArchivesListView.Items[i].Selected = false;
                        }
                    }
                }
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {

            try
            {
                this._stop = false;
                StopButton.Enabled = true;
                StopButton.Visible = true;
                StopButton.Refresh();

                this._selectedArchiveActionCount = 0;
                this._selectedArchiveByteCount = 0;
                det_ActionCount.Text = "0";
                det_ActionCount.Refresh();
                this._archive = new Archive(this.CountUp, _selectedArchive.SourceRoot, _selectedArchive.BackupRoot);
                this._archive.DoArchive_info();

                this._stop = false;
                StopButton.Enabled = false;
                StopButton.Visible = false;
                StopButton.Refresh();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }

        private void RunArchiveButton_Click(object sender, EventArgs e)
        {
            this._stop = false;
            StopButton.Enabled = true;
            StopButton.Visible = true;
            StopButton.Refresh();

            var item = this._selectedArchive;
            string curDir = Directory.GetCurrentDirectory();
            string logPath = Path.Combine(curDir, "Logs", item.ArchiveName.Trim());

            this._updateCountMessage = true;
            this._selectedArchiveActionCount = 0;
            this._selectedArchiveByteCount = 0;
            this._archive = new Archive(this.CountUp, item.SourceRoot, item.BackupRoot);
            this._archive.DoArchive_info();
            this._updateCountMessage = false;

            this._archive = new Archive(this.CountDown, item.SourceRoot, item.BackupRoot, logPath);
            if (this._archive.DoArchive())
            {
                item.LastRunDateTime = DateTime.Now;
                DAL.UpdateArchive(item);
            }

            this._stop = false;
            StopButton.Enabled = false;
            StopButton.Visible = false;
            StopButton.Refresh();
        }

        #endregion
    }
}