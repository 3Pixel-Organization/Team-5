using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public enum SlotHolding
{
	Tile, Object, Building
}

public class Slot : MonoBehaviour
{
	[SerializeField] private Image icon;

	private TileData tileData;
	private ObjectData objectData;
	private BuildingData buildingData;
	private SlotHolding holding;
	private Transform curText;
	private TextMeshProUGUI text;
	private Animator animator;
	private CreatorsManager cManager;

	private void Start()
	{
		cManager = CreatorsManager.instance;
	}

	public void SetSlotData(TileData data, Transform _curText)
	{
		curText = _curText;
		text = curText.GetComponent<TextMeshProUGUI>();
		animator = curText.GetComponent<Animator>();
		tileData = data;
		icon.enabled = true;
		if (data.isRuledTile)
			icon.sprite = data.ruleTile.m_DefaultSprite;
		else icon.sprite = data.tile.sprite;
		holding = SlotHolding.Tile;
	}

	public void SetSlotData(ObjectData data, Transform _curText)
	{
		curText = _curText;
		text = curText.GetComponent<TextMeshProUGUI>();
		animator = curText.GetComponent<Animator>();
		objectData = data;
		icon.enabled = true;
		icon.sprite = data.inventoryIcon;
		holding = SlotHolding.Object;
	}

	public void SetSlotData(BuildingData data, Transform _curText)
	{
		curText = _curText;
		text = curText.GetComponent<TextMeshProUGUI>();
		animator = curText.GetComponent<Animator>();
		buildingData = data;
		icon.enabled = true;
		icon.sprite = data.menuIcon;
		holding = SlotHolding.Building;
	}

	public void SetSelectedType()
	{
		if (holding == SlotHolding.Tile)
		{
			cManager.SetSelectedType(tileData);
			text.text = tileData.name;
		}
		else if (holding == SlotHolding.Object)
		{
			cManager.SetSelectedType(objectData);
			text.text = objectData.name;
		}
		else if (holding == SlotHolding.Building)
		{
			cManager.SetSelectedType(buildingData);
			text.text = buildingData.name;
		}

		UIManager.instance.AnimateText(animator);
	}
}
