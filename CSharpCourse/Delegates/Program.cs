using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Program
    {

        //delegateler bir tür elçi gibi, burada ilk olarak bir elçilik tanımlıyoruz yani elçi sınıfı gibi
        //biraz daha teknik açıdan bakarsak delegate'ler kendisine verilen metotların ya da fonksiyonların adresini tutmak için kullanılır
        //birnevi C++'daki pointerlar gibi
        public delegate void MyDelegate();
        public delegate void MyDelegate2(string text);
        public delegate int MyDelegate3(int n1,int n2);
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            MyDelegate myDelegate = customerManager.SendMessage; //burada elçiye ilk görevini veriyoruz
            myDelegate += customerManager.SendAlert;             //burada da elçiye sonraki görevini ekliyoruz

            //elçiyi çalıştır ve kendine atanan tüm görevleri yerine getirsin
            myDelegate();                                        

            MyDelegate2 myDelegate2 = customerManager.SendMessage;
            myDelegate2 += customerManager.SendAlert;

            //parametreli delegatelerde, parametre delegate çalıştırılacağı zaman verir.
            //alınan parametre tüm görevlerde kullanılır dikkat!!
            //çıktı -> hello, hello olacaktır
            myDelegate2("hello");                               

            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;

            //bu deleagte bir int döndüğünden bir sonuç değişkenine atanmalı
            //değişkene atanan en son değer delegate'in en sonki görevinin dönüş değeri olur
            var result = myDelegate3(2, 3);   
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }


    class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }

        public void SendAlert()
        {
            Console.WriteLine("Alerted!");
        }
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void SendAlert(string alert)
        {
            Console.WriteLine(alert);
        }
    }

    class Matematik
    {
        public int Topla(int s1,int s2)
        {
            return s1 + s2;
        }

        public int Carp(int s1, int s2)
        {
            return s1 * s2;
        }
    }
}
