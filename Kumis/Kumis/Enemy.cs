namespace Kumis
{
	public class Enemy
	{
        public string Name { get; set; }
        public int Level { get; set; }
        public double Damage { get; private set; }
        public double Hp { get; set; }
        public string EnemyClass { get; set; }

        // Добавить оружие или броню с модификаторами:
        // CRIT - каждый 3 удар увеличивает урон на 150%
        // COLD - каждый 5 удар замораживает противника и он пропускает ход
        // POSION - каждый ход наносится дополнительно 10 урона
        // Модификаторы могут меняться в зависимости от вашей фантазии 

        public Enemy(string name, string enemyClass, int level)
        {
            Name = name;
            EnemyClass = enemyClass;
            Level = level;
            switch (enemyClass)
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
                case "Гоблин":
                    Hp = 60 * level;
                    Damage = 10 * level;
                    break;
                case "Троль":
                    Hp = 150 * level;
                    Damage = 40 * level;
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

