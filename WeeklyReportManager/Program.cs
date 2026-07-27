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

        static int contId = 1;
        static void Main(string[] args)
        {
            
            List<ActivityReport> reports = new List<ActivityReport>();

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

                    break;

                Console.Write("Quantidade: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("Observação: ");
                string observation = Console.ReadLine();

                CreateReport(nameTask, quantity, observation);

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
    }
}
