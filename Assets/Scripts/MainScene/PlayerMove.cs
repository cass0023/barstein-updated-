using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //LEFT PLAYER CONTROLLER

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
    public GameObject currentHover;
    public GameObject currentHeld;
    public string holding;
    //allows interacting with ingredients, shaker, and serving tray
    public bool canGrab;
    public bool interactShaker;

    public void Update()
    {
        //interact controls depending on obj collision
        if (Input.GetKeyDown(interact))
        {
            if (currentHeld == null)
            {
                if (canGrab == true)
                {
                    currentHeld = currentHover.gameObject;
                    //holding = currentHeld.name;
                    OnGrab();
                }
            }
            else if (interactShaker == true && currentHeld != null)
            {
                Shaker.AddIngredient();
                currentHeld.SetActive(true);
                currentHeld = null;
            }
            else
            {
                currentHeld.SetActive(true);
                if (currentHeld != null)
                {
                    currentHeld = null;
                    holding = null;
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
        //checks what the player is hovering over
        if (collision.gameObject.CompareTag("Ingredients"))
        {
            currentHover = collision.gameObject;
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
        currentHover = null;
        canGrab = false;
        interactShaker = false;
    }
    public void OnGrab()
    {
        //holding string is used to match recipes
        currentHeld.SetActive(false);
        canGrab = false;
        holding = currentHeld.name;
    }

}