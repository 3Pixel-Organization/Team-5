using System.Collections.Generic;
using JASUtils;

[System.Serializable]
public class TilemapData
{
	public List<float[]> positions = new List<float[]>();
	public Dictionary<float[], int> tiles = new Dictionary<float[], int>();

	public TilemapData(List<TileSaveData> data)
	{
		foreach (TileSaveData tileData in data)
		{
			if (Utils.Contains(positions, tileData.position))
				tiles[Utils.GetPosition(positions, tileData.position)] = tileData.tileIndex;
			else
			{
				positions.Add(tileData.position);
				tiles.Add(tileData.position, tileData.tileIndex);
			}
		}
	}
}
