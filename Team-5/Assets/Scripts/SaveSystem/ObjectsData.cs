using System.Collections.Generic;

[System.Serializable]
public class ObjectsData
{
	public List<float[]> positions = new List<float[]>();
	public Dictionary<float[], int> objects = new Dictionary<float[], int>();

	public ObjectsData(List<ObjectSaveData> data)
	{
		foreach (ObjectSaveData objectData in data)
		{
			if (Contains(objectData.position))
				objects[GetPosition(objectData.position)] = objectData.objectIndex;
			else
			{
				positions.Add(objectData.position);
				objects.Add(objectData.position, objectData.objectIndex);
			}
		}
	}

	private bool Contains(float[] position)
	{
		for (int i = 0; i < positions.Count; i++)
		{
			if (IsEqual(positions[i], position))
				return true;
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
