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
        ActivityReportService activityReportService = new ActivityReportService();

        // initializes and controls the application flow
        public void Start()
        {
            DrawHeader();
            DrawMenu();
            ReadOption();
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

        }
        //Execute the corresponding action.
        static void ReadOption()
        {

        }
    }
}
