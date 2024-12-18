using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeChanger : MonoBehaviour
{
    public DrinkRecipe DrinkRecipe;
    public Shaker Shaker;

    public List<Sprite> recipeCard;

    public Sprite currentRecipe;
    public GameObject UI;
    public int difficulty = 0;


    public void Start()
    {
        
    }
    public void Update()
    {
        if(GameData.drinkLevel > difficulty)
        {
            difficulty++;
            Debug.Log("drink lvl increase");
            UI.GetComponent<UnityEngine.UI.Image>().overrideSprite = recipeCard[difficulty];
        }
    }

}
