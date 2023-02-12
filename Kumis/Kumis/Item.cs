namespace Kumis
{
    //Класс отвечающий за вещь в рюкзаке
	public class Item
	{
		public string Name { get; set; }
		public int Weight { get; set; }
        public int Damage { get; set; }
        public int Slot { get; set; }


        public Item(string name, int weight, int damage, int slot)
        {
            Name = name;
            Weight = weight;
            Damage = damage;
            Slot = slot;
        }
    }
}
