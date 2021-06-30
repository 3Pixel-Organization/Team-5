using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private float panSpeed = 20;

	private void Update()
    {
		Vector3 pos = transform.position;

		Vector2 direction = INPUT.GetAxis;
		
		pos += (Vector3)direction * panSpeed * Time.deltaTime;
		
		transform.position = pos;
	}
}
