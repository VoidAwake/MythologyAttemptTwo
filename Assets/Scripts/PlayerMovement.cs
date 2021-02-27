using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpImpulse;
    [SerializeField] private float gravity;
    private bool grounded = false;

    private float movement;

    private new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }

        if (!grounded){
            Gravity();
        }
    }

    private void Jump () {
        rigidbody.AddForce(transform.up * jumpImpulse, ForceMode2D.Impulse);
    }

    private void Move () {
        rigidbody.velocity = new Vector2(
            Input.GetAxisRaw("Horizontal") * speed,
            rigidbody.velocity.y
        );
    }

    private void Gravity() {
        rigidbody.AddForce(transform.up * -1 * gravity);
    }

    private void OnCollisionEnter2D(Collision2D floor) {
        if(floor.gameObject.tag == "floor"){
            grounded = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy"){
            Health.DamagePlayer(1);
        }
    }
}
