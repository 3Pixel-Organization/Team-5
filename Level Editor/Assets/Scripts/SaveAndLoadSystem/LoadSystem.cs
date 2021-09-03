using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using JASUtils;
using static Levels;
using static Levels.Level;

public static class LoadSystem
{
    public static string path = $"{Application.persistentDataPath}/";
	private static ObjectCreator objectCreator;
	private static TileCreator tileCreator;

	public static bool FileExists(string fileName)
	{
		string _path = path + fileName;
		if (File.Exists(_path))
			return true;
		else return false;
	}

    public static T GetData<T>(string fileName)
	{
		string _path = path + fileName;
		if (File.Exists(_path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(_path, FileMode.Open);

			T data = (T)formatter.Deserialize(stream);
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError($"Save file not found in {_path}!");
			return default(T);
		}
	}

	public static Level GetLevel(Levels _levels, string _levelName) => _levels.levels[_levelName];
}
