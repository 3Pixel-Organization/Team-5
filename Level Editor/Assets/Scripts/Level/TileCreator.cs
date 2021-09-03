using JASUtils;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCreator : MonoBehaviour
{
	public static TileCreator instance;

	[SerializeField] private Tile tile;

	[HideInInspector] public Vector3Int cellPosition;

	private LevelEditor levelEditor;

	private Tilemap tilemap;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	private void Start()
	{
		levelEditor = GetComponent<LevelEditor>();
		tilemap = GetComponentInChildren<Tilemap>();
	}

	private void Update()
	{
		/*if (InputManager.GetButton("LMB"))
			SetTile(cellPosition);*/
	}

	public void SetTile(Vector3Int pos)
	{
		tilemap.SetTile(pos, tile);
		TileSaveData data = new TileSaveData(0, Utils.Vector3ToFloatArray(pos));
		LevelCreator.tilesSaveData.Add(data);
	}
}
