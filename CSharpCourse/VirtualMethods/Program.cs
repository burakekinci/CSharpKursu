using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();

            OracleServer oracleServer = new OracleServer();
            oracleServer.Add();

            Console.ReadLine();

        }
    }


    class Database
    {
        //virtual anahtar kelimesi ile ana sınıfı miras alan alt sınıflar, ana sınıf metotlarını override edebilir
        public virtual void Add()
        {
            Console.WriteLine("Added by Default");
        }
        public virtual void Delete()
        {
            Console.WriteLine("Deleted by Default");
        }
    }

    class SqlServer : Database
    {
        //ana sınıfın metotlarını override etmek için başına override anahtar kelimesi yazılır
        public override void Add()
        {
            Console.WriteLine("Added by SqlServer");
        }
    }

    class OracleServer: Database
    {
        public override void Add()
        {
            Console.WriteLine("Added by OracleServer");
        }
    }
}
