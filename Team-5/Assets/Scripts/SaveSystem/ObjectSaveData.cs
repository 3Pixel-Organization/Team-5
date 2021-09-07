using UnityEngine;
using JASUtils;

public struct ObjectSaveData
{
	public float[] position;
	public int objectIndex;

	public ObjectSaveData(Vector3 _pos, int _index)
	{
		float[] pos = Utils.Vector3ToFloatArray(_pos);
		position = pos;
		objectIndex = _index;
	}
}
