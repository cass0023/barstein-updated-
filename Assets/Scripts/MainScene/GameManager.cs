using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Shaker Shaker;
    public PlayerMove LPlayer;
    public RightPlayerMove RPlayer;
    public DrinkFeedback DrinkFeedback;
    public DrinkRecipe DrinkRecipe;

    public TextMeshProUGUI livesCounter;
    public TextMeshProUGUI pointsCounter;
    public TextMeshProUGUI timeCounter;
    public float timeRemaining;

    public bool wrongIng;
    public bool rightIng;

    public int numberOfRecipeIng = 3;
    public void Start()
    {
        timeRemaining = GameData.startingTime;
    }
    public void LoseLife()
    {
        //**not implemented yet
        GameData.lives--;
        //DrinkFeedback.IncorrectFeedback();
        //wrongIng = true;
        if (GameData.lives == 0)
        {
            Debug.Log("No more lives");
            LoadEndScene();
        }
    }
    public void CorrectIngredient()
    {
        //DrinkFeedback.CorrectIng();
        //rightIng = true;
        GameData.score += 75;
    }
    public void CorrectDrink() 
    {
        GameData.score += 100;
    }
    public void ReadyToShake()
    {
        //when shaker is full load shaker scene
        //**display on screen that players need to press and hold the interact key to shake
        GameData.drinkLevel++;
        Debug.Log("READY TO SHAKE");
        LoadShakeScene();
    }
    public void LoadShakeScene()
    {
        SceneManager.LoadScene("Shake");
    }
    public void LoadEndScene()
    {
        SceneManager.LoadScene("Finish");
    }
    public void Update()
    {
        //drink time remaining
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0)
        {
            Debug.Log("Out of time, update recipe");
            GameData.drinkLevel++;
        }
        livesCounter.text = GameData.lives.ToString();
        pointsCounter.text = GameData.score.ToString();
        timeCounter.text = timeRemaining.ToString("F0");
        if (GameData.drinkLevel > DrinkRecipe.recipeItem.Count)
        {
            //doesnt load
            LoadEndScene();
        }
    }
    public void LateUpdate()
    {
        if (timeRemaining < 0)
        {
            timeRemaining = GameData.startingTime;
        }
    }

}
