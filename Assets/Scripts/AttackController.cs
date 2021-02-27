using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject normalAttack;
    [SerializeField] GameObject verticalAttack;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            AttackSpawn();
        }
    }


    private void AttackSpawn(){
      switch (Input.GetAxisRaw("Vertical"))
      {
          case 1:
              attackUp();
              break;
          case -1:
              attackDown();
              break;
          default:
              attackNormal();
              break;
      }
        
    }

    private void attackNormal(){
        Vector3 offset = new Vector3(-0.9f,-4.5f, 0f);
        Instantiate(normalAttack, transform.position + offset, Quaternion.identity);
    }

    private void attackUp(){
        Vector3 offset = new Vector3(0f,-3.7f, 0f);
        Instantiate(verticalAttack, transform.position + offset, Quaternion.identity);
    }

    private void attackDown(){
        Vector3 offset = new Vector3(0f,-4.8f, 0f);
        Instantiate(verticalAttack, transform.position + offset, Quaternion.identity);
    }

}
