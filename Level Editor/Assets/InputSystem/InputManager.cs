using UnityEngine;
using UnityEngine.InputSystem;
using static Input.InputSystem;

public static class InputManager
{
    private static Input.InputSystem input;
    private static PlayerActions player;
    public static Keyboard kb;

    private static float horizontal;

    private static bool jumpHold;
    private static bool LMBhold;
    private static float curValue;

    public static Vector2 mousePosition
    {
        get { return player.mousePosition.ReadValue<Vector2>(); }
    }

    public static void Init()
    {
        input = new Input.InputSystem();
        input.Enable();
        kb = InputSystem.GetDevice<Keyboard>();
        player = input.player;

        player.move.performed += _ctx => horizontal = _ctx.ReadValue<float>();
        player.move.canceled += _ctx => horizontal = _ctx.ReadValue<float>();

        player.jump.performed += _ctx => jumpHold = true;
        player.jump.canceled += _ctx => jumpHold = false;

        player.LMB.performed += _ctx => LMBhold = _ctx.ReadValue<float>() == 0 ? false : true;
        player.LMB.canceled += _ctx => LMBhold = _ctx.ReadValue<float>() == 0 ? false : true;
    }

    public static bool GetButton(string name)
    {
        switch (name)
        {
            case "Jump":
                return jumpHold;
            case "LMB":
                return LMBhold;
            default:
                Debug.LogError($"There is no button with the name '{name}'");
                return false;
        }
    }

    public static bool GetButtonDown(string name)
    {
        switch (name)
        {
            case "Jump":
                return player.jump.triggered;
            case "LMB":
                return player.LMB.triggered;
            default:
                Debug.LogError($"There is no button with the name '{name}'");
                return false;
        }
    }

    public static float GetAxis(string name)
    {
        switch (name)
        {
            case "Horizontal":
                curValue = Mathf.Lerp(curValue, horizontal, Time.deltaTime * 5);
                return curValue;
            default:
                Debug.LogError($"There is no axis with the name '{name}'");
                return 0;
        }
    }

    public static float GetAxis(string name, float smooth)
    {
        switch (name)
        {
            case "Horizontal":
                curValue = Mathf.Lerp(curValue, horizontal, Time.deltaTime * smooth);
                return curValue;
            default:
                Debug.LogError($"There is no axis with the name '{name}'");
                return 0;
        }
    }

    public static float GetAxisRaw(string name)
    {
        switch (name)
        {
            case "Horizontal":;
                return horizontal;
            default:
                Debug.LogError($"There is no axis with the name '{name}'");
                return 0;
        }
    }
}
