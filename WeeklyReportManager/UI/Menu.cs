using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyReportManager
{
    internal class Menu
    {
        ActivityReportService activityReportService = new ActivityReportService();
        

        public void Run()
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
                    activityReportService.ListAtivityReports();
                    break;
                }



                Console.Write("Quantidade: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("Observação: ");
                string observation = Console.ReadLine();

                ActivityReport report = activityReportService.CreateReport(nameTask, quantity, observation);
                reports.Add(report);

            }
        }
    }
}
