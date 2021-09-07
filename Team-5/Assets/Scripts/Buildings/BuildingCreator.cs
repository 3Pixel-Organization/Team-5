using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{
	public static BuildingCreator instance;

	public Transform objectsParent;
	public List<BuildingData> buildings = new List<BuildingData>();
	public Color buildingPreviewCanPlaceColor;
	public Color buildingPreviewCantPlaceColor;

	[HideInInspector] public Vector3 mousePosition;
	[HideInInspector] public GameObject buildingPreview;

	private ContactFilter2D contactFilter;

	private SpriteRenderer buildingPreviewRnderer;
	private Collider2D buildingPreviewCollider;
	private List<Collider2D> colliders = new List<Collider2D>();

	private CreatorsManager cManager;
	private WorldManager wManager;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		for (int i = 0; i < buildings.Count; i++)
			buildings[i].index = i;
	}

	private void Start()
	{
		cManager = CreatorsManager.instance;
		wManager = WorldManager.instance;
		CreatorsManager.CreateOptionChanged += OnCreateOptionChanged;
	}

	private void Update()
	{
		if (buildingPreview != null)
		{
			buildingPreview.transform.position = mousePosition;

			int collidersCount = buildingPreviewCollider.OverlapCollider(contactFilter, colliders);

			if (collidersCount == 0)
				buildingPreviewRnderer.color = buildingPreviewCanPlaceColor;
			else buildingPreviewRnderer.color = buildingPreviewCantPlaceColor;

			if (CreatorsManager.isCreate)
			{
				if (INPUT.MainController.Build.triggered && CreatorsManager.createMode == CreateMode.Building && collidersCount == 0)
					CreateBuilding(mousePosition, cManager.selectedBuilding);
			}
			else
			{
				buildingPreviewRnderer.enabled = false;
				buildingPreviewCollider.enabled = false;
			}
		}
	}

	public GameObject CreateBuilding(Vector3 position, BuildingData buildingData)
	{
		if (!Physics2D.OverlapPoint(position, buildingData.cantBePlacedOn))
		{
			GameObject building = Instantiate(buildingData.prefab, position, Quaternion.identity, objectsParent);
			building.AddComponent<BuildingInScene>().data = buildingData;
			wManager.buildings.Add(building);
			return building;
		}
		return null;
	}

	private void OnCreateOptionChanged()
	{
		if (buildingPreviewRnderer && buildingPreviewCollider)
		{
			if (CreatorsManager.createMode == CreateMode.Building && CreatorsManager.isCreate)
			{
				buildingPreviewRnderer.enabled = true;
				buildingPreviewCollider.enabled = true;
			}
			else
			{
				if (buildingPreviewRnderer != null && buildingPreviewCollider != null)
				{
					buildingPreviewRnderer.enabled = false;
					buildingPreviewCollider.enabled = false;
				}
			}
		}
	}

	public void SetCurBuilding(BuildingData _object)
	{
		contactFilter.ClearLayerMask();
		contactFilter.SetLayerMask(_object.cantBePlacedOn);
		if (buildingPreview != null)
			Destroy(buildingPreview.gameObject);

		buildingPreview = Instantiate(_object.prefab, mousePosition, Quaternion.identity, objectsParent);
		Destroy(buildingPreview.transform.Find("Logic").gameObject);
		buildingPreview.layer = 0;
		buildingPreviewRnderer = buildingPreview.GetComponentInChildren<SpriteRenderer>();
		buildingPreviewCollider = buildingPreview.GetComponent<Collider2D>();
		buildingPreviewRnderer.enabled = false;
		buildingPreviewCollider.enabled = false;
	}
}
