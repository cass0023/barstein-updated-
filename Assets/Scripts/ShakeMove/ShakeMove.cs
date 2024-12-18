using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakeMove : MonoBehaviour
{ 
    public GameManager GameManager;
    //NEEDS PLAY MENU
    public GameObject popup;
    //players movement
    public KeyCode leftPlayerL;
    public KeyCode leftPlayerR;
    public KeyCode rightPlayerL;
    public KeyCode rightPlayerR;
    //player interact
    public KeyCode interactL;
    public KeyCode interactR;
    public bool LPlayerReady;
    public bool RPlayerReady;
    public float moveSpeed = 10f;
    public int inversion = 1;
    public TextMeshProUGUI time;

    public float timeRemaining;
 
    void Update()
    {
        //resets timer on load
        if (popup.gameObject.activeInHierarchy == true)
        {
            timeRemaining = 10;
            if (Input.GetKey(interactL))
            {
                LPlayerReady = true;
            }
            if (Input.GetKey(interactR))
            {
                RPlayerReady = true;
            }
            if (LPlayerReady && RPlayerReady)
            {
                popup.SetActive(false);
            }
        }
        else
        {
            //timer
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            if (timeRemaining <= 0)
            {
                //Done shaking, return to main scene
                //**needs to save variables from main scene
                SceneManager.LoadScene("MainScene");
            }
        }
        time.text = timeRemaining.ToString("F0");

        //shaker movement controls
        if (Input.GetKey(leftPlayerR) && Input.GetKey(rightPlayerR))
        {
            transform.Translate(new Vector2(0, -1) * moveSpeed * Time.deltaTime * inversion * 2);
        }
        if (Input.GetKey(leftPlayerL) && Input.GetKey(rightPlayerL))
        {
            transform.Translate(new Vector2(0, 1) * moveSpeed * Time.deltaTime * inversion * 2);
        }
        if (Input.GetKey(rightPlayerR) && Input.GetKeyDown(leftPlayerL)) 
        {
            transform.Translate(new Vector2(0, -1) * moveSpeed * Time.deltaTime * inversion / 2);
        }
        if (Input.GetKey(rightPlayerL) && Input.GetKeyDown(leftPlayerR))
        {
            transform.Translate(new Vector2(0, 1) * moveSpeed * Time.deltaTime * inversion / 2);
        }
    }
}
