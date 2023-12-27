using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ArchiveUI
{
    public class AppConfig
    {
        public class ConnectionStrings
        {
            private static string _archiveDb { get; set; }
            public static string ArchiveDb
            {
                get
                {
                    if (_archiveDb == null)
                    {
                        _archiveDb = ConfigurationManager.ConnectionStrings["ArchiveDb"].ConnectionString;
                    }
                    return _archiveDb;
                }
            }
        }
    }
}
