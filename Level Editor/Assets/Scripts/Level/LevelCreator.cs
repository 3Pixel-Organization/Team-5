using UnityEngine;
using JASUtils;
using static Levels;
using static Levels.Level;
using System.Collections.Generic;

public class LevelCreator : MonoBehaviour
{
	public static LevelCreator instance;

	public static ObjectCreator objectCreator;
	public static TileCreator tileCreator;

	[HideInInspector] public static List<Transform> objectsInScene = new List<Transform>();
	[HideInInspector] public static List<TileSaveData> tilesSaveData = new List<TileSaveData>();

	private void Start()
	{
		objectsInScene = new List<Transform>();
		tilesSaveData = new List<TileSaveData>();
		LoadLevel(GameManager.instance.curLevel);
	}

	public static void LoadLevel(Levels levels, string _levelName)
	{
		Level data = levels.levels[_levelName];
		LoadTilemap(data.tiles);
		LoadObjects(data.objects);
	}

	public static void LoadLevel(Level level)
	{
		LoadTilemap(level.tiles);
		LoadObjects(level.objects);
	}

	private static void LoadTilemap(TilemapData data)
	{
		foreach (float[] position in data.tiles.Keys)
		{
			Vector3Int pos = Utils.ConvertFloatArrayToVector3Int(position);
			if (tileCreator == null)
				tileCreator = TileCreator.instance;
			tileCreator.SetTile(pos);
		}
	}

	private static void LoadObjects(ObjectsData data)
	{
		foreach (float[] position in data.objects.Keys)
		{
			Vector3 pos = Utils.ConvertFloatArrayToVector3(position);
			if (objectCreator == null)
				objectCreator = ObjectCreator.instance;
			objectCreator.CreateObject(pos, objectCreator.objects[data.objects[Utils.GetPosition(data.objects.Keys, position)]]);
		}
	}
}
