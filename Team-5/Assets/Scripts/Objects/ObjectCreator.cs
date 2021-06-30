using UnityEngine;
using System.Collections.Generic;

public class ObjectCreator : MonoBehaviour
{
	public static ObjectCreator instance;

	public Transform objectsParent;
	public List<ObjectData> objects = new List<ObjectData>();
	public Color objectFeedbackCanPlaceColor;
	public Color objectFeedbackCantPlaceColor;

	[HideInInspector] public Vector3 mousePosition;
	[HideInInspector] public GameObject objectFeedback;

	private ObjectData curObjectData;

	private ContactFilter2D contactFilter;

	private SpriteRenderer objectFeedbackRnderer;
	private Collider2D objectFeedbackcollider;
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
		CreatorsManager.CreateModeChanged += OnCreateModeChanged;
		cManager = CreatorsManager.instance;

		for (int i = 0; i < objects.Count; i++)
			objects[i].index = i;

		SetCurObject(objects[0]);
	}

	private void Update()
	{
		if (objectFeedback != null)
		{
			objectFeedback.transform.position = mousePosition;
			
			int collidersCount = objectFeedbackcollider.OverlapCollider(contactFilter, colliders);

			if (collidersCount == 0)
				objectFeedbackRnderer.color = objectFeedbackCanPlaceColor;
			else objectFeedbackRnderer.color = objectFeedbackCantPlaceColor;

			if (CreatorsManager.isCreate)
			{
				if (INPUT.MainController.LMB.triggered && CreatorsManager.createMode == CreateMode.Object && collidersCount == 0)
					CreateObject(mousePosition, curObjectData);
			}
			else
			{
				objectFeedbackRnderer.enabled = false;
				objectFeedbackcollider.enabled = false;
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
			objectFeedbackRnderer.enabled = true;
			objectFeedbackcollider.enabled = true;
		}
		else
		{
			objectFeedbackRnderer.enabled = false;
			objectFeedbackcollider.enabled = false;
		}
	}

	private void OnCreateModeChanged()
	{
		if (CreatorsManager.createMode == CreateMode.Object && CreatorsManager.isCreate)
		{
			objectFeedbackRnderer.enabled = true;
			objectFeedbackcollider.enabled = true;
		}
		else 
		{
			objectFeedbackRnderer.enabled = false;
			objectFeedbackcollider.enabled = false;
		}
	}

	public void SetCurObject(ObjectData _object)
	{
		curObjectData = _object;
		contactFilter.ClearLayerMask();
		contactFilter.SetLayerMask(_object.cantBePlacedOn);
		if (objectFeedback != null)
			Destroy(objectFeedback.gameObject);

		objectFeedback = Instantiate(_object.prefab, mousePosition, Quaternion.identity, objectsParent);
		objectFeedbackRnderer = objectFeedback.GetComponent<SpriteRenderer>();
		objectFeedbackcollider = objectFeedback.GetComponent<Collider2D>();
		objectFeedback.GetComponent<SpriteRenderer>().enabled = false;
		objectFeedbackcollider.enabled = false;
	}
}
