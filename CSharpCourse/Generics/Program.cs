using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> cities = utilities.buildList<string>("Ankara", "İstanbul", "Bursa");
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

            List<Customer> customers = utilities.buildList<Customer>(new Customer { FirstName = "Burak" }, new Customer { FirstName = "Mert" });
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
            Console.ReadLine();
        }
    }

    class Utilities
    {
        public List<T> buildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }

    interface IEntity
    {
        //bir veritabanı nesnesi olan sınıflara implemente edilir
    }

    interface IProductDal:IRepository<Product>
    {
        //ProductDal'a özel methodlar yazılabilir
    }

    interface ICustomerDal:IRepository<Customer>
    {
        //CustomerDak'a özel methodlar yazılabilir
        void PopulerCustomeOfMonth();
    }

    //Dal interfaceleri için genel bir Dal interface'i yazdık ve Generic bir T type'a göre ayarladık. Bu sayede kod tekrarından kurtulduk
    //Where ile ICustomerDal:IRepository<string> gibi yanlış kullanımların önüne geçiyoruz
    interface IRepository<T> where T : class, IEntity, new()//bu interface'e tanımlanacak T tipi bir class, IEntity implemente etmiş ve newlenebilir olmadılır demek
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    class Product:IEntity
    {
        //Bir veritabanı varlığı olduğundan IEntity implemente edildi
    }

    class Customer:IEntity
    {
        //Bir veritabanı varlığı olduğundan IEntity implemente edildi
        public string FirstName { get; set; }
    }
}
