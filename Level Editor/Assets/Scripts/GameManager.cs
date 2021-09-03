using UnityEngine;
using UnityEngine.SceneManagement;
using static Levels;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public static bool isEditing = false;

	private Levels levels;
	public static Levels Levels { get { return instance.levels; } }

	[HideInInspector] public Level curLevel;

	private LevelEditor levelEditor;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		
		DontDestroyOnLoad(this);

		if (!LoadSystem.FileExists("levels.lvls"))
			SaveSystem.Save("levels.lvls", new Levels());

		levels = LoadSystem.GetData<Levels>("levels.lvls");
		curLevel = null;
	}

	private void Start()
	{
		InputManager.Init();
	}

	public void EditLevel()
	{
		SceneManager.LoadScene(1);
		isEditing = true;
	}

	public void PlayLevel()
	{
		SceneManager.LoadScene(2);
		isEditing = false;
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene(0);
		isEditing = false;
	}

	public void CreateNewLevel(string _name)
	{
		string levelName = _name;
		if (levelName != string.Empty)
		{
			curLevel = new Level(_name, new Level.ObjectsData(), new Level.TilemapData());
			SceneManager.LoadScene(1);
		}
	}

	public void RemoveLevel(Level _level)
	{
		Levels.levels.Remove(_level.name);
		SaveSystem.SaveLevelsList(Levels);
	}

	public void UpdateLevels()
	{
		levels = LoadSystem.GetData<Levels>("levels.lvls");
		if (curLevel != null)
			curLevel = Levels.levels[curLevel.name];
	}
}
