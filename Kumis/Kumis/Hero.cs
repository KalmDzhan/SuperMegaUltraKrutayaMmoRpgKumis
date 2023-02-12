namespace Kumis
{
	public class Hero
	{
		public string Name { get; set; }
		public int Level { get; set; }
		public double Damage{ get;private set;}
		public double Hp { get; set; }
        public string HeroClass { get; set; }

        // Добавить оружие или броню с модификаторами:
        // CRIT - каждый 3 удар увеличивает урон на 150%
        // COLD - каждый 5 удар замораживает противника и он пропускает ход
        // POSION - каждый ход наносится дополнительно 10 урона
        // Модификаторы могут меняться в зависимости от вашей фантазии 

        public Hero(string name, string heroClass, int level)
        {
            Name = name;
            HeroClass = heroClass;
            Level = level;
            switch (HeroClass)
            {
                case "Человек":
                    Hp = 100 * level;
                    Damage = 20 * level;
                    break;
                case "Эльф":
                    Hp = 90 * level;
                    Damage = 30 * level;
                    break;
                case "Орк":
                    Hp = 120 * level;
                    Damage = 25 * level;
                    break;
                case "Бог":
                    Hp = 10000 * level;
                    Damage = 2000 * level;
                    break;
                case "Гигачад":
                    Hp = 1000000 * level;
                    Damage = 200000 * level;
                    break;
            }
        }
    }
}

