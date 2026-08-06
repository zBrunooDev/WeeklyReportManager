using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
            bool runnig = true;

            while (runnig)
            {

                DrawHeader();
                DrawMenu();

                int option = ReadOption();
                if (option == -1)
                {
                    ShowError("Opção inválida.");
                }
                else
                {

                    switch (option)
                    {
                        case 1:
                            //Adding activities
                            Console.Write("Digite o nome da atividade: ");
                            string name = Console.ReadLine();
                            int quantity = ReadInt("Quantidade: ");
                            Console.Write("Observação: ");
                            string observation = Console.ReadLine();
                            service.RegisterActivity(name, quantity, observation);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Atividade Cadastrada com sucesso!");
                            Console.ResetColor();
                            Pause();
                            break;
                        case 2:
                            // Listing activities
                            ShowReports();
                            break;
                        case 3:
                            //List by ID
                            ShowReportById();
                            break;
                        case 4:
                            //Edit report
                            ShowEditReport();
                            break;
                        case 5:
                            ShowDeletReport();
                            break;
                        case 0:
                            ShowSuccess("Encerrando o sistema...");
                            runnig = false;
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

        //Show the attractive listing
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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("============================================");
                Console.WriteLine("             DETALHES DO RELATÓRIO           ");
                Console.WriteLine("============================================");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Total de atividades: {reports.Count}");
                Console.WriteLine();

                Console.ResetColor();

                foreach (var report in reports)
                {
                    DisplayReport(report);
                    Console.WriteLine();
                }
            }
            Pause();
        }
        // Show report by ID
        static void ShowReportById()
        {
            Console.Write("Digite o ID: ");
            int chooseId = ReadOption();
            if (chooseId == -1)
            {
                ShowError("Opção inválida.");
            }
            else
            {
                var serviceId = service.FindById(chooseId);
                if(serviceId == null)
                {
                    ShowError("ID não encontrado!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("============================================");
                    Console.WriteLine("            BUSCAR RELATÓRIO POR ID         ");
                    Console.WriteLine("============================================");
                    Console.ResetColor();
                    Console.WriteLine();
                    DisplayReport(serviceId);
                    Pause();
                }
            }
        }
        // Show Display of Reports Listing
        static void DisplayReport(ActivityReport report)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============================================");
            Console.ResetColor();

            Console.WriteLine($"ID         : {report.Id}");
            Console.WriteLine($"Data       : {report.Date:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Tarefa     : {report.TaskName}");
            Console.WriteLine($"Quantidade : {report.Quantity}");
            Console.WriteLine($"Observação : {report.Observation}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============================================");
            Console.ResetColor();
        }
        // Show current data and edit
        static void ShowEditReport()
        {
            ActivityReport report = SelectReportById();
            if (report == null)
            {
                Pause();
                return;
            }

            Console.WriteLine();

            DisplayReport(report);

            Console.WriteLine();

            Console.Write("Novo nome: ");
            string name = Console.ReadLine();

            int quantity = ReadInt("Nova quantidade: ");

            Console.Write("Nova observação: ");
            string observation = Console.ReadLine();

            service.UpdateReport(report, name, quantity, observation);

            Console.WriteLine();
            ShowSuccess("Dados alterados com sucesso!");
            
        }
        // Auxiliary methods for displaying success/error messages
        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Pause();
        }
        static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Pause();
        }
        // auxiliary method to return an item from the list
        static ActivityReport SelectReportById()
        {
            Console.Write("Digite o ID: ");
            int id = ReadOption();
            if (id == -1)
            {
                ShowError("Opção inválida.");
                return null;
            }

            ActivityReport report = service.FindById(id);
            if (report == null)
            {
                ShowError("ID não encontrado!");
                return null;
            }
            return report;
        }
        // auxiliary method for deleting a report
        static void ShowDeletReport()
        {
            ActivityReport report = SelectReportById();
            if (report == null)
                return;

            DisplayReport(report);
            Console.WriteLine("[0] = Não / [1] = Sim");
            int option = ReadInt("Deseja realmente excluir esta atividade?: ");
            
            if (option == 0)
            {
                return;
            }
            else
            {
                service.DeleteReport(report.Id);
                ShowError("Atividade não excluida!");
            }


            ShowSuccess("Atividade excluída com sucesso!");
        }
        // auxiliary method for reading numbers
        static int ReadInt(string prompt)
        {
            int quantity;
            Console.Write($"{prompt}");

            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                ShowError("Valor inválido! Digite um número inteiro.");
                Console.WriteLine();
                Console.Write($"{prompt}");
            }
            return quantity;
        }

    }
}
