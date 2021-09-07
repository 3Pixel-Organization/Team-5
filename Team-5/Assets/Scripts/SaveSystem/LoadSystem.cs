using System.IO;
using UnityEngine;
using static WorldData;
using System.Runtime.Serialization.Formatters.Binary;
using JASUtils;

public static class LoadSystem
{
	private static string path = Application.persistentDataPath + "/";

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
}
