using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRessources : MonoBehaviour
{

    
    #region Singleton
    [SerializeField] private static PlayerRessources INSTANCE = null;
    private PlayerRessources(){

    }

    private static void createInstance(){
        if(INSTANCE == null){
            Debug.Log("No instance of PlayerRessources Available");
            INSTANCE = new PlayerRessources();
        }
    }

    private static PlayerRessources getInstance(){
        if(INSTANCE == null) createInstance();
        
        return INSTANCE;
    }


    #endregion



    enum allRessources{

    }

    
    public int[] ressources;
}
