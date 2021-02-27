using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health health;
    public Image hearts;
    public Text enemyText;

    private int curHP;
    public int maxHP;
    private int bossHP;

    // Start is called before the first frame update
    void Start()
    {
        health = this;
        curHP = maxHP;
        UpdateUI();
    }

    // Update is called once per frame
    public void Update()
    {

    }
    public void UpdateUI()
    {
        hearts.rectTransform.sizeDelta = new Vector2(50 * curHP, 50);
        if (curHP == 0) Die();

    }
    public static void DamageEnemy(int att)
    {
        health.bossHP -= att;
        //enemyText.text = enemyHP;
    }

    public static void DamagePlayer(int att)
    {
        health.curHP -= att;
        health.curHP = Mathf.Clamp(health.curHP, 0, health.maxHP);
        health.UpdateUI();
        //enemyText.text = enemyHP;
    }
    private void Die()
    {
        Debug.LogError("You have died. Please exit the game.");
    }
}
