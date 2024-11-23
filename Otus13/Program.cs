namespace Otus13
{
	internal class Program
	{
		private static readonly List<Item> _items = new List<Item>()
		{
			new Item() {Id = 1, Name = "Хлеб"},
			new Item() {Id = 2, Name = "Молоко"},
			new Item() {Id = 3, Name = "Яица"},
			new Item() {Id = 4, Name = "Шоколад"},
			new Item() {Id = 5, Name = "Кофе"},
			new Item() {Id = 6, Name = "Чай"},
		};
		static void Main(string[] args)
		{
			var shop = new Shop();
			var customer = new Customer();
			shop.Items.CollectionChanged += customer.OnItemChanged;
			foreach (var item in _items)
			{
				shop.Add(item);
			}

			while (true)
			{
				Console.WriteLine("A - новый товар, D - удалить товар, X - выход");
				var reply = Console.ReadLine();
				if (reply == "A")
				{
					shop.Add(new Item() { 
						Id = shop.Items.Count + 1,
						Name = "Товар от " + DateTime.Now.ToString() 
					});
				}
				else if (reply == "D")
				{
					Console.WriteLine("Введите Id товара, который хотите удалить");
					reply = Console.ReadLine();
					int id;
					if(!int.TryParse(reply, out id)){
						Console.WriteLine("Ответ не распознан");
					}
					else
					{
						shop.Remove(id);
					}
				}
				else if (reply == "X") break;
				else Console.WriteLine("Ответ не распознан");
			}
		}
	}
}
