using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text levelName;
    [SerializeField] private Text timerText;
    [SerializeField] private Slider score;
    public static float timer;
    private float maxTimer = 20;
    private float minTimer = 12;
    public static int level;
    private GridSetup grid;
    public static float maxScore;
    public static float currentScore = 20;
    public static float roundCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridSetup>();
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
        if (maxTimer > minTimer) maxTimer--;
        timer = maxTimer;
        currentScore = 20;
        roundCount += 1;
    }
}
