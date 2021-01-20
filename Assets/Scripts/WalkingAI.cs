using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAI : MonoBehaviour
{
    private Transform GaurdPos;
    public Vector3 Direction;
    public float Speed;
    private bool IsGrounded;
    public LayerMask Ground;
    public float Radius;
    public float Boost;
    private SpriteRenderer Gaurd;
    private bool Flipped;

    private void Start()
    {
        GaurdPos = GetComponent<Transform>();
        Gaurd = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        DetectGround();
    }

    public void DetectGround()
    {
        IsGrounded = Physics2D.OverlapCircle(GaurdPos.position, Radius, Ground);
        if (IsGrounded)
        {
            GaurdPos.position += Direction * Speed * Time.deltaTime;
            Gaurd.flipX = true;
        }
        else if (!IsGrounded && !Flipped)
        {
            Flipped = true;
            Speed = Speed - 2 * Speed;
            GaurdPos.position += Direction * Speed * Boost * Time.deltaTime;
            Gaurd.flipX = Flipped;
        }
        else if (!IsGrounded && Flipped)
        {
            Flipped = false;
            Speed = Speed - 2 * Speed;
            GaurdPos.position += Direction * Speed * Boost * Time.deltaTime;
            Gaurd.flipX = Flipped;
        }


    }

}
