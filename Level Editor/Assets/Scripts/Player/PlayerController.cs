using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private float move;
    private bool jump;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        jump = InputManager.GetButton("Jump");

        move = InputManager.GetAxis("Horizontal", 20);
    }

    private void FixedUpdate()
    {
        motor.Move(move, jump);
    }
}
