using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyReportManager
{
    internal class Menu
    {
        

        // initializes and controls the application flow
        public void Start()
        {
            DrawHeader();
            DrawMenu();
            int option = ReadOption();
            if(option == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar");
                Console.ResetColor();
                Console.ReadKey();

            }
            else
            {
                if(option == 1)
                {
                    Console.WriteLine("Testando");
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
            Console.WriteLine("[2] Listar por atividade");
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
    }
}
