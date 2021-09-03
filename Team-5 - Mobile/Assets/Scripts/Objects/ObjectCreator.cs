using UnityEngine;
using System.Collections.Generic;

public class ObjectCreator : MonoBehaviour
{
	public static ObjectCreator instance;

	public Transform objectsParent;
	public List<ObjectData> objects = new List<ObjectData>();
	public Color objectPreviewCanPlaceColor;
	public Color objectPreviewCantPlaceColor;

	[HideInInspector] public Vector3 mousePosition;
	[HideInInspector] public GameObject objectPreview;

	private ObjectData curObjectData;

	private ContactFilter2D contactFilter;

	private SpriteRenderer objectPreviewRnderer;
	private Collider2D objectPreviewCollider;
	private List<Collider2D> colliders = new List<Collider2D>();

	private CreatorsManager cManager;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else Destroy(gameObject);
	}

	private void Start()
	{
		CreatorsManager.CreateOptionChanged += OnCreateOptionChanged;
		cManager = CreatorsManager.instance;

		for (int i = 0; i < objects.Count; i++)
			objects[i].index = i;

		SetCurObject(objects[0]);
	}

	private void Update()
	{
		if (objectPreview != null)
		{
			objectPreview.transform.position = mousePosition;
			
			int collidersCount = objectPreviewCollider.OverlapCollider(contactFilter, colliders);

			if (collidersCount == 0)
				objectPreviewRnderer.color = objectPreviewCanPlaceColor;
			else objectPreviewRnderer.color = objectPreviewCantPlaceColor;

			if (CreatorsManager.isCreate)
			{
				if (INPUT.MainController.Build.triggered && CreatorsManager.createMode == CreateMode.Object && collidersCount == 0)
					CreateObject(mousePosition, curObjectData);
			}
			else
			{
				objectPreviewRnderer.enabled = false;
				objectPreviewCollider.enabled = false;
			}
		}
	}

	public void CreateObject(Vector3 _pos, ObjectData _object)
	{
		Instantiate(_object.prefab, _pos, Quaternion.identity, objectsParent);
		ObjectSaveData data = new ObjectSaveData(_pos, _object.index);
		cManager.objectsData.Add(data);
	}

	private void OnCreateOptionChanged()
	{
		if (CreatorsManager.createMode == CreateMode.Object && CreatorsManager.isCreate)
		{
			objectPreviewRnderer.enabled = true;
			objectPreviewCollider.enabled = true;
		}
		else
		{
			objectPreviewRnderer.enabled = false;
			objectPreviewCollider.enabled = false;
		}
	}

	public void SetCurObject(ObjectData _object)
	{
		curObjectData = _object;
		contactFilter.ClearLayerMask();
		contactFilter.SetLayerMask(_object.cantBePlacedOn);
		if (objectPreview != null)
			Destroy(objectPreview.gameObject);

		objectPreview = Instantiate(_object.prefab, mousePosition, Quaternion.identity, objectsParent);
		objectPreviewRnderer = objectPreview.GetComponentInChildren<SpriteRenderer>();
		objectPreviewCollider = objectPreview.GetComponent<Collider2D>();
		objectPreviewRnderer.enabled = false;
		objectPreviewCollider.enabled = false;
	}
}
