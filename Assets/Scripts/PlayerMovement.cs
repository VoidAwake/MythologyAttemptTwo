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
    }

    private void Update()
    {
        Move();
    }

    private void Jump () {

    }

    private void Move () {
        // Debug.Log(movement);

        // rigidbody.velocity = new Vector2(
        //     movement * speed,
        //     rigidbody.velocity.y
        // );
    }
}
