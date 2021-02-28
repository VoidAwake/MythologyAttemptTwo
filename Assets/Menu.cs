using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text score;
    public Text highscore;
    public Button retry;
    public bool newScore;
    // Start is called before the first frame update
    void Start()
    {
        int _score = PlayerPrefs.GetInt("score");
        int _highscore = PlayerPrefs.GetInt("highscore");
        if (_score > _highscore) _highscore = _score;
        PlayerPrefs.SetInt("highscore", _score);
        highscore.text = "Highscore = " + PlayerPrefs.GetInt("highscore");
        score.text = "Score = " + PlayerPrefs.GetInt("score") + "";
    }

    // Update is called once per frame
    public void Retry()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }
}
