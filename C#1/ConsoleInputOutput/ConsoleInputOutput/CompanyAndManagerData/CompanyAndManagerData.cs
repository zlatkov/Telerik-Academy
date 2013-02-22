using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAndManagerData
{
    class CompanyAndManagerData
    {
        static void Main(string[] args)
        {
            Console.Write("Enter company name: ");
            string companyName = Console.ReadLine();

            Console.Write("Enter company address: ");
            string companyAddress = Console.ReadLine();

            Console.Write("Enter company phone number: ");
            string companyPhoneNumber = Console.ReadLine();

            Console.Write("Enter company fax number: ");
            string companyFaxNumber = Console.ReadLine();

            Console.Write("Enter company web site: ");
            string companyWebSite = Console.ReadLine();

            Console.Write("Enter manager first name: ");
            string managerFirstName = Console.ReadLine();

            Console.Write("Enter manager last name: ");
            string managerLastName = Console.ReadLine();

            Console.Write("Enter manager age: ");
            byte managerAge = Convert.ToByte(Console.ReadLine());

            Console.Write("Enter manager phone number: ");
            string managerPhoneNumber = Console.ReadLine();

            Console.WriteLine("Company name: " + companyName);
            Console.WriteLine("Company address: " + companyAddress);
            Console.WriteLine("Company phone number: " + companyPhoneNumber);
            Console.WriteLine("Company fax number: " + companyFaxNumber);
            Console.WriteLine("Company web site: " + companyWebSite);
            Console.WriteLine("Manager first name: " + managerFirstName);
            Console.WriteLine("Manager last name: " + managerLastName);
            Console.WriteLine("Manager age: " + managerAge);
            Console.WriteLine("Manager phone number: " + managerPhoneNumber);

        }
    }
}
