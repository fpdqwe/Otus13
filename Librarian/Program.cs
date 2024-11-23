using System.Collections.Concurrent;

namespace Librarian
{
	internal class Program
	{
		private static ConcurrentDictionary<string, int> Books = new ConcurrentDictionary<string, int>();
		static void Main(string[] args)
		{
			var bookThread = new Thread(ReadBooks);
			bookThread.Start();
			while (true)
			{
				Console.WriteLine("1 - добавить книгу, 2 - вывести спиок прочитанного, 3 - выйти");
				var reply = Console.ReadLine();
				if (reply == "1")
				{
					Console.WriteLine("Введите название книги");
					reply = Console.ReadLine();
					AddBook(reply);
				}
				else if (reply == "2")
				{
					PrintBooksList();
				}
				else if (reply == "3")
				{
					break;
				}
				else
				{
					Console.WriteLine("Ответ не распознан");
				}
			}
			bookThread.Abort();
		}
		private static void PrintBooksList()
		{
			foreach (var book in Books)
			{
				Console.WriteLine($"{book.Key} - {book.Value}");
			}
		}
		private static void AddBook(string name)
		{
			var update = Books.TryAdd(name, 0);
			if (!update)
			{
				Thread.Sleep(30);
				AddBook(name);
			}
		}
		private static void ReadBooks()
		{
			while (true)
			{
				if (Books.Count > 0)
				{
					foreach (var book in Books)
					{
						if (book.Value >= 100)
						{
							var remove = Books.Remove(book.Key,out int i);
						}
						Books.TryUpdate(book.Key, book.Value + 1, book.Value);
					}
				}
				Thread.Sleep(1000);
			}
		}
	}
}
