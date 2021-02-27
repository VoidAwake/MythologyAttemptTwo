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

    [SerializeField] private Transform leftFoot;

    [SerializeField] private Transform rightFoot;
    private new Rigidbody2D rigidbody;
    public LayerMask feet;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        Move();

        if (Input.GetButtonDown("Jump")) {
            RaycastHit2D left = Physics2D.Raycast(leftFoot.position, (Vector2)leftFoot.position, 0.1f, feet);
            RaycastHit2D right = Physics2D.Raycast(rightFoot.position, (Vector2)rightFoot.position, 0.1f, feet);
            if (left.collider || right.collider) Jump();
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
