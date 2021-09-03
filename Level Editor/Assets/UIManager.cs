using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

	[SerializeField] private GameObject menu;

	[HideInInspector] public bool isMenuActive { get { return menu.activeSelf; } }

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(this);
	}

	private void Start() => menu.SetActive(false);

	private void Update()
    {
		if (InputManager.kb.escapeKey.wasPressedThisFrame)
			menu.SetActive(!menu.activeSelf);
    }

	public void BackToMenu() => GameManager.instance.BackToMenu();
}
