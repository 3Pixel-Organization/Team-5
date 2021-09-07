using UnityEngine;

[CreateAssetMenu(fileName ="NewObject", menuName ="Scriptables/Object")]
public class ObjectData : ScriptableObject
{
    public new string name;
    public GameObject prefab;
    public Sprite inventoryIcon;
    public LayerMask cantBePlacedOn;
    [TextArea(10, 20)]
    public string objectDescription;

    [HideInInspector] public int index;
}
