using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
		{
			//ExceptionsIntro();
			FindIntro();

			//action delegate islemleri
			//bu şekilde action yapısını kullanarak tekrar tekrar try-catch yazmanın önüne geçmiş olduk
			//HandleException(() =>
			//{
			//	Find();
			//});

			//--input,input,output--
			Func<int, int, int> add = Topla;//kullanılacak olan fonksiyonun static olması zorunlu
			Console.WriteLine(add(3, 5));

			//parametresiz Func'larda delegate kullanılabilir
			//buradaki delegate kullanımı bir lambda function(anonymous delegate'tir)
			Func<int> getRandomNumber = delegate ()
			{
				Random random = new Random();
				return random.Next(1, 100);
			};

			Func<int> getRandomNumber2 = () => new Random().Next(1, 100);

			Console.WriteLine(getRandomNumber);
			Thread.Sleep(1000);
			Console.WriteLine(getRandomNumber2);

			Console.ReadLine();

		}

		static int Topla(int sayi1, int sayi2)
		{
			return sayi1 + sayi2;
		}

		private static void FindIntro()
		{
			try
			{
				Find();
			}
			catch (RecordNotFoundException e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static void HandleException(Action action)
		{
			try
			{
				action.Invoke();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static void Find()
		{
			List<string> strings = new List<string> { "ab", "cd" };

			if (!strings.Contains("ali"))
			{
				throw new RecordNotFoundException("Record Not Found!");
			}
			else
			{
				Console.WriteLine("Record Found");
			}
		}

		private static void ExceptionsIntro()
		{
			try
			{
				string[] students = new string[3] { "ali", "veli", "deli" };
				students[3] = "ahmet";
			}
			catch (IndexOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);

			}
		}
	}
}
