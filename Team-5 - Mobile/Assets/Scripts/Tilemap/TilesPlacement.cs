using UnityEngine;
using System.Collections.Generic;


public enum TilesPlacementType
{
	oneTile,
	fourTiles,
	nineTiles,
	line2TilesRight,
	line2TilesUp,
	line4TilesRight,
	line4TilesUp,
	a3x3sq,
	a4x4sq
}

public static class TilesPlacement
{
	private static TileCreator _tCreator;
	private static TileCreator tCreator
	{
		get
		{
			if (_tCreator == null)
				_tCreator = TileCreator.instance;

			return _tCreator;
		}
	}

	public static Vector2Int[] GetPlacement(TilesPlacementType _type)
	{
		return toTilesPlacement[_type.ToString()];
	}

	public static void Init()
	{
		toTilesPlacement = new Dictionary<string, Vector2Int[]>()
		{
			{ "oneTile", oneTile },
			{ "fourTiles", fourTiles },
			{ "line2TilesRight", line2TilesRight },
			{ "line2TilesUp", line2TilesUp },
			{ "line4TilesRight", line4TilesRight },
			{ "line4TilesUp", line4TilesUp },
			{ "a3x3sq", a3x3sq },
			{ "nineTiles", nineTiles },
			{ "a4x4sq", a4x4sq }
		};
	}

	private static TilesPlacementType _type;

	public static TilesPlacementType type
	{
		get { return _type; }
		set
		{
			_type = value;
			tCreator.ChangeOnTilePlacementSize();
		}
	}

	public static Dictionary<string, Vector2Int[]> toTilesPlacement;

	private static readonly Vector2Int[] oneTile = { new Vector2Int(0, 0) };

	private static readonly Vector2Int[] fourTiles =
	{
		new Vector2Int(0, 0),
		new Vector2Int(1, 0),
		new Vector2Int(0, 1),
		new Vector2Int(1, 1)
	};

	private static readonly Vector2Int[] line2TilesRight =
	{
		new Vector2Int(0, 0),
		new Vector2Int(1, 0)
	};

	private static readonly Vector2Int[] line2TilesUp =
	{
		new Vector2Int(0, 0),
		new Vector2Int(0, 1)
	};

	private static readonly Vector2Int[] line4TilesRight =
	{
		new Vector2Int(0, 0),
		new Vector2Int(1, 0),
		new Vector2Int(2, 0),
		new Vector2Int(3, 0)
	};

	private static readonly Vector2Int[] line4TilesUp =
	{
		new Vector2Int(0, 0),
		new Vector2Int(0, 1),
		new Vector2Int(0, 2),
		new Vector2Int(0, 3)
	};

	private static readonly Vector2Int[] a3x3sq =
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

	private static readonly Vector2Int[] nineTiles =
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

	private static readonly Vector2Int[] a4x4sq =
	{
		new Vector2Int(0, 0),
		new Vector2Int(1, 0),
		new Vector2Int(2, 0),
		new Vector2Int(3, 0),
		new Vector2Int(0, 1),
		new Vector2Int(0, 2),
		new Vector2Int(0, 3),
		new Vector2Int(3, 1),
		new Vector2Int(3, 2),
		new Vector2Int(3, 3),
		new Vector2Int(2, 3),
		new Vector2Int(1, 3),
	};
}
