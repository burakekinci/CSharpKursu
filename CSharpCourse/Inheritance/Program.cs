using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3]
            {
                new Customer{FirstName="Burak"},
                new Student{FirstName="Veli"},
                new Person{FirstName="Beyza"}
            };
            
            foreach (var person in people)
            {
                Console.WriteLine(person.FirstName);
            }
            Console.ReadLine();
        }
    }

    //Inheritance sınıfın tek başına bir anlamı vardır, childde tekrardan declare etmeye gerek yok
    //Bir sınıf yalnızca bir sınıftan miras alabilir
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

    }

    class Customer:Person
    {
        public string City { get; set; }
    }

    class Student : Person
    {
        public string Department { get; set; }
    }
}
