using TMPro;
using UnityEngine;

public class MainController : MonoBehaviour
{
	public static MainController instance;
	public static bool isInteracting;

	public LayerMask interactablLayers;
	public GameObject interactionMenu;
	public TextMeshProUGUI objectName;
	public TextMeshProUGUI objectDiscription;

	[HideInInspector] public Interactable interaction;
	public int electrecityAmount;
	public int waterAmount;

	private ObjectCreator oCreator;

	private Camera cam;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	private void Start()
	{
		oCreator = ObjectCreator.instance;

		cam = Camera.main;
	}

	private void Update()
	{
		isInteracting = interactionMenu.activeSelf;

		if (INPUT.MainController.LMB.triggered && !CreatorsManager.isCreate && !UIManager.isInventoryOpen)
			Interact();

		if (INPUT.MainController.RMB.triggered && !CreatorsManager.isCreate)
			StopInteraction();
	}

	public void Collect()
	{
		interaction.GetComponent<ResourcesSystem>().CollectResources();
	}

	public void Upgrade()
	{
		interaction.GetComponent<ResourcesSystem>().UpgradeMachine();
	}

	private void Interact()
	{
		Collider2D[] colliders = Physics2D.OverlapPointAll(cam.ScreenToWorldPoint(INPUT.mousePosition), interactablLayers);

		if (colliders.Length != 0)
		{
			int _theFrontObject = 0;
			float _theLastYvalue = colliders[0].transform.position.y;

			for (int i = 1; i < colliders.Length; i++)
			{
				if (_theLastYvalue > colliders[i].transform.position.y)
				{
					_theLastYvalue = colliders[i].transform.position.y;
					_theFrontObject = i;
				}
			}

			if (interaction != colliders[_theFrontObject].GetComponent<Interactable>())
			{
				if (colliders[_theFrontObject].GetComponent<Interactable>() != oCreator.objectPreview.GetComponentInChildren<Interactable>())
				{
					StopInteraction();
					interaction = colliders[_theFrontObject].GetComponent<Interactable>();

					if (interaction)
						interaction.Interact();
				}
			}
			else StopInteraction();
		}
	}

	private void StopInteraction()
	{
		if (interaction != null)
		{
			interaction.StopInteract();
			interaction = null;
		}
	}
}
