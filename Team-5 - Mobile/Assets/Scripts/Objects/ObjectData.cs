using UnityEngine;

[CreateAssetMenu(fileName ="NewObject", menuName ="Tilemap/Creat A New GameObject")]
public class ObjectData : ScriptableObject
{
    public GameObject prefab;
    public Sprite inventoryIcon;
    public LayerMask cantBePlacedOn;
    [TextArea(10, 20)]
    public string objectDescription;

    [HideInInspector] public int index;
}
