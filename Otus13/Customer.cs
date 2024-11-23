using System.Collections.Specialized;

namespace Otus13
{
	public class Customer
	{
		public void OnItemChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if(args.Action == NotifyCollectionChangedAction.Add)
			{
				var newItems = args.NewItems;
				foreach (var element in newItems)
				{
					var item = element as Item;
					Console.WriteLine($"Customer notified about: {item.Id}, {item.Name}, modified by {args.Action.ToString()}");
				}
			}
			if (args.Action == NotifyCollectionChangedAction.Remove)
			{
				var items = args.OldItems;
				foreach (var element in args.OldItems)
				{
					var item = element as Item;
					Console.WriteLine($"{item.Name} удалён из магазина");
				}
			}
		}
	}
}
