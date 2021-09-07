using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader instance;

	private Animator animator;

	private GameManager gManager;
	private WorldManager wManager;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(this);

		animator = GetComponentInChildren<Animator>();
		gManager = GameManager.instance;
	}

	private void Start()
	{
		wManager = WorldManager.instance;
		wManager.LoadWorld(GameManager.worldData);
	}

	public void EnterBuilding(WorldData.BuildingData bData)
	{
		LoadScene(1, () =>
		{ 
			wManager.Save();
			gManager.UpdateWorldData();
			wManager.buildings = new List<GameObject>(); 
		}, () =>
		{
			GameManager.inBuilding = true;
			wManager.LoadBuilding(bData);
		});
	}

	public void ExitBuilding()
	{
		LoadScene(0,
		() =>
		{
			wManager.Save();
			wManager.buildingObjectsData = new List<ObjectSaveData>();
			wManager.buildingTilesData = new List<TileSaveData>();
			gManager.UpdateWorldData();
		},
		() =>
		{
			wManager.buildings = new List<GameObject>();
			GameManager.inBuilding = false;
			wManager.LoadWorld(GameManager.worldData);
		});
	}

	public void LoadScene(int _index) => StartCoroutine(_LoadScene(_index));
	public void LoadScene(int _index, Action beforeAction, Action afterAction) => StartCoroutine(_LoadScene(_index, beforeAction, afterAction));

	public IEnumerator _LoadScene(int _index)
	{
		animator.SetBool("Move", true);

		yield return new WaitForSeconds(1.2f);

		SceneManager.LoadSceneAsync(_index);

		yield return new WaitForSeconds(.2f);

		animator.SetBool("Move", false);
	}

	public IEnumerator _LoadScene(int _index, Action beforeAcrion, Action afterAction)
	{
		animator.SetBool("Move", true);

		beforeAcrion();

		yield return new WaitForSeconds(1.2f);

		AsyncOperation operation = SceneManager.LoadSceneAsync(_index);

		while (!operation.isDone)
			yield return null;

		yield return new WaitForSeconds(.2f);

		afterAction();

		animator.SetBool("Move", false);
	}
}
