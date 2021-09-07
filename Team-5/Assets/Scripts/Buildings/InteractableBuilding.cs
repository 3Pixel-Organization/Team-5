using UnityEngine;
using TMPro;

public class InteractableBuilding : Interactable
{
	private GameObject interactionMenu;
	private TextMeshProUGUI objectName;
	private TextMeshProUGUI objectDiscription;

	public BuildingData buildingData;

	private MainController mController;

	private void Start()
	{
		mController = MainController.instance;

		interactionMenu = mController.interactionMenu;
		objectName = mController.objectName;
		objectDiscription = mController.objectDiscription;
	}

	public override void Interact()
	{
		interactionMenu.SetActive(true);
		objectName.text = buildingData.name;
		objectDiscription.text = buildingData.description;
	}

	public override void StopInteract()
	{
		interactionMenu.SetActive(false);
	}
}
