using UnityEngine;
using TMPro;
using static Levels;

public class LevelsMenu : MonoBehaviour
{
	public static LevelsMenu instance;

    [SerializeField] private Transform levelSelcetPrefab;
    [SerializeField] private Transform levelsParent;
	[SerializeField] private GameObject newLevelMenu;
	[SerializeField] private GameObject viewLevelMenu;
	[SerializeField] private GameObject levelsMenu;
	[SerializeField] private TextMeshProUGUI levelName;
	[SerializeField] private TMP_InputField newLevelName;

	private GameManager gameManager;

	private Level curLevel
	{ 
		get { return gameManager.curLevel; }
		set { gameManager.curLevel = value; }
	}

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy(gameObject);

		gameManager = GameManager.instance;
	}

	private void Start()
    {
		if (curLevel != null)
		{
			gameManager.UpdateLevels();
			ViewLevel(curLevel);
		}

		UpdateLevelsList();
    }

	public void ViewLevel(Level _level)
	{
		DisableAllMenus();
		viewLevelMenu.SetActive(true);
		levelName.text = _level.name;
		curLevel = _level;
	}

	public void BackToMenu()
	{
		DisableAllMenus();
		curLevel = null;
		levelsMenu.SetActive(true);
	}

	public void CreateNewLevel_Button() => newLevelMenu.SetActive(true);

	public void CreateNewLevel() => gameManager.CreateNewLevel(newLevelName.text);

	private void DisableAllMenus()
	{
		viewLevelMenu.SetActive(false);
		newLevelMenu.SetActive(false);
		levelsMenu.SetActive(false);
	}

	public void RemoveLevel()
	{
		gameManager.RemoveLevel(curLevel);
		BackToMenu();
		UpdateLevelsList();
	}

	public void UpdateLevelsList()
	{
		foreach (Transform _transform in levelsParent)
			Destroy(_transform.gameObject);

		foreach (Level lvl in GameManager.Levels.levels.Values)
		{
			Transform obj = Instantiate(levelSelcetPrefab, levelsParent);
			obj.GetComponent<LevelData>().SetData(lvl);
		}
	}

	public void EditLevel() => gameManager.EditLevel();
	public void PlayLevel() => gameManager.PlayLevel();
}
