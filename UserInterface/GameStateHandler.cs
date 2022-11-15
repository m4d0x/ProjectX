﻿namespace UserInterface;

using GameLogic;

public class GameStateHandler
{
    public static GameState SwitchMenu(GameState gameState, Game game)
    {
        switch (gameState)
        {
            case GameState.MainMenu: // klar
                Output.MainMenu();
                gameState = Input.MainMenuInput();
                break;

            case GameState.CharacterHandler: // klar
                Output.CharacterHandlerOutPut();
                gameState = Input.CharacterMenuInput();
                break;
            
            case GameState.LoadCharacter: // inte klar än
                Console.WriteLine("Load feature not implemented yet!");
                gameState = GameState.CharacterHandler;
                break;
            
            case GameState.SetCharacterVocation: // Klar
                Output.ChooseCharacterVocation();
                gameState = Input.CharacterVocationInput();
                break;
            
            case GameState.SetCharacterName: // Klar
                Output.CharacterName();
                gameState = Input.CharacterNameInput(game._player);
                break;

            case GameState.RoamingMap: // väntar på robert
                Output.TestRoamingMenu();
                gameState = Input.TestRoamingMenuInput();
                // Returns GameState.TutorialMenu, GameState.ShopMenu, GameState.FightingMenu or GameState.Quit
                break;

            case GameState.ShopMenu: // inte klar än
                Output.ShopMenu();
                gameState = Input.ShopMenuInput();
                break;

            case GameState.BuyFromShop: // inte klar än
                Output.BuyFromShopMenu(Shop.Stock.ToList());
                gameState = Input.ShopBuyMenuInput();
                break;

            case GameState.SellInShop: // inte klar än
                Output.SellInShop();
                gameState = Input.ShopSellMenuInput();
                break;

            case GameState.TutorialMenu: // inte klar än
                Output.TutorialMenu(game._player);
                gameState = Input.TutorialMenuInput();
                break;

            case GameState.FightMenu: // inte klar än, behöver hantera när man vinner
                Output.FightStartMenu(game._player);
                gameState = Input.FightingMenuInput();
                // Returns GameState.RoamingMap, GameState.WonMenu or LostMenu
                break;
            
            case GameState.Fighting: // inte klar än
                Output.FightingMenu(game);
                if (game._player.Health <= 0)
                {
                    gameState = GameState.LostMenu;
                }
                // else if (//won condition)
                // {
                //     
                // }
                else
                {
                    gameState = GameState.FightMenu;   
                }
                break;

            case GameState.WonMenu: // inte klar än
                Output.WonMenu();
                gameState = GameState.QuitGame;
                break;

            case GameState.LostMenu: // inte klar än
                Output.LooseMenu();
                gameState = GameState.QuitGame;
                break;

            case GameState.QuitGame: // inte klar än, behöver spara osv
                Output.Quit();
                gameState = GameState.ExitProgram;
                break;
        }

        return gameState;
    }
}