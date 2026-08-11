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
        private readonly string path = "Data/reports.json";

        public void Save(List<ActivityReport> reports)
        {
            string json = JsonSerializer.Serialize(reports, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(path, json);
        }
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
