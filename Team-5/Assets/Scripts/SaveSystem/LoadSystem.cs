using System.IO;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

public static class LoadSystem
{
	private static TileCreator tCreator;
	private static ObjectCreator oCreator;

	private static string tilemapPath = Application.persistentDataPath + "/tilemap.tiles";
	private static string objectsPath = Application.persistentDataPath + "/objects.objets";

	private static TilemapData GetTilemapData()
	{
		if (File.Exists(tilemapPath))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(tilemapPath, FileMode.Open);

			TilemapData data = (TilemapData)formatter.Deserialize(stream);
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError($"Save file not found in :{tilemapPath}");
			return null;
		}
	}

	private static ObjectsData GetObjectsData()
	{
		if (File.Exists(objectsPath))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(objectsPath, FileMode.Open);

			ObjectsData data = (ObjectsData)formatter.Deserialize(stream);
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError($"Save file not found in :{objectsPath}");
			return null;
		}
	}

	public static IEnumerator LoadTilemapData()
	{
		if (tCreator == null)
			tCreator = TileCreator.instance;

		TilemapData data = GetTilemapData();

		for (int i = 0; i < data.positions.Count; i++)
		{
			Vector3Int pos = DataConverter.ConvertFloatArrayToVector3Int(data.positions[i]);
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

		ObjectsData data = GetObjectsData();

		for (int i = 0; i < data.positions.Count; i++)
		{
			Vector3 pos = DataConverter.ConvertFloatArrayToVector3(data.positions[i]);
			oCreator.CreateObject(pos, oCreator.objects[data.objects[data.positions[i]]]);
			yield return null;
		}
	}
}
