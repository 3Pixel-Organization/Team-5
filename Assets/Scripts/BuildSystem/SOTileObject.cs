using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "New Tile", menuName = "TileObject")]
public class SOTileObject : ScriptableObject
{
    public enum ObjectType{
        ground,
        wall,
        door,
    }

    [SerializeField] ObjectType gridAppartenance;

    public string TileName;
    public int[] ressources;

    public Tile sprite;



    public int[] getRessources(){
        return ressources;
    }

    public ObjectType getGridAppartenance(){
        return gridAppartenance;
    }

}
