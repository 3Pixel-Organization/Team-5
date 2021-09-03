using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInteracting = false;

    public virtual void Interact()
	{
        isInteracting = true;
        print("INTERACTING!");
	}

	public virtual void StopInteract()
	{
		isInteracting = false;
		print("STOP INTERACTING!");
	}
}
