using System.IO;
using UnityEngine;
using System.Collections.Generic;
using JASUtils;
using System.Runtime.Serialization.Formatters.Binary;
using static WorldData;

public static class SaveSystem
{
	public static string path = Application.persistentDataPath + "/";

	public static void Save(string fileName, object data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(path + fileName, FileMode.Create);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static TilemapData GetTilemapData(List<TileSaveData> tileSaveDatas)
	{
		Dictionary<float[], int> tiles = new Dictionary<float[], int>();

		foreach (TileSaveData tileData in tileSaveDatas)
		{
			if (Utils.ContainsKey(tiles.Keys, tileData.position))
				tiles[Utils.GetPosition(tiles.Keys, tileData.position)] = tileData.tileIndex;
			else
			{
				tiles.Add(tileData.position, tileData.tileIndex);
			}
		}

		return new TilemapData(tiles);
	}

	public static ObjectsData GetObjectsData(List<ObjectSaveData> tileSaveDatas)
	{
		Dictionary<float[], int> tiles = new Dictionary<float[], int>();

		foreach (ObjectSaveData objectData in tileSaveDatas)
		{
			if (Utils.ContainsKey(tiles.Keys, objectData.position))
				tiles[Utils.GetPosition(tiles.Keys, objectData.position)] = objectData.objectIndex;
			else
			{
				tiles.Add(objectData.position, objectData.objectIndex);
			}
		}

		return new ObjectsData(tiles);
	}

	public static Dictionary<string, WorldData.BuildingData> GetBuildingsData(List<GameObject> buildings)
	{
		Dictionary<string, WorldData.BuildingData> data = new Dictionary<string, WorldData.BuildingData>();

		foreach (GameObject building in buildings)
		{
			BuildingInScene bInS = building.GetComponent<BuildingInScene>();
			TilemapData tData = bInS.tilemapData;
			ObjectsData oData = bInS.objectsData;
			int index = bInS.data.index;
			string name = $"{index}_{building.transform.position}";
			float[] position = Utils.Vector3ToFloatArray(building.transform.position);

			WorldData.BuildingData buildingData = new WorldData.BuildingData(tData, oData, index, position, name);

			data.Add(name, buildingData);
		}

		return data;
	}
}
