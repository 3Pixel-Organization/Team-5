using UnityEngine;

public class Interactable : MonoBehaviour
{
	public bool isInteracting;

	public virtual void Interact()
	{
		if (!isInteracting)
		{
			isInteracting = true;
			Debug.Log("Interacting", gameObject);
		}
	}

	public virtual void StopInteract()
	{
		if (isInteracting)
		{
			isInteracting = false;
			Debug.Log("Stoped Interaction", gameObject);
		}
	}
}
