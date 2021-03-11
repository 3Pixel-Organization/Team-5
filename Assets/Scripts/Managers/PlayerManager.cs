using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerManager : Manager
{
    private static PlayerManager instance;

    const string MASTER_VOLUME_KEY = "master volume";
    
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    //handle to sceneController
    SceneController sceneController;    

    public static PlayerManager Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
                
            }
            return instance;

        }
    }

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }            
        else
        {
            Debug.LogError("Volume outside of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }


    public override void InitScene(SceneController _sceneController)
    {
        this.sceneController = _sceneController;
    }

    public override void QuitGame()
    {

    }
}
