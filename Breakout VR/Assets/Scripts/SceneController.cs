using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneController : MonoBehaviour {

	public Text countDown;
	public GameObject bluePrefab, greenPrefab, yellowPrefab, orangePrefab, redPrefab;
    public GameObject ballPrefab;

    private GameObject ball;
    private float minYRange = -1f;
    private float maxYRange = 2f;
    private float minXRange = -5f;
    private float maxXRange = 5f;

	void Start () {

		for (int i = -4; i <= 4; i++) {

			for (int j = -1; j <= 2; j++) {

				//Instantiate (bluePrefab, new Vector3 (2.0f * i, j * 2, -6.0f), Quaternion.identity);
				//Instantiate (greenPrefab, new Vector3 (2.0f * i, j * 2, -4.0f), Quaternion.identity);
				//Instantiate (yellowPrefab, new Vector3 (2.0f * i, j * 2, -2.0f), Quaternion.identity);
				Instantiate (orangePrefab, new Vector3 (2.0f * i, j * 2, 0.0f), Quaternion.identity);
				Instantiate (redPrefab, new Vector3 (2.0f * i, j * 2, 2.0f), Quaternion.identity);

			}

		}

        ball = (GameObject)Instantiate(ballPrefab, new Vector3(Random.value * 10 - 5, Random.value * 3 - 1, -6), Quaternion.identity);

        StartCoroutine(WaitToStart());

	}

    void Update()
    {
        if (ball.transform.position.z < -20 || Mathf.Abs(ball.transform.position.x) > 15 || Mathf.Abs(ball.transform.position.y) > 10)
        {
            ball.GetComponent<BallScript>().ResetBall();
            StartCoroutine(WaitToStart());
        }
    }


    public IEnumerator WaitToStart()
    {
		countDown.text = "3";
        yield return new WaitForSeconds(1);
		countDown.text = "2";
		yield return new WaitForSeconds(1);
		countDown.text = "1";
		yield return new WaitForSeconds(1);
        ball.GetComponent<BallScript>().MoveBall();
		countDown.text = "";
    }
}
