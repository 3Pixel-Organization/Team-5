using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	private static string tilemapPath = Application.persistentDataPath + "/tilemap.tiles";
	private static string objectsPath = Application.persistentDataPath + "/objects.objets";

	public static void SaveTilemap(TilemapData tilemapData)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(tilemapPath, FileMode.Create);

		formatter.Serialize(stream, tilemapData);
		stream.Close();
	}

	public static void SaveObjects(ObjectsData data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(objectsPath, FileMode.Create);

		formatter.Serialize(stream, data);
		stream.Close();
	}
}
