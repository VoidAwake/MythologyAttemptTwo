using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text levelName;
    public Text timerText;
    public Slider score;
    private float timer;
    public static int level;
    public GridSetup grid;
    public static float maxScore;
    public static float currentScore = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) ResetLevel();
        UpdateUI();
    }
    void UpdateUI()
    {
        timerText.text = Mathf.RoundToInt(timer) + "";
        score.value = currentScore/maxScore;
        
    }
    void ResetLevel()
    {
        levelName.text = grid.Reset();
    }
}
