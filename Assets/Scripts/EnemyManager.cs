using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public GameObject fire;
    public phase curPhase;
    private int cooldown;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangePhase", 1);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown++;
        switch (curPhase)
        {
            case phase.idle:
                break;
            case phase.fireball:
                if (AttackDelay(40))
                {
                    Instantiate(fire);
                }
                break;
            case phase.attack:
                if (cooldown > 40)
                {

                }
                break;
            case phase.help:
                break;
            default:
                break;
        }
    }

    private bool AttackDelay(int delay)
    {
        if(cooldown > delay)
        {
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