using UnityEngine;

[CreateAssetMenu(fileName ="New Object", menuName ="Object/Create New Object")]
public class ObjectData : ScriptableObject
{
	public new string name;
	public Transform prefab;
	[HideInInspector] public int index;
}
