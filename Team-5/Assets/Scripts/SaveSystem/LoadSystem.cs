using System.IO;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using JASUtils;

public static class LoadSystem
{
	private static TileCreator tCreator;
	private static ObjectCreator oCreator;

	private static string path = Application.persistentDataPath + "/";
	private static string tilemapPath = Application.persistentDataPath + "/tilemap.tiles";
	private static string objectsPath = Application.persistentDataPath + "/objects.objets";

	public static T GetData<T>(string _fileName)
	{
		string _filePath = path + _fileName;

		if (File.Exists(_filePath))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(_filePath, FileMode.Open);

			T data = (T)formatter.Deserialize(stream);
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError($"Save file not found in :{_filePath}");
			return default(T);
		}
	}

	public static IEnumerator LoadTilemapData()
	{
		if (tCreator == null)
			tCreator = TileCreator.instance;

		TilemapData data = GetData<TilemapData>("tilemap.tiles");

		for (int i = 0; i < data.positions.Count; i++)
		{
			Vector3Int pos = Utils.ConvertFloatArrayToVector3Int(data.positions[i]);
			TilesPlacement.type = TilesPlacementType.oneTile;
			if (data.tiles[data.positions[i]] == 0)
				tCreator.SetTile(pos, null);
			else tCreator.SetTile(pos, tCreator.tiles[data.tiles[data.positions[i]]]);
			yield return null;
		}
	}

	public static IEnumerator LoadObjects()
	{
		if (oCreator == null)
			oCreator = ObjectCreator.instance;

		ObjectsData data = GetData<ObjectsData>("objects.objets");

		for (int i = 0; i < data.positions.Count; i++)
		{
			Vector3 pos = Utils.ConvertFloatArrayToVector3(data.positions[i]);
			oCreator.CreateObject(pos, oCreator.objects[data.objects[data.positions[i]]]);
			yield return null;
		}
	}
}
