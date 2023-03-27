using Classes;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace Bureau
{
    internal class WorkerInterface
    {
        public static void WorkerMenu()
        {
            int worker_id = -1;
            XDocument xDoc = XDocument.Load("workers.xml");
            XElement? workers = xDoc.Element("workers");
            if (workers != null )
            {
                foreach (XElement worker in workers.Elements("worker"))
                {
                    worker_id = int.Parse(worker.Attribute("Id").Value);
                }
            }
            Console.Clear();
            Console.WriteLine("                                         =====================================\n" +
                              "                                         |     1. Показать соискателей       |\n" +
                              "                                         =====================================\n" +
                              "                                         |     2. Добавить соискателя        |\n" +
                              "                                         =====================================\n" +
                              "                                         |     3. Удалить соискателя         |\n" +
                              "                                         =====================================\n" +
                              "                                         |     4. Выход в главное меню       |\n"+
                              "                                         =====================================");
            Console.WriteLine("Введите код операции: ");
            char Code = Console.ReadKey(true).KeyChar;
            switch (Code)
            {
                case '1':
                    ShowWorkers();
                    break;
                case '2':
                    AddWorker(worker_id);
                    break;
                case '3':
                    DeleteWorker();
                    break;
                case '4':
                    Main.MainMenu();
                    break;
                default:
                    Console.WriteLine("Вы ввели неверный код, повторите ввод");
                    Thread.Sleep(1000);
                    WorkerMenu();
                    break;
            }
        }

        internal static void ShowWorkers()
        {
            Console.Clear();
            XDocument xDoc = XDocument.Load("workers.xml");
            XElement? workers = xDoc.Element("workers");
            if (workers != null)
            {
                foreach (XElement worker in workers.Elements("worker"))
                {
                    Console.WriteLine($"{worker.Attribute("Id").Value}");
                    Console.WriteLine($"{worker.Element("FullName")}");
                    Console.WriteLine($"{worker.Element("Qualification")}");

                }
            }
            if (celllist.Count == 0)
            {
                Console.WriteLine("Соискателей нет");
                Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
            }
            else
            {
                foreach (XmlNode cellNode in celllist)
                {
                    foreach (XmlNode node in cellNode.ChildNodes) 
                    { 
                        Console.WriteLine(node.InnerText);
                    }
                }
            }
            Console.ReadKey();
            WorkerMenu();
        }

        static void AddWorker(int worker_id)
        {
            Console.Clear();
            //try
            //{
                Console.WriteLine("Введите ФИО");
                string FullName = Console.ReadLine();
                Console.WriteLine("Введите квалификацию");
                string Qualification = Console.ReadLine();
                Console.WriteLine("Введите род занятий");
                string WorkType = Console.ReadLine();
                Console.WriteLine("Введите желаемую зарплату");
                decimal WantedSalary = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Введите остальную информацию");
                string Other = Console.ReadLine();
                worker_id++;
                Worker worker = new Worker(worker_id, FullName, Qualification, WorkType, WantedSalary, Other);
                worker.ToDoc();
                WorkerMenu();
            //}
            /*catch
            {
                Console.WriteLine("Вы ввели неверные данные, повторите ввод. Нажмите любую кнопку чтобы продолжить");
                Console.ReadKey();
                AddWorker(worker_id);
            }*/
        }

        static void DeleteWorker()
        {
            Console.Clear();
            XmlDocument worker_doc = new XmlDocument();
            worker_doc.Load("workers.xml");
            XmlNode root = worker_doc.DocumentElement;
            XmlNodeList celllist = root.ChildNodes;
            if (celllist.Count != 0)
            {
                foreach (XmlNode cellNode in celllist)
                {
                    foreach (XmlNode node in cellNode.ChildNodes)
                    {
                        Console.WriteLine(node.InnerText);
                    }
                }
                Console.WriteLine("Введите код нужного соискателя");
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    var y = worker_doc.GetElementsByTagName("worker")[id];
                    worker_doc.DocumentElement.RemoveChild(y);
                    worker_doc.Save("workers.xml");
                }
                catch
                {
                    Console.WriteLine("Соискателя с таким кодом не существует");
                    Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
                    Console.ReadKey();
                    WorkerMenu();
                }
            }
            else
            {
                Console.WriteLine("Нет соискателей для удаления");
                Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
                Console.ReadKey();
            }
            WorkerMenu();
        }
    }
}
