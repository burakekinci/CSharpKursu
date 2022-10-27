using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }


    //Interface ve virtualın ortak noktalarını bulunduran bir yapı denilebilir
    //Interface gibi tek başına tanımlanamaz -> Database database = new Database() şeklinde tanımlanamaz, hata verir.
    abstract class Database
    {
        //tüm alt databaselerde ekleme metotu aynıdır
        public void Add()
        {
            Console.WriteLine("Added by default");
        }

        //tüm alt databaselerde silme kendine göredir ve alt sınıflarda override edilmek zorundadır
        public abstract void Delete();
    }
}
