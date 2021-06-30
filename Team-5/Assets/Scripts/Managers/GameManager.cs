using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private CreatorsManager cManager;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else Destroy(gameObject);

		INPUT.Init();
	}

	private void Start()
	{
		cManager = CreatorsManager.instance;
	}

	private void Update()
	{
		if (INPUT.MainController.Quit.triggered)
			Application.Quit();
		if (INPUT.MainController.Load.triggered)
			cManager.Load();
		if (INPUT.MainController.Save.triggered)
			cManager.Save();
	}
}
