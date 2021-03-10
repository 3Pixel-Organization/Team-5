using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : Manager
{

    private static GameManager instance;
    
    //handle to sceneController
    SceneController sceneController;


    //Global State Management
    public enum GlobalGameState { Splash = 0, GameMenu, GameMenuUpgrades, GameMenuPlayer, InGame, InGamePaused, InGameEndArea, InGameUpgrading, InGameNextLevel, InGameDied };
    public static GlobalGameState GameState { get; set; }

    public static GameManager Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
                GameState = GlobalGameState.Splash;
            }
            return instance;

        }
    }

    public override void InitScene(SceneController _sceneController)
    {
        this.sceneController = _sceneController;

    }

    

    public override void QuitGame()
    {
        //Game Manager is the one closing the App

        //yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }

}
