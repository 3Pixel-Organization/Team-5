using TMPro;
using UnityEngine;

public enum ResourceType
{
	Electrecity,
	Water
}

public class ResourcesSystem : Interactable
{
	private GameObject interactionMenu;
	private TextMeshProUGUI objectName;
	private TextMeshProUGUI objectDiscription;

	public ResourceType resourceType;
	public ObjectData objectData;

	private int level = 1;
	private int curResources;
	private float nextIncreaseTime;

	private MainController mController;

	private void Start()
	{
		mController = MainController.instance;

		interactionMenu = mController.interactionMenu;
		objectName = mController.objectName;
		objectDiscription = mController.objectDiscription;
	}

	private void Update()
	{
		if (nextIncreaseTime < Time.time)
		{
			curResources += 1;
			nextIncreaseTime = Time.time + 1f / level;
		}
	}

	public override void Interact()
	{
		interactionMenu.SetActive(true);
		objectName.text = objectData.name;
		objectDiscription.text = objectData.objectDescription;
	}

	public override void StopInteract()
	{
		interactionMenu.SetActive(false);
	}

	public void CollectResources()
	{
		switch (resourceType)
		{
			case ResourceType.Electrecity:
				mController.electrecityAmount += curResources;
				curResources = 0;
				break;
			case ResourceType.Water:
				mController.waterAmount += curResources;
				curResources = 0;
				break;
			default:
				break;
		}
	}

	public void UpgradeMachine()
	{
		level += 1;
	}

	public void OnClick()
	{
		Debug.Log("ACTION!");
	}
}
