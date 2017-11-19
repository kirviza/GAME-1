using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour {

    public GameObject playersObject;
    
    private GameObject Players1;
    private GameObject Players2;
	public GameObject PlayersText1;
	public GameObject PlayersText2;
	public GameObject StepText;
	public bool Step;
	public GameObject Tower1;
	public GameObject Tower2;
	public GameObject Box;

    private bool ChangeStep;
	private GameObject[] AllCubes;

	 

	// Use this for initialization
	void Start () {
        Players1 = Instantiate(playersObject);
        Players2 = Instantiate(playersObject);

        Players1.GetComponent<GamerScript>().numGamer = 1;
        Players2.GetComponent<GamerScript>().numGamer = 2;

		PlayersText1.GetComponent<Text>().text = "Игрок 1: 0";
		PlayersText2.GetComponent<Text>().text = "Игрок 2: 0";
		StepText.GetComponent<Text>().text = "Ходит игрок 1";

        Step = false;
        ChangeStep = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
			ChangeStep = false;

			AllCubes = GameObject.FindGameObjectsWithTag ("CubeField");

            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);
			if (hit.transform == null)
				return;
            if (hit.transform.gameObject.tag.Equals("CubeField"))
            {
                Debug.Log("Push Cube");
				return;
            }
            else if (hit.transform.gameObject.tag.Equals("WallField"))
            {
				foreach (GameObject cube in AllCubes) 
				{
					if (Vector3.Distance (cube.transform.position, hit.transform.gameObject.transform.position) < 1) 
					{
						cube.GetComponent<CubesScript> ().countWall++;
						if (cube.GetComponent<CubesScript> ().countWall == 4) 
						{
							ChangeStep = true;

							if (Step) {
								Players2.GetComponent<GamerScript> ().points++;
								PlayersText2.GetComponent<Text>().text = "Игрок 2: "+Players2.GetComponent<GamerScript> ().points.ToString();

								Box.GetComponent<BoxScript> ().tower = Tower2;
								Instantiate (Box, new Vector3 (cube.transform.position.x, Camera.main.transform.position.y+10, cube.transform.position.z), Quaternion.identity);
								//Instantiate(Tower2, new Vector3(cube.transform.position.x, 1, cube.transform.position.z), Quaternion.identity);
							} else {
								Players1.GetComponent<GamerScript> ().points++;
								PlayersText1.GetComponent<Text>().text = "Игрок 1: "+Players1.GetComponent<GamerScript> ().points.ToString();

								Box.GetComponent<BoxScript> ().tower = Tower1;
								Instantiate (Box, new Vector3 (cube.transform.position.x, Camera.main.transform.position.y+10, cube.transform.position.z), Quaternion.identity);
								//Instantiate	(Tower1, new Vector3(cube.transform.position.x, 1, cube.transform.position.z), Quaternion.identity);
							}
						}
					}
				}
                Destroy(hit.transform.gameObject);
                Debug.Log("Delete Wall");
            }
				
            if(!ChangeStep)
            	Step = !Step;

			if(Step)
				StepText.GetComponent<Text>().text = "Ходит игрок 2";
			else
				StepText.GetComponent<Text>().text = "Ходит игрок 1";
				
        }
		
	}
}
