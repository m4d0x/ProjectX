﻿using GameLogic;


namespace UserInterface;

public class Output
{

    public static void MainMenu()
    {
        WriteLineMultiColored((ConsoleColor.Red, "- "), (ConsoleColor.White, "Welcome to the World of Heretics"), (ConsoleColor.Red, " -"));
        WriteLineMultiColored((ConsoleColor.White, "Press "), (ConsoleColor.Green, "[P]"), (ConsoleColor.White, " to play.."));
        WriteLineMultiColored((ConsoleColor.White, "..or "), (ConsoleColor.Red, "[Q]"), (ConsoleColor.White, " to quit game.."));
        //Console.WriteLine("Press [P] to play..\n..or press [Q] to quit game!");
    }

    public static void CharacterHandlerOutPut()
    {
        WriteLineMultiColored((ConsoleColor.Red, "---------"), (ConsoleColor.White, "CHARACTER"), (ConsoleColor.Red, "---------"));
        WriteLineMultiColored((ConsoleColor.Red, "[C]"), (ConsoleColor.White, "reate character"), (ConsoleColor.White, "."));
        WriteLineMultiColored((ConsoleColor.Red, "[L]"), (ConsoleColor.White, "oad character"), (ConsoleColor.White, "."));
        WriteLineMultiColored((ConsoleColor.Red, "[R]"), (ConsoleColor.White, "eturn to main menu"), (ConsoleColor.White, "."));
        //Console.WriteLine("[C]reate character");
        //Console.WriteLine("[L]oad character"); // not possible yet without db
        //Console.WriteLine("[R]eturn to main menu");
    }

    public static void ChooseCharacterVocation()
    {
        Console.WriteLine("Choose a class by pressing the corresponding alphabetical character:");
        WriteLineMultiColored((ConsoleColor.Green, "[A]"), (ConsoleColor.White, "rcher - An expert in distance fighting"), (ConsoleColor.White, "."));
        WriteLineMultiColored((ConsoleColor.Cyan, "[M]"), (ConsoleColor.White, "age - Wielder of magic and spells"), (ConsoleColor.White, "."));
        WriteLineMultiColored((ConsoleColor.Red, "[W]"), (ConsoleColor.White, "arrior - User of handheld weaponry"), (ConsoleColor.White, "."));
        //Console.WriteLine("[A]rcher - An expert in distance fighting.");
        //Console.WriteLine("[M]age - Wielder of magic and spells.");
        //Console.WriteLine("[W]arrior - User of handheld weaponry.");
    }

    public static void CharacterName(Vocation chosenVocation) //behöver kunna använda klassen till karaktären om så är möjligt
    {
        Console.Write($"Pick a suitable name for your {chosenVocation}: ");
    }

    public static void ShopMainMenu()
    {
        WriteLineMultiColored((ConsoleColor.Red, "---------"), (ConsoleColor.White, "SHOP"), (ConsoleColor.Red, "---------"));
        WriteLineMultiColored((ConsoleColor.Red, "[B] "), (ConsoleColor.White, " - Buy "), (ConsoleColor.White, "items."));
        WriteLineMultiColored((ConsoleColor.Green, "[S] "), (ConsoleColor.White, " - Sell "), (ConsoleColor.White, "items."));
        WriteLineMultiColored((ConsoleColor.Red, "[R] "), (ConsoleColor.White, " - Return "), (ConsoleColor.White, "to map."));
        //Console.WriteLine("[B]uy\n[S]ell\n[L]eave");
    }

    public static void StockInShop(List<Item> shopStock)//List<Item> stockList
    {
        
        WriteLineMultiColored((ConsoleColor.Red, "---------"), (ConsoleColor.White, "BUYING"), (ConsoleColor.Red, "---------"));
        foreach (var item in shopStock)
        {
            
            Console.WriteLine($"{item.Name} - Buy for: {item.Currency} ");
        }
        Console.WriteLine($"Example: You've bought \"item.Name\" from Shop");
        WriteLineMultiColored((ConsoleColor.Red, "[R]"), (ConsoleColor.White, "eturn "), (ConsoleColor.White, "to shop menu."));
    }

    public static void SellToShop(Character activePlayer)
    {
        foreach (var item in activePlayer.InventoryItems)
        {
            //bör listas med siffra för att avgöra vilket item som ska säljas i genom output/input
            Console.WriteLine($"{item.Name} - Sell for: {item.Currency} ");
        }
        WriteLineMultiColored((ConsoleColor.Red, "---------"), (ConsoleColor.White, "SELLING"), (ConsoleColor.Red, "---------"));
        //Console.WriteLine($"Example: Your item {activePlayer.InventoryItems[1]}");
        Console.WriteLine($"Example: Your item [Blade of souls] was sold for [10 Gold]!");
        WriteLineMultiColored((ConsoleColor.Red, "[R]"), (ConsoleColor.White, "eturn "), (ConsoleColor.White, "to shop menu."));
    }

