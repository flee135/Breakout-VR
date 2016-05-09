using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneController : MonoBehaviour {

	public Text countDown, deaths;
	public GameObject bluePrefab, greenPrefab, yellowPrefab, orangePrefab, redPrefab;
    public GameObject ballPrefab, heartPrefab;
    public AudioClip countdownStart;
    public AudioClip countdownEnd;

    private GameObject ball;
	private int deathCount = 0;
    private float minYRange = -1f, maxYRange = 2f, minXRange = -5f, maxXRange = 5f, heartSpeed = 5.0f;

	void Start () {

		for (int i = -4; i <= 4; i++) {

			for (int j = -1; j <= 2; j++) {

				//Instantiate (bluePrefab, new Vector3 (2.0f * i, j * 2, -1.0f), Quaternion.identity);
				//Instantiate (greenPrefab, new Vector3 (2.0f * i, j * 2, 1.0f), Quaternion.identity);
				//Instantiate (yellowPrefab, new Vector3 (2.0f * i, j * 2, 3.0f), Quaternion.identity);
				Instantiate (orangePrefab, new Vector3 (2.0f * i, j * 2, 5.0f), Quaternion.identity);
				Instantiate (bluePrefab, new Vector3 (2.0f * i, j * 2, 7.0f), Quaternion.identity);

			}
		}

        for (int i = -4; i <= -3; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                for (int k = -1; k <= 1; k += 2)
                {
                    Instantiate(greenPrefab, new Vector3(2.0f * i, j * 2, k-1f), Quaternion.identity);
                }
            }
        }

        for (int i = 3; i <= 4; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                for (int k = -1; k <= 1; k += 2)
                {
                    Instantiate(greenPrefab, new Vector3(2.0f * i, j * 2, k-1f), Quaternion.identity);
                }
            }
        }

        ball = (GameObject)Instantiate(ballPrefab, new Vector3(Random.value * 10 - 5, Random.value * 3 - 1, -6), Quaternion.identity);
		heartPrefab.transform.Rotate (new Vector3 (0.0f, 45.0f, 0.0f));
		deaths.text = deathCount.ToString ();

        StartCoroutine(WaitToStart());

	}

    void Update()
    {
		heartPrefab.transform.Rotate (new Vector3 (0.0f, 0.0f, heartSpeed));
        if (ball.transform.position.z < -20 || Mathf.Abs(ball.transform.position.x) > 15 || Mathf.Abs(ball.transform.position.y) > 10)
        {
            ball.GetComponent<BallScript>().ResetBall();
			deaths.text = (++deathCount).ToString();
            StartCoroutine(WaitToStart());
        }
    }


    public IEnumerator WaitToStart()
    {
		countDown.text = "3";
        AudioSource.PlayClipAtPoint(countdownStart, new Vector3(0, 0, 0));
        yield return new WaitForSeconds(1);
        countDown.text = "2";
        AudioSource.PlayClipAtPoint(countdownStart, new Vector3(0, 0, 0));
		yield return new WaitForSeconds(1);
        countDown.text = "1";
        AudioSource.PlayClipAtPoint(countdownStart, new Vector3(0, 0, 0));
		yield return new WaitForSeconds(1);
        ball.GetComponent<BallScript>().MoveBall();
        countDown.text = "";
        AudioSource.PlayClipAtPoint(countdownEnd, new Vector3(0, 0, 0));
    }
}
