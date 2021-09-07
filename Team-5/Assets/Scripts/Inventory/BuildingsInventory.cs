using System.Collections.Generic;
using UnityEngine;

public class BuildingsInventory : MonoBehaviour
{
	public Transform curTileText;

	private List<Slot> slots = new List<Slot>();
	private int curSlot = 0;
	private BuildingCreator bCreator;

	private void Start()
	{
		bCreator = BuildingCreator.instance;

		foreach (Transform _transform in transform)
		{
			Slot slot = _transform.GetComponent<Slot>();
			if (slot)
			{
				if (bCreator.buildings.Count > curSlot)
				{
					slots.Add(slot);
					slot.SetSlotData(bCreator.buildings[curSlot], curTileText);
					curSlot++;
				}
				else break;
			}
		}
	}
}
