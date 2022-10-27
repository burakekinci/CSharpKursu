using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id=1, Name="Burak"};
            CustomerDal customerDal = new CustomerDal();
            //[Obsolete("Dont'use Add Method, use insted AddNew Method")] -> kullanımı kalkmış methotlarda diğer geliştiricileri uyarmak için kullanılır
            customerDal.Add(customer);
        }
    }

    [ToTable("Customers")]
    [ToTable("CustomersRelations")] //allow multiple ile bu şekilde de aynı attribute çoklu olarak kullanılabilir
    class Customer
    {
        [RequiredProperty]
        public string Name { get; set; }

        [RequiredProperty]
        public int Id { get; set; }

        [RequiredProperty]
        public int Age { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        private string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    class RequiredPropertyAttribute : Attribute
    {
        
    }

    class CustomerDal
    {
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2} added", customer.Id,customer.Name,customer.Age);
        }
    }
}
