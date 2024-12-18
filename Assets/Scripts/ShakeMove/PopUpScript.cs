using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    public ShakeMove ShakeMove;
    public GameObject popup;

    public bool leftPlayerReady;
    public bool rightPlayerReady;
    public GameObject lPlayerStart;
    public GameObject rPlayerStart;
    public Sprite readySprite;
    private void Update()
    {
        //if both players interact, begin count down timer
        if (Input.GetKey(ShakeMove.interactL))
        {
            leftPlayerReady = true;
            lPlayerStart.GetComponent<UnityEngine.UI.Image>().overrideSprite = readySprite;
        }
        if (Input.GetKey(ShakeMove.interactR))
        {
            rightPlayerReady = true;
            rPlayerStart.GetComponent<UnityEngine.UI.Image>().overrideSprite = readySprite;
        }
        if(leftPlayerReady && rightPlayerReady)
        {
            popup.gameObject.SetActive(false);
        }
    }
}
