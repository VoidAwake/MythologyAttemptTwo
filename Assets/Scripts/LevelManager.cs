using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text levelName;
    public Text timerText;
    private float timer;
    public static int level;
    public GridSetup grid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        UpdateUI();
    }
    void UpdateUI()
    {
        timerText.text = Mathf.RoundToInt(timer) + "";
    }
    void ResetLevel()
    {
        levelName.text = grid.Reset();
    }
}
