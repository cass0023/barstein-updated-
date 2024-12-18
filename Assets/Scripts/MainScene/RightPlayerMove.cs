using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayerMove : MonoBehaviour
{
    //RIGHT PLAYER CONTROLS 

    public Shaker Shaker;
    public GameManager gameManager;
    //player controls
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode interact;
    //movement
    public float moveSpeed = 10f;
    public int inversion = 1;
    //checks which object to grab
    public GameObject currentRHover;
    public GameObject currentRHeld;
    public string holdingR;
    //allows interacting with ingredients, shaker, and serving tray
    public bool canGrab;
    public bool interactShaker;

    public void Update()
    {
        //interact controls depending on obj collision
        if (Input.GetKeyDown(interact))
        {
            if (currentRHeld == null)
            {
                if (canGrab == true)
                {
                    currentRHeld = currentRHover.gameObject;
                    
                    OnGrab();
                }
            }
            else if (interactShaker == true && currentRHeld != null)
            {
                Shaker.AddIngredientRight();
                currentRHeld.SetActive(true);
                currentRHeld = null;
            }
            else
            {
                currentRHeld.SetActive(true);
                if (currentRHeld != null)
                {
                    currentRHeld = null;
                    holdingR = null;
                }
            }
        }
    }
    public void FixedUpdate()
    {
        //Move controls
        if (Input.GetKey(right))
        {
            transform.Translate(new Vector2(0, -1) * moveSpeed * Time.deltaTime * inversion);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(new Vector2(0, 1) * moveSpeed * Time.deltaTime * inversion);
        }
        if (Input.GetKey(up))
        {
            transform.Translate(new Vector2(1, 0) * moveSpeed * Time.deltaTime * inversion);
        }
        if (Input.GetKey(down))
        {
            transform.Translate(new Vector2(-1, 0) * moveSpeed * Time.deltaTime * inversion);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ingredients"))
        {
            currentRHover = collision.gameObject;
            canGrab = true;
        }
        if (collision.gameObject.CompareTag("Shaker"))
        {
            interactShaker = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        //resets variables when leaving interactable obj
        currentRHover = null;
        canGrab = false;
        interactShaker = false;
    }
    public void OnGrab()
    {
        //holding string is used to match recipes
        currentRHeld.SetActive(false);
        canGrab = false;
        holdingR = currentRHeld.name;
    }
}
