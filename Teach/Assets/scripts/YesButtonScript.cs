using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesButtonScript : MonoBehaviour {

	public GameObject GhostWall;
	public GameObject ConstWall;
	public bool ChangeStep = false;
	public bool Step;
	public GameObject Box;


	private GameObject[] AllCubes;
	private GameObject createConstWall;

	public void Button_Click()
	{
		createConstWall = Instantiate (ConstWall, GhostWall.transform.position, GhostWall.transform.rotation);
		Destroy (GhostWall);

		AllCubes = GameObject.FindGameObjectsWithTag ("CubeField");

		ChangeStep = false;

		foreach (GameObject cube in AllCubes) {
			if (Vector3.Distance (cube.transform.position, createConstWall.transform.position) < 1.1f) {
				cube.GetComponent<CubesScript> ().countWall++;
				if (cube.GetComponent<CubesScript> ().countWall == 4) {
					ChangeStep = true;

					if (Step) { 
						Camera.main.GetComponent<RulesScript>().Players2.GetComponent<GamerScript> ().points++;
						Camera.main.GetComponent<RulesScript>().PlayersText2.text = "Игрок 2: " + Camera.main.GetComponent<RulesScript>().Players2.GetComponent<GamerScript> ().points.ToString ();
					
						Instantiate (Box, new Vector3 (cube.transform.position.x, cube.transform.position.y, cube.transform.position.z), Quaternion.identity);
					} else {
						Camera.main.GetComponent<RulesScript>().Players1.GetComponent<GamerScript> ().points++;
						Camera.main.GetComponent<RulesScript>().PlayersText1.text = "Игрок 1: " + Camera.main.GetComponent<RulesScript>().Players1.GetComponent<GamerScript> ().points.ToString ();

						Instantiate (Box, new Vector3 (cube.transform.position.x, cube.transform.position.y, cube.transform.position.z), Quaternion.identity);
					}
				}
			}
		}

		if (!ChangeStep)
			Step = !Step;

		if(Step)
			Camera.main.GetComponent<RulesScript>().StepText.GetComponent<Text>().text = "Ходит игрок 2";
		else
			Camera.main.GetComponent<RulesScript>().StepText.GetComponent<Text>().text = "Ходит игрок 1";

		Camera.main.GetComponent<RulesScript> ().Step = Step;
		

		Camera.main.GetComponent<RulesScript> ().yes_no = false;
		Destroy (gameObject);
	}
}
