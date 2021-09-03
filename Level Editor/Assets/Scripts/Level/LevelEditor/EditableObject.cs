using UnityEngine;
using TMPro;
using System;

public class EditableObject : Interactable
{
	private GameObject interactionMenu;
	private TMP_InputField x;
	private TMP_InputField y;

	private LevelEditor levelEditor;

	private void Start()
	{
		levelEditor = LevelEditor.instance;
		interactionMenu = levelEditor.interactionMenu;
		x = levelEditor.x;
		y = levelEditor.y;
	}

	public override void Interact()
	{
		interactionMenu.SetActive(true);
		x.text = transform.position.x.ToString();
		y.text = transform.position.y.ToString();
	}

	public override void StopInteract()
	{
		interactionMenu.SetActive(false);
	}

	public void SetPosition()
	{
		Vector3 newPos = new Vector3((float)Convert.ToDouble(x.text), (float)Convert.ToDouble(y.text), 0);
		transform.position = newPos;
	}
}
