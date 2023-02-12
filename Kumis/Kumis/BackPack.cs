namespace Kumis
{

    //Рюкзак
    public class BackPack
    {
        //Массив обьектов в рюкзаке
        public Item[] items;

        //Следующая свободная ячейка
        private int count = 0;

        public int maxWeight { get; set; }

        public BackPack(int FreeSlot)
        {
            items = new Item[FreeSlot];
            maxWeight = FreeSlot * 5;
            for (int i = 0; i < FreeSlot; i++)
            {
                var Item = new Item("Ничего", 0, 0, 0);
                items[i] = Item;
            }
        }
        public string[] itemsArr = new string[4] { "Алмазный меч", "Ведро с холодной водой", "Самогон", "Кумыс" };
        public void Add(Item item)
        {
            int getWeight = GetWeight();
            int getFreeSlots = GetFreeSlots();

            if (getWeight < maxWeight && getFreeSlots > 0 && count < items.Length)
            {
                items[count] = item;
                count++;
                Console.WriteLine("У вас в инвентаре теперь новый предмет");
            }
            else
            {
                Console.WriteLine("Перевес.");
            }

            Console.WriteLine($"\nОбщий вес = {GetWeight()}, свободного места - {GetFreeSlots()}");
        }
        public void Remove(int slot)
        {
            int index = slot - 1;
            for (int i = index; i < items.Length - 1; i++)
            {
                items[i].Name = items[i + 1].Name;
                items[i].Weight = items[i + 1].Weight;
                items[i].Damage = items[i + 1].Damage;
                items[i].Slot = items[i + 1].Slot - 1;
            }
        }

        public int GetWeight()
        {
            int result = 0;
            for (int i = 0; i < items.Length; i++)
            {
                result += items[i].Weight;
            }
            return result;
        }
        public int GetFreeSlots()
        {
            int FreeSlot = items.Length;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Weight != 0)
                {
                    FreeSlot--;
                }
                else
                {
                    continue;
                }

            }
            return FreeSlot;
        }
        public Item Looting()
        {
            Random rand = new();
            int randomItem = rand.Next(0, 4);
            int weight = 0;
            int damage = 0;

            switch (randomItem)
            {
                case 0:
                    Console.WriteLine("\nВы получили " + itemsArr[0] + "!");
                    weight = 20;
                    damage = 20;
                    break;
                case 1:
                    Console.WriteLine("\nВы получили " + itemsArr[1] + "!");
                    weight = 7;
                    break;
                case 2:
                    Console.WriteLine("\nВы получили " + itemsArr[2] + "!");
                    weight = 5;
                    break;
                case 3:
                    Console.WriteLine("\nВы получили " + itemsArr[3] + "!!!");
                    weight = 5;
                    break;
            }
            var item = new Item(itemsArr[randomItem], weight, damage, count + 1);
            Add(item);

            return item;
        }
        public void Show()
        {
            Console.WriteLine("\nВаш инвентарь:");
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Weight != 0)
                {
                    Console.WriteLine($"Предмет: {items[i].Name} / Вес: {items[i].Weight} / Урон: {items[i].Damage} / Слот: {items[i].Slot}");
                    Console.Write("Описание: ");
                    switch (items[i].Name)
                    {
                        case "Алмазный меч":
                            Console.WriteLine("Алмазный меч. Каждый 3 ход наносит крит. урон\n");
                            break;
                        case "Ведро с холодной водой":
                            Console.WriteLine("Ведро с холодной водой. Каждый 5 ход замораживает соперника, заставляя его пропустить ход\n");
                            break;
                        case "Самогон":
                            Console.WriteLine("Самогон. Опьяняет разум, отравялет организм жертвы. Каждый ход -10 здоровья противнику\n");
                            break;
                        case "Кумыс":
                            Console.WriteLine("КУМЫС. Напиток Богов. Единоразово прибавляет 30 здоровья выпившему\n");
                            break;
                    }
                }
            }
        }
    }
}