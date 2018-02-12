using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNoGroupScript : MonoBehaviour {

	public float speed = 1.0f;
	Vector3 new_scale;
	// Use this for initialization
	void Start () {
		Vector3 newPosition = gameObject.GetComponent<RectTransform> ().localPosition;
		newPosition.z = 0;
		gameObject.GetComponent<RectTransform> ().localPosition = newPosition;
		gameObject.GetComponent<RectTransform>().localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<RectTransform> ().localScale.x < 0.5f) {
			new_scale = gameObject.GetComponent<RectTransform> ().localScale;

			new_scale.x += Time.deltaTime * speed;
			new_scale.y = new_scale.x;
			new_scale.z = new_scale.x;

			gameObject.GetComponent<RectTransform> ().localScale = new_scale;
		}
	}
}
