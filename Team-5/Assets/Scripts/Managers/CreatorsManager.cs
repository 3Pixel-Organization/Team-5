using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

public enum CreateMode
{
	Object,
	Tile
}

public class CreatorsManager : MonoBehaviour
{
	public static CreatorsManager instance;
	public static bool isCreate = false;
	public static CreateMode createMode = CreateMode.Tile;

	[FormerlySerializedAs("ObjectCreator")] public ObjectCreator oCreator;
	public TileCreator tCreator;

	public delegate void OnCreateOptionChanged();
	public static event OnCreateOptionChanged CreateOptionChanged;
	public delegate void OnCreatModeChanged();
	public static event OnCreatModeChanged CreateModeChanged;

	[HideInInspector] public TileData selectedTile;
	[HideInInspector] public ObjectData selectedObject;
	[HideInInspector] public GameObject selectedGameObject;
	[HideInInspector] public List<TileSaveData> tilesData = new List<TileSaveData>();
	[HideInInspector] public List<ObjectSaveData> objectsData = new List<ObjectSaveData>();

	private bool prevIsCreate;

	private UIManager uiManager;
	private Grid grid;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else Destroy(gameObject);

		isCreate = false;
		createMode = CreateMode.Tile;
	}

	private void Start()
	{
		uiManager = UIManager.instance;
		grid = GetComponentInChildren<Grid>();
	}

	private void Update()
	{
		GetMousePosition();

		if (Input.GetKeyDown(KeyCode.T) && !uiManager.inventory.activeSelf && !MainController.isInteracting)
		{
			isCreate = !isCreate;
			CreateOptionChanged();
		}
	}

	public void OnInventoryStatusChanged(bool inventoryEnabled)
	{
		if (inventoryEnabled)
		{
			prevIsCreate = isCreate;
			isCreate = false;
			CreateOptionChanged();
		}
		else if (!inventoryEnabled && !prevIsCreate)
		{
			isCreate = false;
			CreateOptionChanged();
		}
		else if (!inventoryEnabled && prevIsCreate)
		{
			isCreate = true;
			CreateOptionChanged();
		}
	}

	public void SetSelectedType(TileData data)
	{
		selectedTile = data;
		createMode = CreateMode.Tile;
		CreateModeChanged();
	}

	public void SetSelectedType(ObjectData data)
	{
		selectedObject = data;
		createMode = CreateMode.Object;
		oCreator.SetCurObject(data);
		CreateModeChanged();
	}

	private void GetMousePosition()
	{
		Vector3Int tilePos = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		Vector3 mousePos = grid.GetCellCenterWorld(tilePos);
		tilePos.z = 0;
		mousePos.z = 0;
		oCreator.mousePosition = mousePos;
		tCreator.SetPositions(mousePos, tilePos);
	}

	public void Save()
	{
		TilemapData tiles = new TilemapData(tilesData);
		ObjectsData objects = new ObjectsData(objectsData);
		SaveSystem.SaveTilemap(tiles);
		SaveSystem.SaveObjects(objects);
	}

	public void Load()
	{
		StartCoroutine(LoadSystem.LoadTilemapData());
		StartCoroutine(LoadSystem.LoadObjects());
	}
}
