using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InterfacesIntro();
            //InterfaceDemo1();

            //Interfacel
            ICustomerDal[] customerDals = new ICustomerDal[2]
            {
                new SqlServerDal(),
                new OracleServerDal()
            };
            foreach (ICustomerDal customerDal in customerDals)
            {
                customerDal.Add();
            }
            Console.ReadLine();
        }

        private static void InterfaceDemo1()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerDal());
            customerManager.Add(new OracleServerDal());
        }

        private static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            Customer customer = new Customer { Id = 1, FirstName = "burak", LastName = "ekinci", Address = "İstanbul" };
            Student student = new Student { Id = 2, FirstName = "begüm", LastName = "özkısırlar", Department = "Mühendislik" };

            manager.Add(student);
            manager.Add(customer);
        }
    }

    //Interfacelerin tek başına bir anlamı yoktur, bir class birden fazla Interface implemente edebilir
    //Propertylerin yeninden declare edilmesi gerekiyor
    interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }

    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine(person.FirstName);
        }
    }
}
