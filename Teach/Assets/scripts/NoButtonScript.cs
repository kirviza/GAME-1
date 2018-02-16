using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButtonScript : MonoBehaviour {

	public GameObject GhostWall;

	public void Button_Click()
	{
		Destroy (GhostWall);
		Camera.main.GetComponent<RulesScript> ().yes_no = false;
		Destroy (gameObject);
	}
}
