using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
	public static ObjectCreator instance;

	public List<ObjectData> objects = new List<ObjectData>();

	private LevelEditor levelEditor;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		levelEditor = GetComponent<LevelEditor>();
	}

	private void Start()
	{
		for (int i = 0; i < objects.Count; i++)
			objects[i].index = i;
	}

	public void CreateObject(Vector3 pos, ObjectData objectData)
	{
		if (!Physics2D.OverlapPoint(pos))
		{
			Transform newObj = Instantiate(objectData.prefab, pos, Quaternion.identity);
			if (GameManager.isEditing)
				newObj.gameObject.AddComponent<EditableObject>();

			newObj.GetComponent<ObjectInScene>().data = objectData;
			LevelCreator.objectsInScene.Add(newObj);
		}
	}
}
