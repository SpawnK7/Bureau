using Classes;

namespace Bureau
{
    internal class DealInterface
    {
        public static void DealMenu()
        {
            ICollection<Deal> deals = new List<Deal>();
            int deal_id = -1;
            Deal.Initialize(ref deals,ref deal_id);
            Console.Clear();
            Console.WriteLine("                                         =====================================\n" +
                              "                                         |        1. Показать договоры       |\n" +
                              "                                         =====================================\n" +
                              "                                         |        2. Добавить договор        |\n" +
                              "                                         =====================================\n" +
                              "                                         |        3. Удалить договор         |\n" +
                              "                                         =====================================\n" +
                              "                                         |        4. Выход в главное меню    |\n" +
                              "                                         =====================================");
            Console.WriteLine("Введите код операции: ");
            char Code = Console.ReadKey(true).KeyChar;
            switch (Code)
            {
                case '1':
                    ShowDeals(deals);
                    break;
                case '2':
                    AddDeal(deals,deal_id);
                    break;
                case '3':
                    DeleteDeal(deals);
                    break;
                case '4':
                    Main.MainMenu();
                    break;
                default:
                    Console.WriteLine("Вы ввели неверный код, повторите ввод");
                    Thread.Sleep(1000);
                    DealMenu();
                    break;
            }
        }

        internal static void ShowDeals(ICollection<Deal> deals)
        {
            Console.Clear();
            if (deals.Count == 0)
            {
                Console.WriteLine("Сделок нет");
            }
            else
            {
                foreach (Deal deal in deals)
                {
                    deal.Show();
                }
            }
            Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
            Console.ReadKey();
            DealMenu();
        }

        internal static void AddDeal(ICollection<Deal> deals,int deal_id)
        {
            ICollection<Worker> workers = new List<Worker>();
            int worker_id = -1;
            
            ICollection<Employer> employers = new List<Employer>();
            int employer_id = -1;
            Console.Clear();
            if (workers.Count == 0)
            {
                Console.WriteLine("Нет соискателей для заключения договора");
                Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
                Console.ReadKey();
                DealMenu();
            }
            else
            {
                foreach (Worker worker in workers)
                {
                 
                }
                try
                {
                    Console.WriteLine("Введите код соискателя, с которым заключат договор");
                    int Code1 = int.Parse(Console.ReadLine());
                    int temp1 = workers.Where(d => d.Id == Code1).First().Id;
                    Console.Clear();
                    if (employers.Count == 0)
                    {
                        Console.WriteLine("Нет работодателей для заключения договора");
                        Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
                        Console.ReadKey();
                        DealMenu();
                    }
                    else
                    {
                        foreach (Employer employer in employers)
                        {
                        }
                        Console.WriteLine("Введите код работодателя, который заключит договор");
                        int Code2 = int.Parse(Console.ReadLine());
                        int temp2 = employers.Where(d => d.Id == Code2).First().Id;
                        Console.Clear();
                        Console.WriteLine("Введите должность");
                        string WorkPosition = Console.ReadLine();
                        Console.WriteLine("Введите заработную плату работника");
                        decimal Salary = decimal.Parse(Console.ReadLine());
                        deal_id++;
                        Deal deal = new Deal(deal_id, temp2, temp1, WorkPosition, Salary);
                        deals.Add(deal);
                        Deal.Write(deals);
                    }
                }
                catch
                {
                    Console.WriteLine("Вы ввели неверные данные, повторите ввод. Нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                    DealMenu();
                }
            }
            DealMenu();
        }

        internal static void DeleteDeal(ICollection<Deal> deals)
        {
            Console.Clear();
            if (deals.Count == 0)
            {;
                Console.WriteLine("Нет договоров для удаления");
                Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Введите код договора, который вы ходите удалить");
                int id = int.Parse(Console.ReadLine());
                var temp = deals.Where(d => d.Id == id).First();
                if (temp != null)
                {
                    deals.Remove(temp);
                    Deal.Write(deals);
                }
                else
                {
                    Console.WriteLine("Договора с таким кодом не существует");
                    Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
                    Console.ReadKey();
                }
            }
            DealMenu();
        }
    }
}
