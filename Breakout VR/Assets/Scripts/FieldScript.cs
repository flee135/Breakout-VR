using UnityEngine;
using System.Collections;

public class FieldScript : MonoBehaviour {

	private Material origMat;
	private bool isFading = false;
	private float fadeTime = 0.075f;

	void Start() {

		origMat = gameObject.GetComponent<Renderer> ().material;

	}

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.CompareTag ("Ball")) {

			Material origMat = gameObject.GetComponent<Renderer> ().material;
			Color finalColor = origMat.color, startColor = finalColor;

			if (isFading == false) {

				isFading = true;
				StartCoroutine (fade ());

			} else {
				
				StopAllCoroutines();
				StartCoroutine (fade ());

			}

		}

	}

	Color setAlpha (float alphaLevel) {

		return new Color (origMat.color.r, origMat.color.g, origMat.color.b, alphaLevel);

	}

	IEnumerator fade () {
		
		Color finalColor = origMat.color;
		float alphaLevel = 1.0f;

		while (alphaLevel > 0.0f) {

			origMat.color = setAlpha(alphaLevel -= 0.05f);

			if (alphaLevel < 0.05f) {

				isFading = false;
				origMat.color = setAlpha(0.0f);
				StopCoroutine (fade());
				break;

			}

			yield return new WaitForSeconds (fadeTime);

		}

	}

}
