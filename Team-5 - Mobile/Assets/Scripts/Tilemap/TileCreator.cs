using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TileCreator : MonoBehaviour
{
	public static TileCreator instance;

	public Tilemap groundTilemap;
	public Tilemap onGroundTilemap;
	public Transform onTileFeedback;

	public List<TileData> tiles = new List<TileData>();
	public Color onTileFeedbackCanPlaceColor;
	public Color onTileFeedbackCantPlaceColor;
	public Sprite onTileFeedbackCanPlace1;
	public Sprite onTileFeedbackCanPlace4;
	public Sprite onTileFeedbackCanPlace9;

	private Vector3Int tilePos;
	private ContactFilter2D contactFilter;
	private Dictionary<int, TileBase> tileBases = new Dictionary<int, TileBase>();

	private SpriteRenderer onTileFeedbackRenderer;
	private List<Collider2D> colliders = new List<Collider2D>();
	private Collider2D onTileFeedbackcollider;

	private CreatorsManager cManager;

	private TilesPlacementType type { get { return TilesPlacement.type; } }

	//Input
	private float Build;
	private float Remove;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else Destroy(gameObject);

		INPUT.MainController.Build.performed += _ctx => Build = _ctx.ReadValue<float>();
		INPUT.MainController.Build.canceled += _ctx => Build = _ctx.ReadValue<float>();

		INPUT.MainController.Remove.performed += _ctx => Remove = _ctx.ReadValue<float>();
		INPUT.MainController.Remove.canceled += _ctx => Remove = _ctx.ReadValue<float>();
	}

	private void Start()
	{
		cManager = CreatorsManager.instance;
		CreatorsManager.CreateOptionChanged += OnCreateOptionChanged;

		onTileFeedbackRenderer = onTileFeedback.GetComponentInChildren<SpriteRenderer>();
		onTileFeedbackcollider = onTileFeedback.GetComponentInChildren<Collider2D>();

		cManager.selectedTile = tiles[1];
		onTileFeedback.gameObject.SetActive(false);

		for (int i = 0; i < tiles.Count; i++)
		{
			tiles[i].index = i;
			if (tiles[i].isRuledTile)
				tileBases.Add(i, Instantiate<TileBase>(tiles[i].ruleTile));
			else if (tiles[i].tile != null)
				tileBases.Add(i, Instantiate<TileBase>(tiles[i].tile));
		}
	}

	private void Update()
	{
		contactFilter.SetLayerMask(cManager.selectedTile.cantBePlacedOn);

		if (onTileFeedback)
		{
			/*int collidersCount = onTileFeedbackcollider.OverlapCollider(contactFilter, colliders);

			if (collidersCount > 0)
				onTileFeedbackRenderer.color = onTileFeedbackCantPlaceColor;*/
			//else
			//{
				onTileFeedbackRenderer.color = onTileFeedbackCanPlaceColor;

				if (CreatorsManager.isCreate)
				{
					if (CreatorsManager.createMode == CreateMode.Tile)
					{
						if (Build == 1)
							SetTile(tilePos, cManager.selectedTile);
						if (Remove == 1)
							SetTile(tilePos, null);
					}
				}
			//}
		}
	}

	public void SetTile(Vector3Int changePos, TileData tile)
	{
		if (tile == null)
		{
			onGroundTilemap.SetTile(changePos, null);
			TileSaveData data = new TileSaveData(changePos, 0);
			cManager.tilesData.Add(data);
		}
		else
		{
			Tilemap _curMap = tile.type == TileType.Ground ? groundTilemap : onGroundTilemap;

			for (int i = 0; i < TilesPlacement.GetPlacement(type).Length; i++)
			{
				Vector3Int placePos = changePos + (Vector3Int)TilesPlacement.GetPlacement(type)[i];
				_curMap.SetTile(placePos, tileBases[tile.index]);

				TileSaveData data = new TileSaveData(placePos, tile.index);
				cManager.tilesData.Add(data);
			}
		}
	}

	public void ChangeOnTilePlacementSize()
	{
		switch (TilesPlacement.type)
		{
			case TilesPlacementType.oneTile:
				onTileFeedbackRenderer.sprite = onTileFeedbackCanPlace1;
				break;
			case TilesPlacementType.fourTiles:
				onTileFeedbackRenderer.sprite = onTileFeedbackCanPlace4;
				break;
			case TilesPlacementType.nineTiles:
				onTileFeedbackRenderer.sprite = onTileFeedbackCanPlace9;
				break;
			default:
				onTileFeedbackRenderer.sprite = onTileFeedbackCanPlace1;
				break;
		}
	}

	public void SetPositions(Vector3 mousePos, Vector3Int _tilePos)
	{
		onTileFeedback.position = mousePos;
		tilePos = _tilePos;
	}

	private void OnCreateOptionChanged()
	{
		if (CreatorsManager.createMode == CreateMode.Tile && CreatorsManager.isCreate)
			onTileFeedback.gameObject.SetActive(true);
		else onTileFeedback.gameObject.SetActive(false);
	}
}
