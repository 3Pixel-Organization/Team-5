using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private float panSpeed = 20;

	Vector2 rawDirection;
	Vector2 smoothDirection;

	private void Update()
    {
		Vector3 pos = transform.position;

		Vector2 rawDirection = INPUT.GetAxis;
		
		pos -= (Vector3)rawDirection * panSpeed * Time.deltaTime;
		
		transform.position = pos;
	}
}
