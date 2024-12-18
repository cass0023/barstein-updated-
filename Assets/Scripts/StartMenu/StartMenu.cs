using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public PlayerMove lPlayer;
    public bool overStart;
    public RightPlayerMove rPlayer;
    public bool overRules;
    public GameObject popup;
    public bool popupOpen;
    public void Update()
    {
        if (Input.GetKeyDown(lPlayer.interact) && overStart == true) 
        {
            SceneManager.LoadScene("MainScene");
        }
        if (Input.GetKeyDown(rPlayer.interact) && overRules == true)
        {
            popup.SetActive(true);
            popupOpen = true;
        }
        if (popupOpen == true && Input.GetKeyDown(lPlayer.interact))
        {
            popupOpen = false;
            popup.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Start"))
        {
            overStart = true;
        }
        if (collision.gameObject.CompareTag("Rules"))
        {
            overRules = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        overRules = false;
        overStart = false;
    }
}