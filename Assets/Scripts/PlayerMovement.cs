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

    public float delay;

    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer rend;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        Move();
        delay = Mathf.Clamp(delay, 0, 1);
        if (Input.GetButtonDown("Jump"))
        {
            if (rigidbody.velocity.y <= 0.25f) Jump(1);
            //delay -= Time.deltaTime * 20;
        }
        else delay = 1;

        Gravity();
    }
    private void LateUpdate()
    {
        //RaycastHit2D left = Physics2D.Raycast(leftFoot.position, leftFoot.position, 0.05f, feet);
        //RaycastHit2D right = Physics2D.Raycast(rightFoot.position, rightFoot.position, 0.05f, feet);
        //anim.SetBool("Grounded", left.collider || right.collider);
        anim.SetBool("Grounded", transform.position.y < -6);
        anim.SetBool("Speed", Input.GetAxisRaw("Horizontal") != 0);
        if (movement != 0) rend.flipX = movement < 0;
    }

    private void Jump (float _delay) {
        rigidbody.AddForce(transform.up * jumpImpulse * _delay, ForceMode2D.Impulse);
        
    }

    private void Move () {
        rigidbody.velocity = new Vector2(
             movement * speed,
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




