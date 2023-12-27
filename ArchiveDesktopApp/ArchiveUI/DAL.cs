using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveUI
{
    public class DAL
    {
        public static List<ArchiveModel> GetArchives()
        {
            try
            {
                List<ArchiveModel> result = new List<ArchiveModel>();
                using (IDbConnection db = new SQLiteConnection(AppConfig.ConnectionStrings.ArchiveDb))
                {
                    result = db.Query<ArchiveModel>(
                        "SELECT * " +
                        "FROM archive").ToList();
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public static ArchiveModel GetArchive(int id)
        {
            ArchiveModel archive = new ArchiveModel();
            using (IDbConnection db = new SQLiteConnection(AppConfig.ConnectionStrings.ArchiveDb))
            {
                archive = db.QuerySingle<ArchiveModel>(
                    "SELECT * " +
                    "FROM archive " +
                    $"WHERE Id = {id.ToString()}");
            }
            return archive;
        }

        public static ArchiveModel GetArchive()
        {
            ArchiveModel archive = new ArchiveModel();
            using (IDbConnection db = new SQLiteConnection(AppConfig.ConnectionStrings.ArchiveDb))
            {
                archive = db.QuerySingle<ArchiveModel>(
                    "SELECT * " +
                    "FROM archive " +
                    "WHERE Id = (SELECT MAX(Id) FROM archive)");
            }
            return archive;
        }

        public static void NewArchive(ArchiveModel archive)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(AppConfig.ConnectionStrings.ArchiveDb))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO archive" +
                        "(ArchiveName," +
                        "Description," +
                        "SourceRoot," +
                        "BackupRoot," +
                        "Enabled)" +
                        "VALUES" +
                        $"(@ArchiveName," +
                        $"@Description," +
                        $"@SourceRoot," +
                        $"@BackupRoot," +
                        $"@Enabled)";
                    cmd.Parameters.AddWithValue("@ArchiveName", archive.ArchiveName);
                    cmd.Parameters.AddWithValue("@Description", archive.Description);
                    cmd.Parameters.AddWithValue("@SourceRoot", archive.SourceRoot);
                    cmd.Parameters.AddWithValue("@BackupRoot", archive.BackupRoot);
                    cmd.Parameters.AddWithValue("@Enabled", archive.Enabled);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                string curDir = Directory.GetCurrentDirectory();
                Directory.CreateDirectory(Path.Combine(curDir, "Logs", archive.ArchiveName.Trim()));
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateArchive(ArchiveModel archive)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(AppConfig.ConnectionStrings.ArchiveDb))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE archive " +
                        "SET " +
                        "ArchiveName = @ArchiveName," +
                        "Description = @Description," +
                        "SourceRoot = @SourceRoot," +
                        "BackupRoot = @BackupRoot," +
                        "LastRunDateTime = @LastRun," +
                        "Enabled = @Enabled " +
                        "WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@ArchiveName", archive.ArchiveName);
                    cmd.Parameters.AddWithValue("@Description", archive.Description);
                    cmd.Parameters.AddWithValue("@SourceRoot", archive.SourceRoot);
                    cmd.Parameters.AddWithValue("@BackupRoot", archive.BackupRoot);
                    cmd.Parameters.AddWithValue("@LastRun", archive.LastRunDateTime);
                    cmd.Parameters.AddWithValue("@Enabled", archive.Enabled);
                    cmd.Parameters.AddWithValue("@Id", archive.Id);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public static void DeleteArchive(ArchiveModel archive)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(AppConfig.ConnectionStrings.ArchiveDb))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM archive WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", archive.Id);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateLogDirectory(string oldName, string newName)
        {
            string curDir = Directory.GetCurrentDirectory();
            string oldPath = Path.Combine(curDir, "Logs", oldName.Trim());
            string newPath = Path.Combine(curDir, "Logs", newName.Trim());
            if (Directory.Exists(oldPath))
            {
                Directory.Move(oldPath, newPath);
            }
            else
            {
                Directory.CreateDirectory(oldPath);
            }
        }

        public static List<ArchiveLog> GetLogs(ArchiveModel archive)
        {
            try
            {
                List<ArchiveLog> result = new List<ArchiveLog>();

                string path = Path.Combine(Directory.GetCurrentDirectory(), "Logs", archive.ArchiveName.Trim());
                if (Directory.Exists(path))
                {
                    foreach(var log in Directory.GetFiles(path))
                    {
                        try
                        {
                            var content = File.ReadAllText(log);
                            var logObj = JsonConvert.DeserializeObject<ArchiveLib.Archive.Log>(content);
                            result.Add(new ArchiveLog()
                            {
                                LogDateTime = logObj.StartTimeLocal,
                                LogFilePath = log
                            });
                        }
                        catch (Exception e)
                        {
                            var ex = e.Message;
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static string GetLog (string logPath)
        {
            try
            {
                if (File.Exists(logPath))
                {
                    return File.ReadAllText(logPath);
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                throw;
            }
        }

        public static void DeleteLogs(ArchiveModel archive)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Logs", archive.ArchiveName.Trim());
                if (Directory.Exists(path)) Directory.Delete(path,true);
            }
            catch
            {
                throw;
            }
        }
    }
}
