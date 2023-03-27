using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bureau
{
    internal class Main
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("                                         =====================================\n" +
                              "                                         |         1.Соискатели              |\n" +
                              "                                         =====================================\n" +
                              "                                         |         2.Наниматели              |\n" +
                              "                                         =====================================\n" +
                              "                                         |         3.Договоры                |\n" +
                              "                                         =====================================\n" +
                              "                                         |         4.Выход из программы      |\n" +
                              "                                         =====================================");
            Console.WriteLine("Введите код операции: ");
            char Code = Console.ReadKey(true).KeyChar;
            switch (Code)
            {
                case '1':
                    WorkerInterface.WorkerMenu();
                    break;
                case '2':
                    EmployerInterface.EmployerMenu();
                    break;
                case '3':
                    DealInterface.DealMenu();
                    break;
                case '4':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Вы ввели неверный код, повторите ввод");
                    Thread.Sleep(1000);
                    MainMenu();
                    break;
            }
        }
    }
}
