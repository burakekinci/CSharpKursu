using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{

    //ufak bir mimari nasıl olmalı örneği
    //internal anahtar kelimesi protected ve public arasında gibidir. Aynı proje dizinindeki diğer sınıflarca using gerekmeden kullanılmasını sağlar
    //eğer sınıfın access modifiersi belirtilmemişse varsayılan olarak internal'dır.
    //eğer bir sınıfı public yaparsak aynı solution içerisinden farklı bir projede using gerekmeden kullanabiliriz
    internal class Program
    {
        static void Main(string[] args)
        {
            //duruma göre istenilen logger tipi seçilebilir artık
            //CustomerManager customerManager = new CustomerManager(new DatabaseLogger());
            //customerManager.Add();

            ChildClass childClass = new ChildClass("Product");
            childClass.Add();
            Console.ReadLine();
        }
    }


    class CustomerManager
    {
        private ILogger _logger { get; set; }
        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Customer Added!");
        }
    }

    interface ILogger
    {
        void Log();
    }


    class DatabaseLogger : ILogger
    {

        public void Log()
        {
            string logMessage = "Logged to database!";
            Console.WriteLine(logMessage);
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            string logMessage = "Logged to database!";
            Console.WriteLine(logMessage);
        }
    }

    class BaseClass
    {
        private string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;
            Message();
        }
        public void Message()
        {
            Console.WriteLine("{0} message", _entity);
        }
    }

    class ChildClass: BaseClass
    {
        //base sınıfa parametre gönderimi
        public ChildClass(string entity):base(entity)
        {

        }
        public void Add()
        {
            Console.WriteLine("Added");
        }
    }
}
