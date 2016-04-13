using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class PaddleScript : MonoBehaviour {

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
            Vector3 paddlePos = new Vector3(pos.x * 25, pos.y * 12.5f, -5f);
            paddle.transform.position = paddlePos;
        }
        else
        {
            Vector3 pos = transform.FindChild("RigidRoundHand_L").FindChild("palm").position;
            Vector3 paddlePos = new Vector3(pos.x * 25, pos.y * 12.5f, -5f);
            paddle.transform.position = paddlePos;
        }
    }
}
