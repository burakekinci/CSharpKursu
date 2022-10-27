using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //unsafeTypeArrays();

            //typeSafeArrays();

            Console.ReadLine();
        }

        private static void typeSafeArrays()
        {
            //bunlara ayrıca generic dizilerde denir.
            List<string> cities = new List<string>();
            cities.Add("İstanbul");
            cities.Add("Giresun");

            foreach (string city in cities)
            {
                Console.WriteLine(city);
            }

            List<Customer> customers = new List<Customer>
            {
                new Customer{Id=1,Name="Burak"},
                new Customer{Id=2, Name="Mert"}
            };

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.Name);
            }

            var count= customers.Count();
            customers.AddRange(new Customer[2]//addRange ile birlikte bir listeye herhangi bir list ekleyebiliriz
            {
                new Customer{Id=3, Name="Ali"},
                new Customer{Id=4, Name="Veli"}
            });

            customers.RemoveAll(c => c.Name == "Burak");

            

        }

        private static void unsafeTypeArrays()
        {
            //ArrayListler typeSafe değildir. Eğer herhangi bir tipte bir dizi kullanmamız
            //gerekiyorsa normal array tercih etmek daha iyi olur
            ArrayList cities = new ArrayList();
            cities.Add("İstanbul");
            cities.Add("Bursa");
            cities.Add(1);
            cities.Add('c');


            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
