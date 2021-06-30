using System.Collections.Generic;
using LuaiUtils;

[System.Serializable]
public class ObjectsData
{
	public List<float[]> positions = new List<float[]>();
	public Dictionary<float[], int> objects = new Dictionary<float[], int>();

	public ObjectsData(List<ObjectSaveData> data)
	{
		foreach (ObjectSaveData objectData in data)
		{
			if (Utils.Contains(positions, objectData.position))
				objects[Utils.GetPosition(positions, objectData.position)] = objectData.objectIndex;
			else
			{
				positions.Add(objectData.position);
				objects.Add(objectData.position, objectData.objectIndex);
			}
		}
	}
}
