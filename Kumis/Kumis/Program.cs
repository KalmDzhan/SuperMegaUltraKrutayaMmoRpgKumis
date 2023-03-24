using Kumis;

Random rand = new();
//Инициализировать классы. И начать битву 

// Дополнительное задание на 5.
// Реализовать механизм лута предметов с противника в случае победы

Console.Write("Кто ты, Воин?: ");
string heroName = Console.ReadLine();

Console.WriteLine("Выбери класс героя:");
Console.WriteLine("1 - Человек, 2 - Эльф, 3- Орк");
char heroClassKey = Console.ReadKey().KeyChar;
string heroClass = "";

switch (heroClassKey)
{
    case '1':
        heroClass = "Человек";
        break;
    case '2':
        heroClass = "Эльф";
        break;
    case '3':
        heroClass = "Орк";
        break;
    default:
        break;
}

string enemyName = "Орк";

Console.WriteLine("\nВы наткнулись на загадочный сундук");
Console.ReadKey();

var BackPack = new BackPack(10);
var Item = BackPack.Looting();
var Hero = new Hero(heroName, heroClass, 1);
var Enemy = new Enemy(enemyName, enemyName, 1);
var BattleArena = new BattleArena(Enemy, Hero, Item, BackPack);

Console.ReadKey();
Console.WriteLine("\nПохоже, что на вас нарвался " + enemyName);

if (BattleArena.Battle(true) == 1)
{
    Console.WriteLine($"{Hero.Name} одержал победу");
    Console.ReadKey();
    BackPack.Looting();
}
else
{
    Console.WriteLine($"{Enemy.Name} одержал победу");
    Console.WriteLine("Капец ты лох!!!");
    Console.WriteLine("Вы потеряли все свои вещи");
    for (int i = 1; i < BackPack.items.Length; i++)
    {
        BackPack.Remove(i);
    }
}

Choose();
void Choose()
{
    Console.WriteLine("\n1 - Показать хп / 2 - Показать инвентарь / 3 - Удалить предмет / Любая другая кнопка - Пойти дальше");
    char choose = Console.ReadKey().KeyChar;
    switch (choose)
    {
        case '1':
            BattleArena.ShowStats();
            Choose();
            break;
        case '2':
            BackPack.Show();
            Choose();
            break;
        case '3':
            Console.WriteLine("\nВведи слот предмета, который хочешь удалить");
            int removeSlot = Convert.ToInt32(Console.ReadLine());
            BackPack.Remove(removeSlot);
            Choose();
            break;
        default:
            break;
    }
}