    public static void TutorialOutput()
    {
        WriteLineMultiColored((ConsoleColor.White, "Welcome to the "), (ConsoleColor.Red, "World of Heretics "), (ConsoleColor.White, "young adventurer!"));
        Console.WriteLine($"Outside the House of Tutorial you just witnessed the map of WoH.");
        WriteLineMultiColored((ConsoleColor.White, "In this map there´s"), (ConsoleColor.Red, " 4 structures "), (ConsoleColor.White, ", giving 4 different options;\n"));
        WriteLineMultiColored((ConsoleColor.Red, " - North West - "), (ConsoleColor.White, "Our in game Shop where you can buy "), (ConsoleColor.White, "and sell your looted items."));
        WriteLineMultiColored((ConsoleColor.Red, " - North East - "), (ConsoleColor.White, "The Mountain of adventures "), (ConsoleColor.White, "(to be released shortly)."));
        WriteLineMultiColored((ConsoleColor.Red, " - South West - "), (ConsoleColor.White, "Tutorial "), (ConsoleColor.White, "(Which house you just entered and found yourself in this text)"));
        WriteLineMultiColored((ConsoleColor.Red, " - South East - "), (ConsoleColor.White, "Fighting is where you´re able to encounter monsters, "), (ConsoleColor.White, "level up and loot items.\n"));
        WriteLineMultiColored((ConsoleColor.White, "Press "), (ConsoleColor.Red, "[R] "), (ConsoleColor.White, "in order to return to map."));
        
    }

    public static void FightingOptions(Character player)
    {
        Console.WriteLine($"{player.Name}, you´ve encountered {player.FightEncounters} enemies so far in the Arena, what would you like to do?");
        WriteLineMultiColored((ConsoleColor.Red, "[F]"), (ConsoleColor.White, "ight"), (ConsoleColor.White, "!"));
        WriteLineMultiColored((ConsoleColor.Red, "[R]"), (ConsoleColor.White, "un away and live to fight another day"), (ConsoleColor.White, "!"));
        //Console.WriteLine("[F]ight!");
        //Console.WriteLine("[R]un away and live to fight another day!");
    }

    public static void FightingResult(Game game)
    {
        int playerLevel = game._player.LevelStats.Level;
        int enemyListCount = Enemy.GenerateEnemies(playerLevel).Count;
        Console.WriteLine(game.HandleFighting(Enemy.GenerateEnemy(enemyListCount, playerLevel))); // ska ändras sen
        Console.WriteLine("------------");
    }

    public static void FightWonOptions()
    {
        Console.WriteLine("You´ve defeated your enemy and won the battle!");
    }

    public static void FightLostOptions(Character player)
    {
        Console.WriteLine($"RIP {player.Name}, you´ve died and will have to restart your journey!");
        WriteLineMultiColored((ConsoleColor.Red, "[R]"), (ConsoleColor.White, "estart "), (ConsoleColor.White, "game."));
        WriteLineMultiColored((ConsoleColor.Red, "[Q]"), (ConsoleColor.White, "uit "), (ConsoleColor.White, "game."));
    }

    public static void Quit()
    {
        Console.WriteLine("Farewell young adventurer, your game is saved and we hope to see you soon!");
    }

    public static void TestRoamingMenu() //temporary fix for roaming map interactions
    {
        WriteLineMultiColored((ConsoleColor.Red, "---------"), (ConsoleColor.White, "ROAMING "), (ConsoleColor.Red, "---------"));
        Console.WriteLine("---------ROAMING---------");
        WriteLineMultiColored((ConsoleColor.Red, "[1.] "), (ConsoleColor.White, "Fight Club"), (ConsoleColor.White, "!"));
        WriteLineMultiColored((ConsoleColor.Red, "[2.] "), (ConsoleColor.White, "Shop"), (ConsoleColor.White, "!"));
        WriteLineMultiColored((ConsoleColor.Red, "[3.] "), (ConsoleColor.White, "Tutorial"), (ConsoleColor.White, "!"));
        WriteLineMultiColored((ConsoleColor.Red, "[4.] "), (ConsoleColor.White, "Leave"), (ConsoleColor.White, "!"));
        //Console.WriteLine("[1.] Fight Club");
        //Console.WriteLine("[2.] Shop");
        //Console.WriteLine("[3.] tutorial");
        //Console.WriteLine("[4.] Leave");
    }

    public static void WriteLineMultiColored(params (ConsoleColor color, string value)[] values) //formatering för snyggare writes.
    {
        Console.Write("\r");
        foreach (var value in values)
        {
            Console.ForegroundColor = value.color;
            Console.Write(value.value);
        }

        Console.Write("\r\n");
        Console.ResetColor();
    }
}