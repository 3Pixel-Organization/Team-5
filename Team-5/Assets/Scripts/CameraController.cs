using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private float panBoarder = 10;
	[SerializeField] private float panSpeed = 20;

	private void Update()
    {
		Vector3 pos = transform.position;

		float hori = Input.GetAxisRaw("Horizontal");
		float vert = Input.GetAxisRaw("Vertical");

		if (Input.mousePosition.y >= Screen.height - panBoarder && Input.GetKey(KeyCode.LeftShift))
		{
			pos.y += panSpeed * Time.deltaTime;
		}
		if (Input.mousePosition.y <= panBoarder && Input.GetKey(KeyCode.LeftShift))
		{
			pos.y -= panSpeed * Time.deltaTime;
		}
		if (Input.mousePosition.x >= Screen.width - panBoarder && Input.GetKey(KeyCode.LeftShift))
		{
			pos.x += panSpeed * Time.deltaTime;
		}
		if (Input.mousePosition.x <= panBoarder && Input.GetKey(KeyCode.LeftShift))
		{
			pos.x -= panSpeed * Time.deltaTime;
		}
		if (vert > 0.01f)
		{
			pos.y += vert * panSpeed * Time.deltaTime;
		}
		if (vert < -0.01)
		{
			pos.y += vert * panSpeed * Time.deltaTime;
		}
		if (hori > 0.01f)
		{
			pos.x += hori * panSpeed * Time.deltaTime;
		}
		if (hori < -0.01f)
		{
			pos.x += hori * panSpeed * Time.deltaTime;
		}

		transform.position = pos;
	}
}
