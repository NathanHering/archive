using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveUI
{
    public class ArchiveModel
    {
        public int Id { get; set; }
        public string ArchiveName { get; set; }
        public string Description { get; set; }
        public string SourceRoot { get; set; }
        public string BackupRoot { get; set; }
        public DateTime LastRunDateTime { get; set; }
        public DateTime NextRunDateTime { get; set; }
        public bool CurrentlyRunning { get; set; }
        public bool Enabled { get; set; }
        public string Schedule { get; set; }
        public int ActionCount { get; set; }
    }

    public class ArchiveLog : IComparable<ArchiveLog>
    {
        public DateTime LogDateTime { get; set; }
        public string LogFilePath { get; set; }

        public int CompareTo(ArchiveLog otherLog)
        {
            return this.LogDateTime.CompareTo(otherLog.LogDateTime);
        }
    }
}