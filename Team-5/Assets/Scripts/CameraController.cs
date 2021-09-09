using UnityEngine;
using UnityEngine.U2D;

public class CameraController : MonoBehaviour
{
	[Header("Pan")]
	[SerializeField] private float panSpeed = 20;
	[SerializeField] private Vector2 panLimit = new Vector2(40, 40);

	[Header("Zoom")]
	[SerializeField] private int zoomSpeed = 3;
	[SerializeField] private int zoomMaxSize = 50;
	[SerializeField] private int zoomMinSize = 150;

	private PixelPerfectCamera cam;

	private void Start() => cam = GetComponentInChildren<PixelPerfectCamera>();

	private void Update()
    {
		Vector3 pos = transform.position;

		Vector2 rawDirection = INPUT.GetAxis;

		float value = Input.GetAxis("Mouse ScrollWheel");

		int scroll;

		if (value > 0)
			scroll = Mathf.CeilToInt(value);
		else if (value < 0)
			scroll = Mathf.FloorToInt(value);
		else scroll = 0;

		if (cam.assetsPPU < zoomMaxSize && scroll > 0)
			cam.assetsPPU += scroll * zoomSpeed;
		else if (cam.assetsPPU < zoomMaxSize && scroll < 0)
		{
			if (cam.assetsPPU > zoomMinSize)
			cam.assetsPPU += scroll * zoomSpeed;
		}
		else if (cam.assetsPPU > zoomMaxSize && scroll < 0)
			cam.assetsPPU += scroll * zoomSpeed;
		else if (cam.assetsPPU < zoomMinSize && scroll > 0)
			cam.assetsPPU += scroll * zoomSpeed;
		else if (cam.assetsPPU > zoomMinSize && scroll < 0)
			cam.assetsPPU += scroll * zoomSpeed;


		pos += (Vector3)rawDirection * panSpeed * Time.deltaTime;

		pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
		pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
		
		transform.position = pos;
	}
}
