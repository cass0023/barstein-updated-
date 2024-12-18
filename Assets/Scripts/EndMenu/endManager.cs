using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endManager : MonoBehaviour
{
    public int endScore;
    public TextMeshProUGUI scoreDisplay1;
    public TextMeshProUGUI scoreDisplay2;

    void Update()
    {
        endScore = GameData.score;
        scoreDisplay1.text = endScore.ToString(); 
        scoreDisplay2.text = endScore.ToString();
    }

    public void LoadNewGame()
    {
        GameData.score = 0;
        GameData.drinkLevel = 0;
        GameData.lives = 3;
        SceneManager.LoadScene("MainMenu");
    }
}
