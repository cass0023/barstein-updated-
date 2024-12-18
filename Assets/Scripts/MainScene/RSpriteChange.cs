using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSpriteChange : MonoBehaviour
{
    public RightPlayerMove RPlayer;
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
        if (RPlayer.currentRHeld == null)
        {
            playerHand = emptyHand;
        }
        else if (RPlayer.holdingR == "Coke")
        {
            playerHand = playerHeld[0];
        }
        else if (RPlayer.holdingR == "Cranberry")
        {
            playerHand = playerHeld[1];
        }
        else if (RPlayer.holdingR == "LimeJuice")
        {
            playerHand = playerHeld[2];
        }
        else if (RPlayer.holdingR == "SodaWater")
        {
            playerHand = playerHeld[3];
        }
        else if (RPlayer.holdingR == "Tomato")
        {
            playerHand = playerHeld[4];
        }
        else if (RPlayer.currentRHeld != null)
        {
            playerHand = playerHeld[5];
        }
    }
}
