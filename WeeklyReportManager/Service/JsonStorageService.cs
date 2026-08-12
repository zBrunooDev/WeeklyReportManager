using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace WeeklyReportManager.Service
{
    internal class JsonStorageService
    {
        private readonly string path = "Data/report.json";

        // Method that serializes the object
        public void Save(List<ActivityReport> reports)
        {
            string json = JsonSerializer.Serialize(reports, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            string directory = Path.GetDirectoryName(path);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(path, json);
        }
        //Method that deserializes the object
        public List<ActivityReport> Load()
        {  
            if (!File.Exists(path))
            {
                return new List<ActivityReport>();
            }
                
            string json = File.ReadAllText(path);

            List<ActivityReport> reports =
                JsonSerializer.Deserialize<List<ActivityReport>>(json);

            return reports ?? new List<ActivityReport>();
        }
    }
}
