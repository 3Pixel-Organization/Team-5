using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Slot : MonoBehaviour
{
	[SerializeField] private Image icon;

	private TileData tileData;
	private ObjectData objectData;
	private bool isTileData;
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
		isTileData = true;
	}

	public void SetSlotData(ObjectData data, Transform _curText)
	{
		curText = _curText;
		text = curText.GetComponent<TextMeshProUGUI>();
		animator = curText.GetComponent<Animator>();
		objectData = data;
		icon.enabled = true;
		icon.sprite = data.inventoryIcon;
		isTileData = false;
	}

	public void SetSelectedType()
	{
		if (isTileData)
		{
			cManager.SetSelectedType(tileData);
			text.text = tileData.name;
		}
		else
		{
			cManager.SetSelectedType(objectData);
			text.text = objectData.name;
		}

		UIManager.instance.AnimateText(animator);
	}
}
