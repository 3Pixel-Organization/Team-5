using UnityEngine;
using JASUtils;

public struct TileSaveData
{
	public float[] position;
	public int tileIndex;

	public TileSaveData(Vector3Int _pos, int _index)
	{
		float[] pos = Utils.Vector3ToFloatArray(_pos);
		position = pos;
		tileIndex = _index;
	}
}
