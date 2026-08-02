using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyReportManager
{
    internal class Menu
    {
        static ActivityReportService service = new ActivityReportService();

        // initializes and controls the application flow
        public void Start()
        {
            DrawHeader();
            DrawMenu();
            int option = ReadOption();
            while (true)
            {
                if (option == 0)
                {
                    break;
                }
                if (option == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar");
                    Console.ResetColor();
                    Console.ReadKey();

                }
                else
                {

                    switch (option)
                    {
                        case 1:
                            //Adding activities
                            Console.Write("Digite o nome da atividade: ");
                            string name = Console.ReadLine();
                            Console.Write("Quantidade: ");
                            int quantity = int.Parse(Console.ReadLine());
                            Console.Write("Observação: ");
                            string observation = Console.ReadLine();
                            service.CreateReport(name, quantity, observation);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Atividade Cadastrada com sucesso!");
                            service.RegisterActivity(name, quantity, observation);
                            Console.ResetColor();
                            Pause();
                            Start();
                            break;
                        case 2:
                            // Listing activities
                            ShowReports();
                            Start();
                            break;
                    }

                }
            }

        }
        // Draw the header
        static void DrawHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============================================");
            Console.WriteLine("           WEEKLY REPORT MANAGER            ");
            Console.WriteLine("============================================");
            Console.ResetColor();
            Console.WriteLine();
        }
        //Draw the Menu
        static void DrawMenu()
        {
            Console.WriteLine("Registro diário de atividades administrativas");
            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.WriteLine("[1] Nova Atividade");
            Console.WriteLine("[2] Listar atividades");
            Console.WriteLine("[3] Buscar por ID");
            Console.WriteLine("[4] Editar atividade");
            Console.WriteLine("[5] Excluir atividade");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("============================================");
            Console.Write("Escolha uma opção: ");
        }
        //Execute the corresponding action.
        static int ReadOption()
        {

            string input = Console.ReadLine();

            int option;
            bool isNumber = int.TryParse(input, out option);

            if(isNumber)
            {
                return option;
            }

            return -1;

        }
        //Pause the program
        static void Pause()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Pressione qualquer tecla para continuar...");
            Console.ResetColor();
            Console.ReadKey();
        }

        //Mostrar a listagem da atrividade
        static void ShowReports()
        {
            var reports = service.GetAllReports();
            if(reports.Count == 0)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Não há nenhum item na lista!");
            }
            else
            {
                foreach(var report in reports)
                {
                    Console.WriteLine("============================================");
                    Console.WriteLine($"ID: {report.Id}");
                    Console.WriteLine($"Data: {report.Date}");
                    Console.WriteLine($"Tarefa: {report.TaskName}");
                    Console.WriteLine($"Quantidade: {report.Quantity}");
                    Console.WriteLine($"Observação: {report.Observation}");
                    Console.WriteLine("============================================");
                }
            }
            Pause();
        }
    }
}
