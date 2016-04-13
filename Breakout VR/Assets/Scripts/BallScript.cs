using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(new Vector3(1, 1, 1) * thrust );
	}
	
	// Update is called once per frame
	void Update () {
	}
}
