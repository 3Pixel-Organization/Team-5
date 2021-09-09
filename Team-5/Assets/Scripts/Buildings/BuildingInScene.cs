using UnityEngine;
using static WorldData;

public class BuildingInScene : MonoBehaviour
{
    [HideInInspector] public BuildingData data;
    [HideInInspector] public ObjectsData objectsData = new ObjectsData();
    [HideInInspector] public TilemapData tilemapData = new TilemapData();
    [HideInInspector] public new string name = string.Empty;
}
