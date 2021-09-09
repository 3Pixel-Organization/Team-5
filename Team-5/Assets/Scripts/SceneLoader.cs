using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader instance;
	public static bool isLoadoingScene = false;

	private EventSystem eventSystem;

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
		eventSystem = gManager.GetComponentInChildren<EventSystem>();
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
		() => {
			wManager.Save();
			wManager.buildingObjectsData = new List<ObjectSaveData>();
			wManager.buildingTilesData = new List<TileSaveData>();
			gManager.UpdateWorldData();
		},
		() => {
			wManager.buildings = new List<GameObject>();
			GameManager.inBuilding = false;
			wManager.LoadWorld(GameManager.worldData);
		});
	}

	public void LoadScene(int _index)
	{
		isLoadoingScene = true;
		eventSystem.enabled = false;
		INPUT.Disable();
		StartCoroutine(_LoadScene(_index));
	}
	public void LoadScene(int _index, Action beforeAction, Action afterAction)
	{
		isLoadoingScene = true;
		eventSystem.enabled = false;
		INPUT.Disable();
		StartCoroutine(_LoadScene(_index, beforeAction, afterAction));
	}
	public IEnumerator _LoadScene(int _index)
	{
		animator.SetBool("Move", true);

		yield return new WaitForSeconds(1.2f);

		SceneManager.LoadSceneAsync(_index);

		yield return new WaitForSeconds(.2f);

		animator.SetBool("Move", false);

		yield return new WaitForSeconds(2f);

		INPUT.Enable();
		eventSystem.enabled = true;
		isLoadoingScene = false;
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

		yield return new WaitForSeconds(2f);

		INPUT.Enable();
		eventSystem.enabled = true;
		isLoadoingScene = false;
	}
}
