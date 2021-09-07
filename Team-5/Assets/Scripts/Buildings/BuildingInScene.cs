using UnityEngine;
using static WorldData;

public class BuildingInScene : MonoBehaviour
{
    [HideInInspector] public BuildingData data;
    [HideInInspector] public ObjectsData objectsData;
    [HideInInspector] public TilemapData tilemapData;
    [HideInInspector] public new string name = string.Empty;
}
