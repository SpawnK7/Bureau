using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Classes
{
    public class Employer
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? WorkType { get; set; }
        public string? Adress { get; set; }
        public string? TelephoneNumber { get; set; }
        public Employer(int id, string? companyName, string? workType, string? adress, string? telephoneNumber)
        {
            Id = id;
            CompanyName = companyName;
            WorkType = workType;
            Adress = adress;
            TelephoneNumber = telephoneNumber;
        }
        public void ToDoc()
        {
            XDocument xDoc = XDocument.Load("employers.xml");
            XElement employer = new XElement("employer");
            XAttribute employerIdAttr = new XAttribute("Id", Id);
            XElement CompanyNameElem = new XElement("CompanyName", CompanyName);
            XElement WorkTypeElem = new XElement("WorkType", WorkType);
            XElement AdressElem = new XElement("Adress", Adress);
            XElement TelephoneNumberElem = new XElement("TelephoneNumber", TelephoneNumber);
            employer.Add(employerIdAttr, CompanyNameElem, WorkTypeElem, AdressElem, TelephoneNumberElem);
            XElement root = xDoc.Element("employers");
            root.Add(employer);
            xDoc.Save("employers.xml");
        }
    }
        
}