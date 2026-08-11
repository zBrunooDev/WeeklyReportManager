using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyReportManager.Service;

namespace WeeklyReportManager
{
    internal class ActivityReportService
    {
        private List<ActivityReport> reports = new List<ActivityReport>();
        private int contId;
        private readonly JsonStorageService storage;

        public ActivityReportService()
        {
            storage = new JsonStorageService();
            reports = storage.Load();
            foreach (var report in reports)
            {
                if (report.Id > contId)
                    contId = report.Id;
            }
        }

        // Creating an activity log object
        private ActivityReport CreateReport(string name, int quantity, string observation)
        {
            contId++;

            return new ActivityReport()
            {
                TaskName = name,
                Quantity = quantity,
                Observation = observation,
                Id = contId,
                Date = DateTime.Now
            };
        }
        // Method of recording information
        public void RegisterActivity(string name, int quantity, string observation)
        {
            ActivityReport report = CreateReport(name, quantity, observation);
            AddActivityReport(report);   
        }
        
        // Add the report to the list.
        public void AddActivityReport(ActivityReport report)
        {
            reports.Add(report);
        }

        //list report
        public List<ActivityReport> GetAllReports()
        {
            return reports;
        }
        //Search by Id
        public ActivityReport FindById(int id)
        {
            foreach (ActivityReport report in reports)
            {
                if (report.Id == id)
                {
                    return report;
                }
            }
            return null;
        }
        //Update Report
        public void UpdateReport(ActivityReport report, string name, int quantity, string observation)
        {
                report.TaskName = name;
                report.Quantity = quantity;
                report.Observation = observation;  
        }
        //Delet records
        public void DeleteReport(int id)
        {
            reports.Remove(FindById(id));
        }
    }
}
