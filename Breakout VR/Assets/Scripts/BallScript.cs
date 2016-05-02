using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	private Rigidbody rb;
    public float thrust;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		//rb.AddForce(new Vector3(1.0f, 1.0f, 1.0f) * thrust);
	}

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.CompareTag ("Block")) {

			Destroy (other.gameObject);

		}

	}

    public void ResetBall()
    {
        transform.position = new Vector3(Random.value * 10 - 5, Random.value * 3 - 1, -6);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void MoveBall()
    {
        rb.AddForce(new Vector3(1.0f, 1.0f, 1.0f) * thrust);
    }

}
