using UnityEngine;

public static class TilesPlacement
{
	public static Vector2Int[] fourTiles =
	{
		new Vector2Int(0, 0),
		new Vector2Int(1, 0),
		new Vector2Int(0, 1),
		new Vector2Int(1, 1)
	};

	public static Vector2Int[] line2TilesRight =
	{
		new Vector2Int(0, 0),
		new Vector2Int(1, 0)
	};

	public static Vector2Int[] line2TilesUp =
	{
		new Vector2Int(0, 0),
		new Vector2Int(0, 1)
	};

	public static Vector2Int[] line4TilesRight =
	{
		new Vector2Int(0, 0),
		new Vector2Int(1, 0),
		new Vector2Int(2, 0),
		new Vector2Int(3, 0)
	};

	public static Vector2Int[] line4TilesUp =
	{
		new Vector2Int(0, 0),
		new Vector2Int(0, 1),
		new Vector2Int(0, 2),
		new Vector2Int(0, 3)
	};

	public static Vector2Int[] a3x3sq =
	{
		new Vector2Int(0, 0),
		new Vector2Int(0, 1),
		new Vector2Int(0, 2),
		new Vector2Int(1, 0),
		new Vector2Int(1, 2),
		new Vector2Int(2, 0),
		new Vector2Int(2, 1),
		new Vector2Int(2, 2),
	};

	public static Vector2Int[] nineTiles =
	{
		new Vector2Int(0, 0),
		new Vector2Int(0, 1),
		new Vector2Int(0, 2),
		new Vector2Int(1, 0),
		new Vector2Int(1, 1),
		new Vector2Int(1, 2),
		new Vector2Int(2, 0),
		new Vector2Int(2, 1),
		new Vector2Int(2, 2),
	};
}
