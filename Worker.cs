using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Classes
{
    public class Worker
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Qualification { get; set; }
        public string? WorkType { get; set; }

        public decimal WantedSalary { get; set; }

        public string? Other { get; set; }
        public Worker(int id, string? fullName, string? qualification, string? workType, decimal wantedSalary, string? other)
        {
            Id = id;
            FullName = fullName;
            Qualification = qualification;
            WorkType = workType;
            WantedSalary = wantedSalary;
            Other = other;
        }
        public void ToDoc()
        {
            XDocument xDoc = XDocument.Load("workers.xml");
            XElement worker = new XElement("worker");
            XAttribute workerIdAttr = new XAttribute("Id", Id);
            XElement workerNameElem = new XElement("FullName", FullName);
            XElement workerQualificationElem = new XElement("Qualification", Qualification);
            XElement workerWorkTypeElem = new XElement("WorkType", WorkType);
            XElement workerWantedSalaryElem = new XElement("WantedSalary", WantedSalary);
            XElement workerOtherElem = new XElement("Other", Other);
            worker.Add(workerIdAttr);
            worker.Add(workerNameElem);
            worker.Add(workerQualificationElem);
            worker.Add(workerWorkTypeElem);
            worker.Add(workerWantedSalaryElem); 
            worker.Add(workerOtherElem);
            XElement? root = xDoc.Element("workers");
            root.Add(worker);
            xDoc.Save("workers.xml");
        }
    }
}
