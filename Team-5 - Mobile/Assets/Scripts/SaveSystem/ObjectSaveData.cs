using UnityEngine;
using JASUtils;

public class ObjectSaveData
{
	public float[] position;
	public int objectIndex;

	public ObjectSaveData(Vector3 _pos, int _index)
	{
		float[] pos = Utils.ConvertVector3ToFloatArray(_pos);
		position = pos;
		objectIndex = _index;
	}
}
