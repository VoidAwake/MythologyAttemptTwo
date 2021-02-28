using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Bullet;

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.roundCount > 4){
            Fire();
        }
    }

    private void Fire(){

    }
}
