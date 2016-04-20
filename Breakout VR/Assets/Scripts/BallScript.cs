using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(new Vector3(1.0f, 0.0f, 0.0f) * 100.0f);
	}

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.CompareTag ("Block")) {

			Destroy (other.gameObject);

		}

	}

}
