using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Bullet;
    private float time;


    // Update is called once per frame

    private void Start()
    {
        time = LevelManager.timer;
        
    }
    void Update()
    {
        if(LevelManager.roundCount > 4){
            InvokeRepeating("Fire",2,1);
            LevelManager.roundCount = -1000000000;
        }
    }

    private void Fire(){
        GameObject pew = Instantiate(Bullet, Player.transform.position + new Vector3(-30f,0f,0f), Quaternion.identity);
        pew.GetComponent<Rigidbody2D>().AddForce(new Vector2(20f,0f), ForceMode2D.Impulse);
    }
}
