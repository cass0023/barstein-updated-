using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkFeedback : MonoBehaviour
{
    public Shaker Shaker;
    public GameManager GameManager;
    public GameObject correctIng;
    public float timeRemain;
    void Update()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
        }
        if (timeRemain < 0)
        {
            timeRemain = 0;
        }
        //if (GameManager.rightIng == true)
        //{
        //    timeRemain = GameData.animTimer;
        //    if(timeRemain > 0)
        //    {
        //        correctIng.SetActive(true);
        //    }
        //}
    }
    public void CorrectIng()
    {
        timeRemain = GameData.animTimer;
        if (timeRemain > 0)
        {
            correctIng.SetActive(true);
        }
        if (timeRemain <= 0)
        {
            correctIng.SetActive(false);
        }
    }
}
