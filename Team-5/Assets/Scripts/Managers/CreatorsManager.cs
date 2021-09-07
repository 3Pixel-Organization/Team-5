using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public enum CreateMode
{
	Object,
	Tile,
	Building
}

public class CreatorsManager : MonoBehaviour
{
	public static CreatorsManager instance;
	public static bool isCreate = false;
	public static CreateMode createMode = CreateMode.Tile;

	public ObjectCreator oCreator;
	public TileCreator tCreator;
	[SerializeField] private TextMeshProUGUI placementNum;

	public delegate void OnCreateOptionChanged();
	public static event OnCreateOptionChanged CreateOptionChanged;

	[HideInInspector] public TileData selectedTile;
	[HideInInspector] public ObjectData selectedObject;
	[HideInInspector] public BuildingData selectedBuilding;
	[HideInInspector] public GameObject selectedGameObject;

	private bool prevIsCreate;
	private bool isKb;
	private Vector3Int tilePos;
	private Vector3 mousePos;
	private Vector3 prevMousePos;

	private Grid grid;
	private Camera cam;
	private Keyboard kb;

	private UIManager uiManager;
	private BuildingCreator bCreator;

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
		TilesPlacement.type = TilesPlacementType.oneTile;
		kb = InputSystem.GetDevice<Keyboard>();
		cam = Camera.main;
		bCreator = BuildingCreator.instance;
	}

	private void Update()
	{
		GetMousePosition();

		SetTilePlacementSize();

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
		CreateOptionChanged();
	}

	public void SetSelectedType(ObjectData data)
	{
		selectedObject = data;
		createMode = CreateMode.Object;
		oCreator.SetCurObject(data);
		CreateOptionChanged();
	}

	public void SetSelectedType(BuildingData data)
	{
		selectedBuilding = data;
		createMode = CreateMode.Building;
		bCreator.SetCurBuilding(data);
		CreateOptionChanged();
	}

	private void GetMousePosition()
	{
		if (!isKb)
		{
			tilePos = grid.WorldToCell(cam.ScreenToWorldPoint(INPUT.mousePosition));

			if (kb.upArrowKey.wasPressedThisFrame)
			{
				tilePos.y++;
				isKb = true;
				prevMousePos = INPUT.mousePosition;
				Cursor.visible = false;
			}
			if (kb.downArrowKey.wasPressedThisFrame)
			{
				tilePos.y--;
				isKb = true;
				prevMousePos = INPUT.mousePosition;
				Cursor.visible = false;
			}
			if (kb.leftArrowKey.wasPressedThisFrame)
			{
				tilePos.x--;
				isKb = true;
				prevMousePos = INPUT.mousePosition;
				Cursor.visible = false;
			}
			if (kb.rightArrowKey.wasPressedThisFrame)
			{
				tilePos.x++;
				isKb = true;
				prevMousePos = INPUT.mousePosition;
				Cursor.visible = false;
			}
		}
		else
		{
			if (kb.upArrowKey.wasPressedThisFrame)
				tilePos.y++;
			if (kb.downArrowKey.wasPressedThisFrame)
				tilePos.y--;
			if (kb.leftArrowKey.wasPressedThisFrame)
				tilePos.x--;
			if (kb.rightArrowKey.wasPressedThisFrame)
				tilePos.x++;

			if (prevMousePos != (Vector3)INPUT.mousePosition)
			{
				isKb = false;
				Cursor.visible = true;
			}
		}
		
		mousePos = grid.GetCellCenterWorld(tilePos);
		mousePos.z = 0;
		tilePos.z = 0;

		oCreator.mousePosition = mousePos;
		tCreator.SetPositions(mousePos, tilePos);
		bCreator.mousePosition = mousePos;
	}

	private void SetTilePlacementSize()
	{
		if (kb.digit1Key.wasPressedThisFrame)
		{
			placementNum.text = "1";
			TilesPlacement.type = TilesPlacementType.oneTile;
		}

		if (kb.digit2Key.wasPressedThisFrame)
		{
			placementNum.text = "2";
			TilesPlacement.type = TilesPlacementType.fourTiles;
		}

		if (kb.digit3Key.wasPressedThisFrame)
		{
			placementNum.text = "3";
			TilesPlacement.type = TilesPlacementType.nineTiles;
		}

		if (kb.digit4Key.wasPressedThisFrame)
		{
			placementNum.text = "4";
			TilesPlacement.type = TilesPlacementType.line2TilesRight;
		}

		if (kb.digit5Key.wasPressedThisFrame)
		{
			placementNum.text = "5";
			TilesPlacement.type = TilesPlacementType.line2TilesUp;
		}

		if (kb.digit6Key.wasPressedThisFrame)
		{
			placementNum.text = "6";
			TilesPlacement.type = TilesPlacementType.line4TilesRight;
		}

		if (kb.digit7Key.wasPressedThisFrame)
		{
			placementNum.text = "7";
			TilesPlacement.type = TilesPlacementType.line4TilesUp;
		}

		if (kb.digit8Key.wasPressedThisFrame)
		{
			placementNum.text = "8";
			TilesPlacement.type = TilesPlacementType.a3x3sq;
		}

		if (kb.digit9Key.wasPressedThisFrame)
		{
			placementNum.text = "9";
			TilesPlacement.type = TilesPlacementType.a4x4sq;
		}
	}
}
