using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLib
{
    public delegate void ActionCount(int action = 0, long bytes = 0);

    public class Archive
    {
        private string _sourceRoot { get; set; }
        private string _backupRoot { get; set; }
        public bool Stop { get; set; }
        private ActionCount _callback { get; set; }
        private Log _log { get; set; }

        public Archive() { }

        public Archive(ActionCount callback, string sourceRoot, string backupRoot, string logRoot = null)
        {
            this._callback = callback;
            this._log = new Log(logRoot);
            this._sourceRoot = sourceRoot;
            this._backupRoot = backupRoot;
        }

        public Archive(ActionCount callback, string sourceRoot, string backupRoot)
        {
            this._callback = callback;
            this._sourceRoot = sourceRoot;
            this._backupRoot = backupRoot;
        }

        #region doArchive

        public bool DoArchive()
        {
            try
            {
                bool result = false;

                if (Directory.Exists(this._sourceRoot) && Directory.Exists(this._backupRoot))
                {
                    try
                    {
                        ArchiveFolder(_sourceRoot);
                        result = true;
                    }
                    catch (Exception e)
                    {
                        this._log.AddEntry($"ERROR: {e.Message}");
                        this._log.AddEntry(e.StackTrace);
                        this._log.Close();
                    }
                }
                else
                {
                    this._log.AddEntry("Could not perform archive because source or backup directory did not exist.");
                }
                this._log.Close();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void ArchiveFolder(string sourceFolderPath)
        {
            try
            {
                if (this.Stop) return;

                string relativePath = sourceFolderPath.Substring(_sourceRoot.Length);
                if (relativePath.Length > 0) relativePath = relativePath.Substring(1);
                string sourcePath = Path.Combine(_sourceRoot, relativePath);
                string backupPath = Path.Combine(_backupRoot, relativePath);

                if (!Directory.Exists(backupPath))
                {
                    _log.AddEntry($"Directory added: {backupPath}");
                    Directory.CreateDirectory(backupPath);
                }
                else
                {
                    SyncFiles(sourcePath, backupPath);
                    SyncFolders(sourcePath, backupPath);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void SyncFiles(string sourcePath, string backupPath)
        {
            try
            {
                if (this.Stop) return;

                foreach (string backupFile in Directory.GetFiles(backupPath))
                {
                    string sourceFile = Path.Combine(sourcePath, Path.GetFileName(backupFile));
                    if (File.Exists(sourceFile))
                    {
                        var sourceWriteTime = File.GetLastWriteTime(sourceFile);
                        var backupWriteTime = File.GetLastWriteTime(backupFile);
                        if (DateTime.Compare(sourceWriteTime, backupWriteTime) > 0)
                        {
                            _log.AddEntry($"File updated: {backupFile}");
                            File.Copy(sourceFile, backupFile, true);
                        }
                    }
                    else
                    {
                        _log.AddEntry($"File deleted: {backupFile}");
                        File.Delete(backupFile);
                    }
                }

                foreach (string sourceFile in Directory.GetFiles(sourcePath))
                {
                    string backupFile = Path.Combine(backupPath, Path.GetFileName(sourceFile));
                    if (!File.Exists(backupFile))
                    {
                        _log.AddEntry($"File copied: {backupFile}");
                        File.Copy(sourceFile, backupFile);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void SyncFolders(string sourcePath, string backupPath)
        {
            try
            {
                if (this.Stop) return;

                foreach (string backupFolder in Directory.GetDirectories(backupPath))
                {
                    string relativePath = backupFolder.Substring(_backupRoot.Length + 1);
                    if (!Directory.Exists(Path.Combine(_sourceRoot, relativePath)))
                    {
                        this._callback();
                        _log.AddEntry($"Directory deleted: {backupFolder}");
                        Directory.Delete(backupFolder);
                    }
                }

                string[] sourceFolders = Directory.GetDirectories(sourcePath);
                foreach (string sourceFolder in sourceFolders)
                {
                    string relativePath = sourceFolder.Substring(_sourceRoot.Length + 1);
                    string backupFolder = Path.Combine(_backupRoot, relativePath);
                    if (!Directory.Exists(backupFolder))
                    {
                        this._callback();
                        _log.AddEntry($"Directory added: {backupFolder}");
                        Directory.CreateDirectory(backupFolder);
                    }
                }

                foreach (string sourceFolder in sourceFolders)
                {
                    ArchiveFolder(sourceFolder);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        #endregion

        #region doArchive_info

        public void DoArchive_info()
        {
            try
            {
                if (Directory.Exists(this._sourceRoot) && Directory.Exists(this._backupRoot))
                {
                    try
                    {
                        ArchiveFolder_info(_sourceRoot);
                    }
                    catch (Exception e)
                    {
                        var m = e.Message;
                    }
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
                throw;
            }
        }
        
        private void ArchiveFolder_info(string sourceFolderPath)
        {
            try
            {
                if (this.Stop) return;

                string relativePath = sourceFolderPath.Substring(_sourceRoot.Length);
                if (relativePath.Length > 0) relativePath = relativePath.Substring(1);
                string sourcePath = Path.Combine(_sourceRoot, relativePath);
                string backupPath = Path.Combine(_backupRoot, relativePath);

                if (!Directory.Exists(backupPath))
                {
                    var x = this.GetTotalDescendantFileSize(sourcePath);
                    this._callback(1, x);
                }
                else
                {
                    SyncFiles_info(sourcePath, backupPath);
                    SyncFolders_info(sourcePath, backupPath);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private long GetTotalDescendantFileSize(string dir)
        {
            try
            {
                long bytes = 0;

                if (Directory.Exists(dir))
                {
                    foreach(var folder in Directory.GetDirectories(dir))
                    {
                        bytes += GetTotalDescendantFileSize(folder);
                    }

                    foreach(var file in Directory.GetFiles(dir))
                    {
                        var info = new FileInfo(file);
                        bytes += info.Length;
                    }
                }

                return bytes;
            }
            catch (Exception e)
            {
                var message = e.Message;
                throw;
            }
        }

        private void SyncFiles_info(string sourcePath, string backupPath)
        {
            try
            {
                if (this.Stop) return;

                foreach (string backupFile in Directory.GetFiles(backupPath))
                {
                    string sourceFile = Path.Combine(sourcePath, Path.GetFileName(backupFile));
                    if (File.Exists(sourceFile))
                    {
                        var sourceWriteTime = File.GetLastWriteTime(sourceFile);
                        var backupWriteTime = File.GetLastWriteTime(backupFile);
                        if (DateTime.Compare(sourceWriteTime, backupWriteTime) > 0)
                        {
                            var info = new FileInfo(sourceFile);
                            this._callback(1, info.Length);
                        }
                    }
                    else
                    {
                        this._callback(1, 0);
                    }
                }

                foreach (string sourceFile in Directory.GetFiles(sourcePath))
                {
                    string backupFile = Path.Combine(backupPath, Path.GetFileName(sourceFile));
                    if (!File.Exists(backupFile))
                    {
                        var info = new FileInfo(sourceFile);
                        this._callback(1, info.Length);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void SyncFolders_info(string sourcePath, string backupPath)
        {
            try
            {
                if (this.Stop) return;

                foreach (string backupFolder in Directory.GetDirectories(backupPath))
                {
                    string relativePath = backupFolder.Substring(_backupRoot.Length + 1);
                    if (!Directory.Exists(Path.Combine(_sourceRoot, relativePath)))
                    {
                        this._callback(1,0);
                    }
                }

                string[] sourceFolders = Directory.GetDirectories(sourcePath);
                foreach (string sourceFolder in sourceFolders)
                {
                    string relativePath = sourceFolder.Substring(_sourceRoot.Length + 1);
                    string backupFolder = Path.Combine(_backupRoot, relativePath);
                    if (!Directory.Exists(backupFolder))
                    {
                        this._callback(1,0);
                    }
                }

                foreach (string sourceFolder in sourceFolders)
                {
                    ArchiveFolder_info(sourceFolder);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        #endregion

        public class Log
        {
            public DateTime StartTimeLocal { get; set; }
            public DateTime StartTimeUTC { get; set; }
            public DateTime EndTimeLocal { get; set; }
            public DateTime EndTimeUTC { get; set; }
            public TimeSpan Duration { get; set; }
            public int EntriesCount { get; set; }
            public List<string> Entries { get; set; }

            [JsonIgnore]
            private string _LogPath { get; set; }

            public Log() { }

            public Log(string rootPath)
            {
                try
                {
                    this._LogPath = rootPath;
                    this.StartTimeLocal = DateTime.Now;
                    this.StartTimeUTC = DateTime.UtcNow;
                    this._LogPath = GetLogPath(rootPath);
                    this.Entries = new List<string>();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            public void AddEntry(string entry)
            {
                try
                {
                    this.Entries.Add(entry);
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            public void Close()
            {
                try
                {
                    EndLog();
                    SaveLog();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            private void EndLog()
            {
                try
                {
                    this.EndTimeLocal = DateTime.Now;
                    this.EndTimeUTC = DateTime.UtcNow;
                    this.Duration = EndTimeLocal.Subtract(StartTimeLocal);
                    this.EntriesCount = this.Entries.Count;
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            private void SaveLog()
            {
                try
                {
                    string content = JsonConvert.SerializeObject(this, Formatting.Indented);
                    File.WriteAllText(_LogPath, content);
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            private string GetLogPath(string rootPath)
            {
                try
                {
                    string timeStamp = this.StartTimeLocal.ToString("yyyy_MM_dd_HH_mm_ss");
                    string name = $"ArchiveLog_{timeStamp}.json";
                    return $"{Path.Combine(rootPath, name)}";
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
    }
}
