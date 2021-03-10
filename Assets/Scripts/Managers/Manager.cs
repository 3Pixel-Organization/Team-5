using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager 
{
    
    //must have a method to be called when entering a new scene
    public abstract void InitScene(SceneController sceneController);

    //must have a method to handle application exit:
    public abstract void QuitGame();
}
