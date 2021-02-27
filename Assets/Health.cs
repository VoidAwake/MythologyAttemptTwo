using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image hearts;
    public Text enemyText;

    private int curHP;
    public int maxHP;
    private int bossHP;

    // Start is called before the first frame update
    void Start()
    {
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
    public void DamageEnemy(int att)
    {
        bossHP -= att;
        //enemyText.text = enemyHP;
    }

    public void DamagePlayer(int att)
    {
        curHP -= att;
        curHP = Mathf.Clamp(curHP, 0, maxHP);
        UpdateUI();
        //enemyText.text = enemyHP;
    }
    private void Die()
    {
        Debug.LogError("You have died. Please exit the game.");
    }
}
