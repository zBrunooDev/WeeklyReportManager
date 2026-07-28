using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyReportManager
{
    internal class Program
    {
        static List<ActivityReport> reports = new List<ActivityReport>();
        static int contId = 0;
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("=== Relatório de atidade díario ===\n");
            Console.WriteLine("Cadastre suas atividade com as informações: Nome, quantidade, observação\n");

            Console.WriteLine("Caso queira encerrar digite o nome do da atividade 'FIM DO EXPEDIENTE'\n");

            while (true)
            {

                Console.Write("Nome da tarefa: ");
                string nameTask = Console.ReadLine();

                if (nameTask == "FIM DO EXPEDIENTE")
                {
                    ListAtivityReports();
                    break;
                }
                   
               

                Console.Write("Quantidade: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("Observação: ");
                string observation = Console.ReadLine();

                ActivityReport report = CreateReport(nameTask, quantity, observation);
                reports.Add(report);

            }
        }

        // Creating an activity log object
        static ActivityReport CreateReport(string name, int quantity, string observation)
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

        // Add the report to the list.
        static void AddActivityReport(ActivityReport report)
        {
            reports.Add(report);
        }
        //list report V1

        /*
        static void ListAtivityReports()
        {
            
            if (reports.Count == 0)
            {
                Console.WriteLine("Não há tarefas para listar.");
            }
            else
            {
                foreach (ActivityReport report in reports)
                {
                    Console.WriteLine($"Id: {report.Id}");
                    Console.WriteLine($"Data: {report.Date}");
                    Console.WriteLine($"Tarefa: {report.TaskName}");
                    Console.WriteLine($"Quantidade: {report.Quantity}");
                    Console.WriteLine($"Observação: {report.Observation}");
                    Console.WriteLine();
                }
            }  
        }
        */
        static List<ActivityReport> ListAtivityReports()
        {
            return reports;
        }


        //Search by Id
        static ActivityReport FindById(int id)
        {
            foreach(ActivityReport report in reports)
            {
                if (report.Id == id)
                {
                    return report;
                }
            }
            return null;
        }
        
        //Delet records
        static void DeleteActivityReport(int id)
        {

            ActivityReport report = FindById(id);
            if (report !=  null)
            {
                reports.Remove(FindById(id));
            }

        }

    }
}
