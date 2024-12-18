using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSpriteChange : MonoBehaviour
{
    public PlayerMove LPlayer;
    public Shaker Shaker;
    public SpriteRenderer spriteRenderer;
    public Sprite emptyHand;
    public Sprite playerHand;
    public List<Sprite> playerHeld;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    //spriteRenderer.sprite = newSprite;
    {
        CheckHolding();

        spriteRenderer.sprite = playerHand;
    }
    public void CheckHolding()
    {
        if (LPlayer.currentHeld == null)
        {
            playerHand = emptyHand;
        }
        else if (LPlayer.holding == "VodkaBottle")
        {
            playerHand = playerHeld[0];
        }
        else if (LPlayer.holding == "RumBottle")
        {
            playerHand = playerHeld[1];
        }
        else if (LPlayer.holding == "GinBottle")
        {
            playerHand = playerHeld[2];
        }
        else if (LPlayer.holding == "Hot_Sauce")
        {
            playerHand = playerHeld[3];
        }
        else if (LPlayer.currentHeld != null)
        {
            playerHand = playerHeld[4];
        }
    }
}
