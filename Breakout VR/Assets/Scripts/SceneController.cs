using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public GameObject bluePrefab, greenPrefab, yellowPrefab, orangePrefab, redPrefab;

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

	}

}
