using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public bool canPress;
    public PlayerMove LPlayer;
    public RightPlayerMove RPlayer;
    public endManager endManager;

    void Start()
    {
        
    }

    void Update()
    {
        if (canPress == true && Input.GetKeyDown(LPlayer.interact))
        {
            endManager.LoadNewGame();
        }
        if(canPress == true && Input.GetKeyDown(RPlayer.interact))
        {
            endManager.LoadNewGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Start"))
        {
            canPress = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canPress = false;
    }
}
