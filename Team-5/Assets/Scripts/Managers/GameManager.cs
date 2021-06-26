using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private CreatorsManager cManager;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else Destroy(gameObject);
	}

	private void Start()
	{
		cManager = CreatorsManager.instance;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
		if (Input.GetKeyDown(KeyCode.L))
			cManager.Load();
		if (Input.GetKeyDown(KeyCode.O))
			cManager.Save();
	}
}
