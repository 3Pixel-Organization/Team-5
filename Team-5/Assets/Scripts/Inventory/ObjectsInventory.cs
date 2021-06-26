using UnityEngine;
using System.Collections.Generic;

public class ObjectsInventory : MonoBehaviour
{
	public Transform curTileText;

	private List<Slot> slots = new List<Slot>();
	private int curSlot = 0;
	private ObjectCreator oCreator;

	private void Start()
	{
		oCreator = ObjectCreator.instance;

		foreach (Transform _transform in transform)
		{
			Slot slot = _transform.GetComponent<Slot>();
			if (slot)
			{
				if (oCreator.objects.Count > curSlot)
				{
					slots.Add(slot);
					slot.SetSlotData(oCreator.objects[curSlot], curTileText);
					curSlot++;
				}
				else break;
			}
		}
	}
}
