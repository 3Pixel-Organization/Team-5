using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;

public enum CreateMode
{
	Object,
	Tile
}

public enum TilesPlacementType
{
	oneTile,
	fourTiles,
	nineTiles
}

public class CreatorsManager : MonoBehaviour
{
	public static CreatorsManager instance;
	public static bool isCreate = false;
	public static CreateMode createMode = CreateMode.Tile;
	public static TilesPlacementType placementType;

	public ObjectCreator oCreator;
	public TileCreator tCreator;
	[SerializeField] private TextMeshProUGUI placementNum;

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

	private Grid grid;
	private Camera cam;
	private Keyboard kb;

	private UIManager uiManager;

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
		placementType = TilesPlacementType.nineTiles;
		kb = InputSystem.GetDevice<Keyboard>();
		cam = Camera.main;
	}

	private void Update()
	{
		GetMousePosition();

		if (kb.digit1Key.wasPressedThisFrame)
		{
			placementNum.text = "1";
			placementType = TilesPlacementType.oneTile;
			tCreator.ChangeOnTilePlacementSize();
		}

		if (kb.digit2Key.wasPressedThisFrame)
		{
			placementNum.text = "4";
			placementType = TilesPlacementType.fourTiles;
			tCreator.ChangeOnTilePlacementSize();
		}

		if (kb.digit3Key.wasPressedThisFrame)
		{
			placementNum.text = "9";
			placementType = TilesPlacementType.nineTiles;
			tCreator.ChangeOnTilePlacementSize();
		}

		if (INPUT.MainController.Create.triggered && !uiManager.inventory.activeSelf && !MainController.isInteracting)
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
		Vector3Int tilePos = grid.WorldToCell(cam.ScreenToWorldPoint(INPUT.mousePosition));
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
