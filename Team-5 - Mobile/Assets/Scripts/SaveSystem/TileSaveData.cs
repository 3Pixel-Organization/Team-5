using UnityEngine;
using JASUtils;

public class TileSaveData
{
	public float[] position;
	public int tileIndex;

	public TileSaveData(Vector3Int _pos, int _index)
	{
		float[] pos = Utils.ConvertVector3ToFloatArray(_pos);
		position = pos;
		tileIndex = _index;
	}
}
