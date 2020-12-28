using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timelimit;
    private float startTime;
    public Text scoreText;
    private int score;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //score part
        score = gameManager.getscore();
        scoreText.text = "Score: " + score.ToString();
        //time part
        float t_passed = Time.time - startTime;
        float t_left = timelimit - t_passed;
        timerText.text = "Time: " + t_left.ToString("f2") + "s";
        if (t_left <= 0){
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("score", score);
        }
    }
}
