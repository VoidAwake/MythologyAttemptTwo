using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public static float roundCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridSetup>();
        timer = maxTimer;
        levelName.text = grid.Reset();
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
        if (currentScore < maxScore) SceneManager.LoadScene(1);
        if (PlayerPrefs.GetInt("score") == 0) PlayerPrefs.SetInt("score", 1);
        else PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);

        levelName.text = grid.Reset();
        if (maxTimer > minTimer) maxTimer--;
        timer = maxTimer;
        currentScore = 20;
        roundCount += 1;
    }
}
