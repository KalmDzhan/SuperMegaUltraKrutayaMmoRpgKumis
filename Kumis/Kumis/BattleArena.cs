namespace Kumis
{
    public class BattleArena
    {
        public Enemy Enemy { get; set; }
        public Hero Hero { get; set; }
        public Item Item { get; set; }
        public BackPack BackPack { get; set; }

        public BattleArena(Enemy enemy, Hero hero, Item item, BackPack backPack)
        {
            Enemy = enemy;
            Hero = hero;
            Item = item;
            BackPack = backPack;
        }
        public int Battle(bool isHeroAttacks) {

            //Реализовать пошаговый бой до окончании жизни одного из участников битвы
            //Вернуть 1 в случае победы. 0 - поражение
            Console.WriteLine("\nБитва началась!");
            int attackCount = 0;
            double damage;
            do
            {
                Console.WriteLine();

                if (isHeroAttacks == true)
                {
                    attackCount++;
                    damage = Hero.Damage + Item.Damage;
                    isHeroAttacks = false;

                    if (Item.Name == "Алмазный меч" && attackCount % 3 == 0)
                    {
                        damage *= 1.5;

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Критический урон! Похоже в вашем инвентаре есть Алмазный меч");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if(Item.Name == "Ведро с холодной водой" && attackCount % 5 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Заморозка. {Enemy.Name} пропускает ход. Похоже в вашем инвентаре есть Ведро с холодной водой");
                        Console.ForegroundColor = ConsoleColor.White;

                        isHeroAttacks = true;
                    }
                    else if (Item.Name == "Самогон")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вы напоили своего противника, теперь у него отнимается 10 hp");
                        Console.ForegroundColor = ConsoleColor.White;

                        Enemy.Hp -= 10;
                    }
                    else if (Item.Name == "Кумыс")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выпили КУМЫС, у вас прибавилось 20 hp");
                        Console.ForegroundColor = ConsoleColor.White;

                        Hero.Hp += 20;
                        BackPack.Remove(Item.Slot);
                    }
                    Enemy.Hp -= damage;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Enemy.Name + " получил урон. Так держать! Вы нанесли " + damage + " урона");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    damage = Enemy.Damage;
                    isHeroAttacks = true;

                    Hero.Hp -= damage;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вас атакуют! Вам нанесли " + damage + " урона");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"\n{Hero.Name}: (Level: {Hero.Level}, HP: {Hero.Hp}, Damage: {Hero.Damage})");
                Console.WriteLine($"{Enemy.Name}: (Level: {Enemy.Level}, HP: {Enemy.Hp}, Damage: {Enemy.Damage})\n");

                if (Hero.Hp <= 0)
                {
                    Hero.Hp = 0;
                    return 0;
                }
                else if(Enemy.Hp <= 0)
                {
                    Enemy.Hp = 0;
                    Hero.Level += 1;
                    return 1;
                }
                Console.ReadKey();
            }
            while (true);
        }
        public void ShowStats()
        {
            Console.WriteLine($"\n{Hero.Name}: (Level: {Hero.Level}, HP: {Hero.Hp}, Damage: {Hero.Damage})");
        }
    }
}
