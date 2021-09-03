using TMPro;
using UnityEngine;
using System.Collections.Generic;
using static Levels;

public class LevelEditor : MonoBehaviour
{
    public static LevelEditor instance;
    public static bool editMode = false;

    [Header("Interaction")]
    public GameObject interactionMenu;
    public TMP_InputField x;
    public TMP_InputField y;

    private Vector3Int cellPosition;
    private Vector3 mouseCellCenterWorld;

    private Camera cam;

    private TileCreator tileCreator;
	private GameManager gameManager;
	private UIManager uiManager;

    [HideInInspector] public EditableObject focus;
    [HideInInspector] public Grid grid;
    [HideInInspector] public ObjectCreator objectCreator;
    [HideInInspector] public ObjectData curObjectData;
	[HideInInspector] public Level curLevel;

	private void Awake()
	{
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);

		gameManager = GameManager.instance;
	}

	private void Start()
    {
        cam = Camera.main;
        tileCreator = GetComponent<TileCreator>();
        objectCreator = GetComponent<ObjectCreator>();
        grid = GetComponentInChildren<Grid>();
		curObjectData = objectCreator.objects[0];
		uiManager = UIManager.instance;
    }

    private void Update()
    {
        SetPositions();

        if (InputManager.kb.tKey.wasPressedThisFrame)
		{
            editMode = !editMode;
            if (focus != null && editMode)
				focus.Interact();
			else if (focus != null && !editMode)
			{
                focus.StopInteract();
                focus = null;
			}
		}

        if (InputManager.GetButtonDown("LMB") && !uiManager.isMenuActive)
			CreateObject(mouseCellCenterWorld, curObjectData);

		if (InputManager.kb.oKey.wasPressedThisFrame)
			SaveSystem.SaveLevel(LevelCreator.tilesSaveData, LevelCreator.objectsInScene, GameManager.Levels, gameManager.curLevel.name);
	}

    public void SetObjectPosition()
	{
		if (focus != null)
            focus.SetPosition();
	}

    public void SetTile(Vector3Int pos)
    {
        tileCreator.SetTile(pos);
    }

    public void CreateObject(Vector3 pos, ObjectData data)
	{
		if (Physics2D.OverlapPoint(pos) && editMode)
		{
			Collider2D _collider = Physics2D.OverlapPoint(pos);
			EditableObject _inter = _collider.GetComponent<EditableObject>();
			if (_inter)
			{
				if (_inter == focus)
				{
					focus.StopInteract();
					focus = null;
				}
				else
				{
					if (!_inter.isInteracting)
					{
						if (focus)
							focus.StopInteract();
						focus = _inter;
						focus.Interact();
					}
					else
					{
						focus.StopInteract();
						focus = null;
					}
				}
			}
		}
		else if (!Physics2D.OverlapPoint(pos) && !editMode)
			objectCreator.CreateObject(pos, data);
	}

    public void SetPositions()
	{
		cellPosition = grid.WorldToCell(cam.ScreenToWorldPoint(InputManager.mousePosition));
		cellPosition.z = 0;
        mouseCellCenterWorld = grid.GetCellCenterWorld(cellPosition);
		mouseCellCenterWorld.z = 0;

        tileCreator.cellPosition = cellPosition;
	}

	public void SaveLevel() => SaveSystem.SaveLevel(LevelCreator.tilesSaveData, LevelCreator.objectsInScene, GameManager.Levels, gameManager.curLevel.name);
}
