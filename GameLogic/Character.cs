namespace GameLogic;

public class Character : Entity
{
    public int CoordX { get; set; }
    public int CoordY { get; set; }
    public List<Item> InventoryItems { get; set; }

    public Character(string name, int currency = 0, Vocation vocation = Vocation.Unassigned) : base(name, vocation,
        currency)
    {
        CoordX = 45; // hardkodat spawn, change later
        CoordY = 15;  // hardkodat spawn, change later
        InventoryItems = new List<Item>();
    }

    public static void CheckEntityVocation(Character activePlayer)
    {
        if (activePlayer.Vocation == Vocation.Archer)
        {
            Stats.SetArcher(activePlayer);
        }

        if (activePlayer.Vocation == Vocation.Mage)
        {
            Stats.SetMage(activePlayer);
        }

        if (activePlayer.Vocation == Vocation.Warrior)
        {
            Stats.SetWarrior(activePlayer);
        }
    }


//metod som kollar vocation,
// använd klassen skills för att kolla setta stats/skills
//alla metoder i skills är static så går att kalla på
    public void MoveUp()
    {
        CoordY--;
    }

    public void MoveDown()
    {
        CoordY++;
    }

    public void MoveLeft()
    {
        CoordX--;
    }

    public void MoveRight()
    {
        CoordX++;
    }

    // public static void ChooseCharcter()
    // {

    //     ConsoleKey x = Console.ReadKey().Key;

    //     if(x == ConsoleKey.D1)
    //     {
    //     List<Character> myCharacter = GetAllCharacters();

    //     foreach (Character currentCharacter in myCharacter)
    //     {

    //     }

    //     }

    // }

    // public static List<Character> GetAllCharacters()
    // {
    //     return new List<Character>()
    //     {
    //     new("Omar", 1, 0, 1),    
    //     new("Khaled", 2, 0, 1),    
    //     new("Robert", 3, 0, 1)
    //     };

    // }
}