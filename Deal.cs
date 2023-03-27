using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Deal
    {
        const string path = "deals.txt";
        public int Id { get; set; }
        public int employerId { get; set; }
        public int workerId { get; set; }
        public string? WorkPosition { get; set; }
        public decimal Salary { get; set; }
        public decimal Fee => Math.Round(Salary * 5 / 100);
        public Deal(int id, int employerId, int workerId, string? workPosition, decimal salary)
        {
            Id = id;
            this.employerId = employerId;
            this.workerId = workerId;
            WorkPosition = workPosition;
            Salary = salary;
        }
        public void Show()
        {
            Console.WriteLine("==========================Договор========================\n" +
                              $"Код договора {Id}\n" +
                              $"Код работодателя {employerId}\n" +
                              $"Код соискателя {workerId}\n" +
                              $"Должность {WorkPosition}\n" +
                              $"Зарплата {Salary}\n" +
                              $"Комиссия {Fee}\n" +
                              "=========================================================\n");
        }
        string ToString()
        {
            return $"{Id},{employerId},{workerId},{WorkPosition},{Salary},{Fee}";
        }
        static Deal ToClass(string line)
        {
            string[] mas = line.Split(',');
            Deal deal = new Deal(int.Parse(mas[0]), int.Parse(mas[1]), int.Parse(mas[2]), mas[3], decimal.Parse(mas[4]));
            return deal;
        }
        public static void Initialize(ref ICollection<Deal> deals, ref int deal_id)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new(path))
                {
                    while (!reader.EndOfStream)
                    {
                        deals.Add(ToClass(reader.ReadLine()));
                    }
                }
                if (deals.Count > 0) { deal_id = deals.Last().Id; }
            }
        }
        public static void Write(ICollection<Deal> deals)
        {
            using (StreamWriter writer = new(path, false))
            {
                foreach (Deal deal in deals)
                {
                    writer.WriteLine(deal.ToString());
                }
            }
        }
    }
}
