using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	public static bool isInventoryOpen = false;

    public GameObject inventory;

	private CreatorsManager cManager;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else Destroy(gameObject);
	}

	private void Start()
	{
		cManager = CreatorsManager.instance;
		inventory.SetActive(false);
		isInventoryOpen = inventory.activeSelf;
	}

	private void Update()
    {
		if (Input.GetKeyDown(KeyCode.E))
		{
            inventory.SetActive(!inventory.activeSelf);
			isInventoryOpen = inventory.activeSelf;
			cManager.OnInventoryStatusChanged(inventory.activeSelf);
		}
    }

	public void AnimateText(Animator animator)
	{
		StopAllCoroutines();
		StartCoroutine(_AnimateText(animator));
	}

	private IEnumerator _AnimateText(Animator animator)
	{
		animator.SetBool("Selected", true);
		yield return new WaitForSeconds(1f);
		animator.SetBool("Selected", false);
	}
}
