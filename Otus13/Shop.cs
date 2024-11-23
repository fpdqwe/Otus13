using System.Collections.ObjectModel;

namespace Otus13
{
	public class Shop
	{
		public ObservableCollection<Item> Items { get; private set; }

        public Shop()
        {
            Items = new ObservableCollection<Item>();
        }
        public void Add(Item item)
        {
            Items.Add(item);
        }
        public void Remove(int id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item != null) { Items.Remove(item); }
        }
    }
}
