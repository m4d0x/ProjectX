﻿using DataManager;

namespace GameLogic;

public class Game // plumming code
{
    // this is where shit goes down
    private List<Item> _itemListDB;
    public Shop Shop;
    public Character Player { get; set; }

    public Game()
    {
        _itemListDB = new(); // itemListDB temp but loadFromDB?
        Player = new Character("Unassigned", Load.SelectCountSqlTable("`character`", "id") + 1);
        Shop = new Shop(Player.Vocation);
    }

    public bool LoadCharacter(int id)
    {
        List<Character> tempPlayer = Load.LoadFromDb<Character>("`character`", id);

        if (tempPlayer.Count == 1)
        {
            Player = tempPlayer[0];
            return true;
        }

        return false;
    }

    public void SaveNewCharacter()
    {
        object data = new
        {
            Player.Name,
            Player.LevelStats.Experience,
            Player.MaxHp,
            Player.Currency,
            vocation = (int)Player.Vocation,
            PositionX = Player.CoordX,
            PositionY = Player.CoordY
        };

        Save.SaveNewToDb("`character`", data,
            "name, experience, health, gold, vocation, positionX, positionY",
            "@Name, @Experience, @MaxHp, @Currency, @vocation, @PositionX, @PositionY");
    }

    public void UpdateActiveCharacterInDb() //bobbis
    {
        object data = new
        {
            Player.Id,
            Player.LevelStats.Experience,
            Player.MaxHp,
            Player.Currency,
            PositionX = Player.CoordX,
            PositionY = Player.CoordY
        };

        Save.UpdateCharacterInDb("`character`", data,
            "`experience`, `health`, `gold`, `positionX`, `positionY`",
            "@Experience, @MaxHp, @Currency, @PositionX, @PositionY");
    }


    public string HandleFighting(Enemy enemy) // returns true if hero won else false
    {
        string battleInfo = $"------------\n" +
                            $"{Player.Name} VS {EnemyHandler.GetRandomEnemy(Player.LevelStats.Level).Name}" +
                            $"\n------------\n";
        int lostHearts = 0;
        //Console.WriteLine($"{_player.Name} vs {tempEnemy.Name}");

        while (true)
        {
            if (Player.Health <= 0) // checks if the Player died
            {
                battleInfo += $"{Player.Name} was defeated in battle... Shame!";
                return battleInfo;
            }

            enemy.Health -= Player.DealDamage(); // Player strikes enemy!

            if (enemy.Health <= 0) // checks if the Enemy died
            {
                battleInfo += $"{enemy.Name} was defeated in battle! {Player.Name} will be rewarded!\n" +
                              $"Gained: {enemy.LevelStats.Experience}xp!\n";
                battleInfo += HandleRewards(enemy);

                battleInfo += $"Lost: {lostHearts} hearts, Hearts left: {Player.Health}";

                Player.FightEncounters++;

                return battleInfo;
            }

            Player.Health -= enemy.DealDamage(); // Enemy strikes Player!
            lostHearts += enemy.DealDamage(); // used to show result of fight
        }
    }

    public string HandleRewards(Enemy killedEnemy)
    {
        string returnMessage = "";

        Player.Currency += killedEnemy.Currency; // gold
        returnMessage += $"Gained {killedEnemy.Currency} Gold!\n";
        returnMessage += $"Current owned Gold: {Player.Currency}\n";

        returnMessage += LevelUpHandler(killedEnemy.LevelStats.Experience); // xp

        return returnMessage;
    }

    public string LevelUpHandler(int gainedExperience)
    {
        int levelsGained = Player.LevelStats.GainExperience(gainedExperience);

        if (levelsGained == 1)
        {
            Player.IncreaseMaxHpOnLevelUp();
            Player.HealCharacter();
            return "You feel a wierd surge of power gained! +10 health cap, and hearts fully healed!\n" +
                   $"{Player.Name} gained {levelsGained} Levels\n{Player.LevelStats.ToString()}\n";
        }

        if (levelsGained >= 2)
        {
            Player.IncreaseMaxHpOnLevelUp();
            Player.HealCharacter();

            return "You feel a wierd surge of power gained! +10 health cap, and hearts fully healed!\n" +
                   $"{Player.Name} gained {levelsGained} Levels\n{Player.LevelStats.ToString()}\n";
        }

        return $"{Player.Name} gained no Levels\n{Player.LevelStats.ToString()}\n";
    }
}