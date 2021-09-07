using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
	public static bool inBuilding = false;
	public static WorldData.BuildingData curBuilding;

	public static GameManager instance;
	public static WorldData worldData;

	private CreatorsManager cManager;
	private WorldManager wManager;

	private Keyboard kb;

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
		worldData = LoadSystem.GetData<WorldData>("World_Data.world");
		curBuilding = new WorldData.BuildingData();
	}

	private void Update()
	{
		if (INPUT.MainController.Quit.triggered)
			Application.Quit();
		if (INPUT.MainController.Save.triggered)
			wManager.Save();
		if (kb.pKey.wasPressedThisFrame)
			SaveSystem.Save("World_Data.world", new WorldData());
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

	public void UpdateWorldData() => worldData = LoadSystem.GetData<WorldData>("World_Data.world");

	private void OnApplicationQuit() => wManager.Save();
}
