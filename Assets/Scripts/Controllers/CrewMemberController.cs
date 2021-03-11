using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMemberController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    [SerializeField] bool hitWall = false;

    [SerializeField] public float runSpeed = 10.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Debug.Log("Set velocity: " + horizontal + ", " + vertical);
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger with " + collision.name);
    }

}
