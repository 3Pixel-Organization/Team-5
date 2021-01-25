using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building")]
public class SOBuilding : ScriptableObject
{
    enum ObjectType{
        ground,
        wall,
        door,
    }

    [SerializeField] ObjectType gridAppartenance;
    public int[] ressources;


    public bool posCheck(Vector2 pos){
        //This function checks if the position given is taken (so you cant build on it) and if it is return false, otherwise return true
        return false;
    }

    public bool ressCheck(){
        //This function checks if the player has enough ressources to build the given building and he does return true, otherwise return false
        return false;
    }

    public int[] getRessources(){
        return ressources;
    }
}
