using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
	public static bool inBuilding = false;
	public static WorldData.BuildingData curBuilding;
	public static string SaveFileName { get { return "World_Data.world"; } }

	public static GameManager instance;
	public static WorldData worldData;

	private CreatorsManager cManager;
	private WorldManager wManager;

	private Keyboard kb;

	private bool clearData = false;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else Destroy(gameObject);

		TilesPlacement.Init();
		INPUT.Init();

		DontDestroyOnLoad(this);
	}

	private void Start()
	{
		cManager = CreatorsManager.instance;
		wManager = WorldManager.instance;
		kb = InputSystem.GetDevice<Keyboard>();
		if (!File.Exists($"{SaveSystem.path}{SaveFileName}"))
			SaveSystem.Save(SaveFileName, new WorldData());
		worldData = LoadSystem.GetData<WorldData>(SaveFileName);
		curBuilding = new WorldData.BuildingData();
	}

	private void Update()
	{
		if (INPUT.MainController.Quit.triggered && !SceneLoader.isLoadoingScene)
			Application.Quit();
		if (kb.pKey.wasPressedThisFrame)
			clearData = true;
	}

	public WorldData.BuildingData GetBuildingData(string name)
	{
		foreach (WorldData.BuildingData building in worldData.buildingsData.Values)
		{
			if (building.name == name)
				return building;
		}

		return new WorldData.BuildingData();
	}

	public WorldData.BuildingData GetBuildingData(BuildingInScene bInS)
	{
		foreach (WorldData.BuildingData building in worldData.buildingsData.Values)
		{
			if (building.name == bInS.name)
				return building;
		}

		return new WorldData.BuildingData();
	}

	public void UpdateWorldData() => worldData = LoadSystem.GetData<WorldData>(SaveFileName);

	private void OnApplicationQuit()
	{
		if (clearData)
			SaveSystem.Save(SaveFileName, new WorldData());
		else wManager.Save();
	}
}
