using UnityEngine;
using System.Collections.Generic;

public class TilesInventory : MonoBehaviour
{
	[HideInInspector] public List<Slot> slots;

	public Transform curTileText;

	private int curSlot = 1;
	private TileCreator creator;

    private void Start()
    {
		creator = TileCreator.instance;

		foreach (Transform _transform in transform)
		{
            Slot slot = _transform.GetComponent<Slot>();
			if (slot)
			{
				if (creator.tiles.Count > curSlot)
				{
					slots.Add(slot);
					slot.SetSlotData(creator.tiles[curSlot], curTileText);
					curSlot++;
				}
				else break;
			}
		}
    }
}
