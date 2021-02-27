using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private float movement;

    private new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Jump () {

    }

    private void Move () {
        

        rigidbody.velocity = new Vector2(
            Input.GetAxisRaw("Horizontal") * speed,
            rigidbody.velocity.y
        );
    }
}
