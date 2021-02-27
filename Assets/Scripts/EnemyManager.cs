using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public GameObject fire;
    public phase curPhase;
    private float cooldown;
    private int attPattern;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangePhase", 1);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        switch (curPhase)
        {
            case phase.idle:
                if (AttackDelay(1))
                {
                    curPhase = (phase)Random.Range(1, 3);
                }
                break;
            case phase.fireball:
                if (AttackDelay(0.2f))
                {
                    Instantiate(fire);
                    if (attPattern == 5)
                    {
                        attPattern = 0;
                        curPhase = phase.idle;
                    }
                }
                break;
            case phase.attack:
                if (AttackDelay(2))
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Sign(transform.position.x - player.position.x));
                    if(attPattern == 2)
                    {
                        attPattern = 0;
                        curPhase = phase.idle;
                    }
                }
                break;
            case phase.help:
                break;
            default:
                break;
        }
    }

    private bool AttackDelay(float delay)
    {
        if(cooldown > delay)
        {
            attPattern++;
            cooldown = 0;
            return true;
        }
        return false;
    }

    void ChangePhase()
    {
        curPhase = (phase)Random.Range(1, 3);

    }
}
public enum phase
{
    idle,
    fireball,
    attack,
    help
}