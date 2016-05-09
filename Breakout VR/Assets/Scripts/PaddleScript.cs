using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class PaddleScript : MonoBehaviour {

    private float MAX_X = 11.5f;
    private float MIN_X = -11.5f;
    private float MAX_Y = 7f;
    private float MIN_Y = -5f;

    public GameObject paddle;

    Controller controller;

    // Use this for initialization
    void Start()
    {
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

        if (rightHand != null || leftHand != null)
        {
            movePaddle(rightHand);
        }
	}

    private void movePaddle(Hand hand)
    {
        Transform rigidHand = transform.FindChild("RigidRoundHand_R");
        if (rigidHand.gameObject.activeSelf)
        {
            Vector3 pos = transform.FindChild("RigidRoundHand_R").FindChild("palm").position;
            float xPos = pos.x * 25f;
            if (xPos > MAX_X) xPos = MAX_X;
            else if (xPos < MIN_X) xPos = MIN_X;

            float yPos = pos.y * 20f - 17.5f;
            if (yPos > MAX_Y) yPos = MAX_Y;
            else if (yPos < MIN_Y) yPos = MIN_Y;
            Vector3 paddlePos = new Vector3(xPos, yPos, -10.25f);
            paddle.transform.position = paddlePos;
        }
        else
        {
            Vector3 pos = transform.FindChild("RigidRoundHand_L").FindChild("palm").position;
            float xPos = pos.x * 25f;
            if (xPos > MAX_X) xPos = MAX_X;
            else if (xPos < MIN_X) xPos = MIN_X;

            float yPos = pos.y * 20f - 17.5f;
            if (yPos > MAX_Y) yPos = MAX_Y;
            else if (yPos < MIN_Y) yPos = MIN_Y;
            Vector3 paddlePos = new Vector3(xPos, yPos, -10.25f);
            paddle.transform.position = paddlePos;
        }
    }
}
