using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyReportManager
{
    internal class ActivityReportService
    {
        public List<ActivityReport> reports = new List<ActivityReport>();
        public int contId = 0;

        // Creating an activity log object
        public ActivityReport CreateReport(string name, int quantity, string observation)
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
        //Delet records
        public void DeleteActivityReport(int id)
        {

            ActivityReport report = FindById(id);
            if (report != null)
            {
                reports.Remove(FindById(id));
            }

        }
    }
}
