using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeeklyReportManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();
        }
    }
}
