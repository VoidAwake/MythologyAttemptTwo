using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject replaceWith;
    [SerializeField] private float Score;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D paint){
        if(paint.gameObject.tag == "painter"){
            Instantiate(replaceWith, transform.position, Quaternion.identity, transform.parent);
            Destroy(gameObject);
            LevelManager.currentScore += Score * LevelManager.roundDifficulty;
        }
    }
}