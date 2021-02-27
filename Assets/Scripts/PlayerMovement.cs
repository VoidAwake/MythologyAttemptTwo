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

    [SerializeField] private float leftFoot;

    [SerializeField] private float rightFoot;
    private new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump")) {
            RaycastHit2D left = Physics2D.Raycast(leftFoot,leftFoot+vector2.down*0.1);
            RaycastHit2D right = Physics2D.Raycast(rightFoot,rightFoot+vector2.down*0.1);
            if(left.collider || right.collider) Jump();
        }

        Gravity();
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
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy"){
            Health.DamagePlayer(1);
        }
    }
}
