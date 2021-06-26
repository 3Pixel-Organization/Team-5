using UnityEngine;

public class ObjectSaveData
{
	public float[] position;
	public int objectIndex;

	public ObjectSaveData(Vector3 _pos, int _index)
	{
		float[] pos = DataConverter.ConvertVector3ToFloatArray(_pos);
		position = pos;
		objectIndex = _index;
	}
}
