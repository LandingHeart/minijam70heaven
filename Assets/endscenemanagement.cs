using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class endscenemanagement : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public void retry()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        scoreText.text = "Your Score is: " + score.ToString();
    }
}
