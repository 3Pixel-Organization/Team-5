using UnityEngine;

[CreateAssetMenu(fileName ="New Building", menuName ="Scriptables/Building")]
public class BuildingData : ScriptableObject
{
    public new string name;
    public GameObject prefab;
    public Sprite menuIcon;
    public LayerMask cantBePlacedOn;
    [TextArea(10, 20)]
    public string description;

    [HideInInspector] public int index;
}
