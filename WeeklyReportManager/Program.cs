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
        static void Main(string[] args)
        {
            List<ActivityReport> reports = new List<ActivityReport>();

            Menu();

        }

        static void Menu()
        {
            Console.WriteLine("=== Relatório de atidade díario ===\n");
            Console.WriteLine("Cadastre suas atividade com as informações: Nome, quantidade, observação\n");

            Console.WriteLine("Caso queira encerrar digite o nome do da atividade 'Fim do expediente'\n");

            while (true)
            {

                
                Console.Write("Nome da tarefa: ");
                string nameTask = Console.ReadLine();

                if (nameTask == "Fim do expediente")
                    break;

                Console.Write("Quantidade: ");
                string quantity = Console.ReadLine();
                Console.Write("Observação: ");
                string observation = Console.ReadLine();

                
            }
        }

        static void ActivityLog(string name, int quantity, string observation)
        {
 
        }
    }
}
