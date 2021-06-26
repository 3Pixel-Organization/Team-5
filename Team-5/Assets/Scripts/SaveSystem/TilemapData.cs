using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TilemapData
{
	public List<float[]> positions = new List<float[]>();
	public Dictionary<float[], int> tiles = new Dictionary<float[], int>();

	public TilemapData(List<TileSaveData> data)
	{
		foreach (TileSaveData tileData in data)
		{
			if (Contains(tileData.position))
			{
				tiles[GetPosition(tileData.position)] = tileData.tileIndex;
			}
			else
			{
				positions.Add(tileData.position);
				tiles.Add(tileData.position, tileData.tileIndex);
			}
		}
	}

	private bool Contains(float[] position)
	{
		for (int i = 0; i < positions.Count; i++)
		{
			if (IsEqual(positions[i], position))
			{
				return true;
			}
		}

		return false;
	}

	private float[] GetPosition(float[] position)
	{
		for (int i = 0; i < positions.Count; i++)
		{
			if (IsEqual(positions[i], position))
			{
				return positions[i];
			}
		}

		return null;
	}

	private bool IsEqual(float[] position01, float[] position02)
	{
		if (position01[0] == position02[0] && position01[1] == position02[1] && position01[2] == position02[2])
			return true;
		else return false;
	}
}

