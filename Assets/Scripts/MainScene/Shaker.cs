using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMove LPlayer;
    public RightPlayerMove RPlayer;
    public DrinkRecipe DrinkRecipe;
    //lists to compare ing with recipe ing
    public List<DrinkRecipe> drinkRecipes;
    public List<string> shakerContents;
    //number of ing added and drink level updates recipe list
    public int numberOfIng;
    public bool matchIng;

    public void Update()
    {
        // sets the current recipe from recipe list
        DrinkRecipe = drinkRecipes[GameData.drinkLevel];
        //adds points if the ing is correct
        if (matchIng == true)
        {
            matchIng = false;
            gameManager.CorrectIngredient();
        }
    }
    public void AddIngredient()
    {
        //adds ing into the shaker list
        numberOfIng++;
        shakerContents.Insert(numberOfIng - 1, LPlayer.holding);  
        CheckMatch();
    }
    public void AddIngredientRight()
    {
        //adds ing into the shaker list
        numberOfIng++;
        shakerContents.Insert(numberOfIng - 1, RPlayer.holdingR);
        CheckMatch();
    }
    public void CheckMatch()
    {
        //checks if what the player is holding matches the recipe list to add points
        for (int i = 0; i < DrinkRecipe.recipeItem.Count; i++)
        {
            if (LPlayer.holding == DrinkRecipe.recipeItem[i])
            {
                matchIng = true;
                LPlayer.holding = null;
            }
            if(RPlayer.holdingR == DrinkRecipe.recipeItem[i])
            {
                matchIng = true;
                RPlayer.holdingR = null;
            }
        }
        CheckDrinkComplete();
    }
    public void CheckDrinkComplete()
    {
        //shaker contents = recipe contents ready to shake
        if (shakerContents.Count >= DrinkRecipe.recipeItem.Count)
        {
            //change sprite to show shaker full
            Debug.Log("Shaker full");
            ClearShaker();
            gameManager.ReadyToShake();
        }
    }
    public void ClearShaker()
    {
        shakerContents = null;
    }
}
[Serializable]
public class DrinkRecipe
{
    //creates list inside list to display name of recipe and ingredients
    public string name;
    public List<string> recipeItem;
}