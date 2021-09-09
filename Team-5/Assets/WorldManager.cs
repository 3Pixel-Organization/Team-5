using UnityEngine;
using JASUtils;
using System.Collections.Generic;
using static WorldData;

public class WorldManager : MonoBehaviour
{
	public static WorldManager instance;

	private TileCreator tileCreator;
	private ObjectCreator objectCreator;
	private BuildingCreator bCreator;

	[HideInInspector] public List<TileSaveData> tilesData = new List<TileSaveData>();
	[HideInInspector] public List<ObjectSaveData> objectsData = new List<ObjectSaveData>();
	[HideInInspector] public List<GameObject> buildings = new List<GameObject>();

	[HideInInspector] public List<ObjectSaveData> buildingObjectsData = new List<ObjectSaveData>();
	[HideInInspector] public List<TileSaveData> buildingTilesData = new List<TileSaveData>();

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(this);
	}

	private void Start()
	{
		tileCreator = TileCreator.instance;
		objectCreator = ObjectCreator.instance;
		bCreator = BuildingCreator.instance;
	}

	public void LoadWorld(WorldData data)
	{
		LoadTilemap(data.tilemapData);
		LoadObjects(data.objectsData);
		LoadBuildings(data.buildingsData);
	}

	public void LoadTilemap(TilemapData data)
	{
		if (data.tiles == null)
			return;

		tileCreator = TileCreator.instance;
		foreach (float[] positions in data.tiles.Keys)
		{
			Vector3Int pos = Utils.FloatArrayToVector3Int(positions);
			int index = data.tiles[positions];
			if (index == 0) tileCreator.SetTile(pos, null);
			else tileCreator.SetTile(pos, tileCreator.tiles[index]);
		}
	}

	public void LoadObjects(ObjectsData data)
	{
		objectCreator = ObjectCreator.instance;
		foreach (float[] positions in data.objects.Keys)
		{
			Vector3 pos = Utils.FloatArrayToVector3(positions);
			objectCreator.CreateObject(pos, objectCreator.objects[data.objects[positions]]);
		}
	}

	public void LoadBuildings(Dictionary<string, WorldData.BuildingData> data)
	{
		bCreator = BuildingCreator.instance;
		foreach (WorldData.BuildingData building in data.Values)
		{
			Vector3 pos = Utils.FloatArrayToVector3(building.position);
			GameObject go = bCreator.CreateBuilding(pos, bCreator.buildings[building.index]);
			if (go)
			{
				BuildingInScene bInS = go.GetComponentInChildren<BuildingInScene>();
				bInS.tilemapData = building.tilemapData;
				bInS.objectsData = building.objectsData;
				bInS.name = building.name;
			}
		}
	}

	public void LoadBuilding(WorldData.BuildingData data)
	{
		LoadTilemap(data.tilemapData);
		LoadObjects(data.objectsData);
	}
	
	public void LoadBuilding(ObjectsData objectsData, TilemapData tilemapData)
	{
		LoadTilemap(tilemapData);
		LoadObjects(objectsData);
	}

	public void Save()
	{
		if (!GameManager.inBuilding)
		{
			TilemapData tiles = SaveSystem.GetTilemapData(tilesData);
			ObjectsData objects = SaveSystem.GetObjectsData(objectsData);
			Dictionary<string, WorldData.BuildingData> buildingsData = SaveSystem.GetBuildingsData(buildings);
			WorldData worldData = new WorldData(tiles, objects, buildingsData);
			SaveSystem.Save(GameManager.SaveFileName, worldData);
		}
		else
		{
			WorldData.BuildingData bData = GameManager.curBuilding;
			bData.tilemapData = SaveSystem.GetTilemapData(buildingTilesData);
			bData.objectsData = SaveSystem.GetObjectsData(buildingObjectsData);
			GameManager.worldData.buildingsData[bData.name] = bData;
			SaveSystem.Save(GameManager.SaveFileName, GameManager.worldData);
		}
	}
}
