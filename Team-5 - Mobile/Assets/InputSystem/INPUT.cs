using UnityEngine;

public static class INPUT
{
    public static InputManager input = new InputManager();
	public static InputManager.MainControllerActions MainController;

	private static float smooth = 15f;

	public static void Init()
	{
		input = new InputManager();
		input.Enable();
		MainController = input.MainController;

		input.MainController.MousePosition.performed += _ctx => _mousePosition = _ctx.ReadValue<Vector2>();
		input.MainController.MousePosition.canceled += _ctx => _mousePosition = _ctx.ReadValue<Vector2>();

		input.MainController.Movement.performed += _ctx => getAxisRaw = _ctx.ReadValue<Vector2>();
		input.MainController.Movement.canceled += _ctx => getAxisRaw = _ctx.ReadValue<Vector2>();
	}

	private static Vector2 _mousePosition;
	public static Vector2 mousePosition
	{
		get { return _mousePosition; }
	}

	private static Vector2 getAxis;
	private static Vector2 getAxisRaw;
	public static Vector2 GetAxis
	{
		get
		{
			getAxis = Vector2.Lerp(getAxis, GetAxisRaw, Time.deltaTime * smooth);
			return getAxis;
		}
	}
	public static Vector2 GetAxisRaw
	{
		get
		{
			return getAxisRaw;
		}
	}
}
