using Classes;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using System.Xml.Linq;

namespace Bureau
{
    internal class EmployerInterface
    {
        public static void EmployerMenu()
        {
            int employer_id = -1;
            XDocument xDoc = XDocument.Load("employers.xml");
            XElement employers = xDoc.Element("employers");
            if (employers != null )
            {
                foreach (XElement employer in employers.Elements("employer"))
                {
                    employer_id = int.Parse(employer.Attribute("Id").ToString());
                }
            }
            Console.Clear();
            Console.WriteLine("                                         =====================================\n" +
                              "                                         |     1. Показать работодателей     |\n" +
                              "                                         =====================================\n" +
                              "                                         |     2. Добавить работодателя      |\n" +
                              "                                         =====================================\n" +
                              "                                         |     3. Удалить работодателя       |\n" +
                              "                                         =====================================\n" +
                              "                                         |     4. Выход в главное меню       |\n" +
                              "                                         =====================================");
            Console.WriteLine("Введите код операции:  ");
            char Code = Console.ReadKey(true).KeyChar;
            switch (Code)
            {
                case '1':
                    ShowEmployers();
                    break;
                case '2':
                    AddEmployer(employer_id);
                    break;
                case '3':
                    DeleteEmployer();
                    break;
                case '4':
                    Main.MainMenu();
                    break;
                default:
                    Console.WriteLine("Вы ввели неверный код, повторите ввод");
                    Thread.Sleep(1000);
                    EmployerMenu();
                    break;
            }
        }

        internal static void ShowEmployers()
        {
            Console.Clear();
            XmlDocument employer_doc = new XmlDocument();
            employer_doc.Load("employers.xml");
            XmlNode root = employer_doc.DocumentElement;
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
            }
            else
            {
                Console.WriteLine("Работадателей нет");
                Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
            }
            Console.ReadKey();
            EmployerMenu();
        }

        static void AddEmployer(int employer_id)
        {
            Console.Clear();
           // try
            //{
                Console.WriteLine("Введите название компании");
                string CompanyName = Console.ReadLine();
                Console.WriteLine("Введите род занятий");
                string WorkType = Console.ReadLine();
                Console.WriteLine("Введите адрес");
                string Adress = Console.ReadLine();
                Console.WriteLine("Введите номер телефона");
                string TelephoneNumber = Console.ReadLine();
                employer_id++;
                Employer employer = new Employer(employer_id, CompanyName, WorkType, Adress, TelephoneNumber);
                employer.ToDoc();

            //}
            /*catch
            {
                Console.WriteLine("Вы ввели неверные данные, повторите ввод. Нажмите любую кнопку чтобы продолжить");
                Console.ReadKey();
                AddEmployer(employer_id);
            }*/
            EmployerMenu();
        }

        static void DeleteEmployer()
        {
            Console.Clear();
            XmlDocument employer_doc = new XmlDocument();
            employer_doc.Load("employers.xml");
            XmlNode root = employer_doc.DocumentElement;
            XmlNodeList celllist = root.ChildNodes;
            if (celllist.Count != 0 )
            {
                foreach (XmlNode cellNode in celllist)
                {
                    foreach (XmlNode node in cellNode.ChildNodes)
                    {
                        Console.WriteLine(node.InnerText);
                    }
                }
                try
                {
                    Console.WriteLine("Введите код работодателя, которого вы ходите удалить");
                    int id = int.Parse(Console.ReadLine());
                    var y = employer_doc.GetElementsByTagName("employer")[id];
                    employer_doc.DocumentElement.RemoveChild(y);
                    employer_doc.Save("employers.xml");
                }
                catch
                {
                    Console.WriteLine("Работодателя с таким кодом не существует");
                    Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
                    Console.ReadKey();
                    EmployerMenu();
                }
            }
            else
            {
                Console.WriteLine("Нет работодателей для удаления");
                Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню...");
                Console.ReadKey();
            }
            EmployerMenu();
        }
    }
}
