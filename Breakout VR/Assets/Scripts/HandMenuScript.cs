using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class HandMenuScript : MonoBehaviour {

    public GameObject menu;
    public Text breakoutText;
    public Text exitText;

    Controller controller;

	// Use this for initialization
	void Start () {
        controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;
        Hand leftHand = null;
        Hand rightHand = null;
        foreach (Hand hand in hands)
        {
            if (hand.IsLeft) leftHand = hand;
            else if (hand.IsRight) rightHand = hand;
        }

        if (menu.activeSelf)
        {
            handleMenu(rightHand);
        }
	}

    private void handleMenu(Hand rightHand)
    {
        if (rightHand == null)
        {
            breakoutText.color = Color.black;
            exitText.color = Color.black;
            return;
        }

        Vector position = rightHand.PalmPosition;
        Color myRed = new Color(position.y/300, 0, 0);

        if (position.z < 0) // Top
        {
            breakoutText.color = myRed;
            exitText.color = Color.black;

            if (rightHand.PalmPosition.y > 300)
            {
                menu.SetActive(false);
            }
        }
        else
        {
            breakoutText.color = Color.black;
            exitText.color = myRed;

            if (rightHand.PalmPosition.y > 300)
            {
                Application.Quit();
            }
        }
    }
}
