using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewTile", menuName = "Tilemap/Create A New Tile")]
public class TileData : ScriptableObject
{
    public TileType type;
	public bool isRuledTile;
    public Tile tile;
	public RuleTile ruleTile;
	public LayerMask cantBePlacedOn;
	[HideInInspector] public int index;
}

public enum TileType
{
	Ground,
	OnGround,
}
