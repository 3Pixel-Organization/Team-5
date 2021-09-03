using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using JASUtils;
using UnityEngine;
using static Levels;
using static Levels.Level;

public static class SaveSystem
{
    public static string path = $"{Application.persistentDataPath}/";

	public static void SaveLevel(List<TileSaveData> tilesSaveData, List<Transform> objectsInScene, Levels levels, string lvlName)
	{
		TilemapData tData = GetTilemapData(tilesSaveData);
		ObjectsData oData = GetObjectsData(objectsInScene);

		Level lvl = new Level(lvlName, oData, tData);
		if (!levels.levels.ContainsKey(lvlName))
			levels.levels.Add(lvlName, lvl);
		else levels.levels[lvlName] = lvl;

		Save("levels.lvls", levels);
	}

	public static void SaveLevelsList(Levels _levels) => Save("levels.lvls", _levels);

	public static TilemapData GetTilemapData(List<TileSaveData> tilesSaveData)
    {
        Dictionary<float[], int> tiles = new Dictionary<float[], int>();

        foreach (TileSaveData tile in tilesSaveData)
        {
            if (Utils.ContainsKey(tiles.Keys, tile.position))
                tiles[Utils.GetPosition(tiles.Keys, tile.position)] = tile.index;
            else tiles.Add(tile.position, tile.index);
        }

        TilemapData data = new TilemapData(tiles);

		return data;
    }

	public static ObjectsData GetObjectsData(List<Transform> objectsInScene)
	{
		Dictionary<float[], int> objects = new Dictionary<float[], int>();

		foreach (Transform _object in objectsInScene)
		{
			float[] pos = Utils.Vector3ToFloatArray(_object.position);
			int index = _object.GetComponent<ObjectInScene>().data.index;
			if (Utils.ContainsKey(objects.Keys, pos))
				objects[Utils.GetPosition(objects.Keys, pos)] = index;
			else objects.Add(pos, index);
		}

		ObjectsData data = new ObjectsData(objects);

		return data;
	}

	public static void Save(string _fileName, object data)
	{
        string _path = path + _fileName;

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(_path, FileMode.Create);

		formatter.Serialize(stream, data);
		stream.Close();
	}
}
