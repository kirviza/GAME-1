using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour {

    public GameObject playersObject;
    
	public GameObject Players1;
	public GameObject Players2;
	public Text PlayersText1;
	public Text PlayersText2;
	public GameObject Tower1;
	public GameObject Tower2;

	public Text StepText;

	public GameObject Box;
	public GameObject GhostWall;
	public GameObject GroupButtonYesNo;
	public GameObject GroupGhostWall;
	public bool yes_no;
	public bool Step = false;

	private GameObject createGhostWall;
	private GameObject createGroupButtonYesNo;
	 
	// Use this for initialization
	void Start () {
        Players1 = Instantiate(playersObject);
        Players2 = Instantiate(playersObject);

        Players1.GetComponent<GamerScript>().numGamer = 1;
        Players2.GetComponent<GamerScript>().numGamer = 2;

		PlayersText1.GetComponent<Text>().text = "Игрок 1: 0";
		PlayersText2.GetComponent<Text>().text = "Игрок 2: 0";
		StepText.GetComponent<Text>().text = "Ходит игрок 1";

		yes_no = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !yes_no)
        {
            RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			ray.direction = ray.direction * 3.0f;

            Physics.Raycast(ray, out hit);

			if (hit.transform == null)
				return;
			
			if (!hit.transform.gameObject.tag.Equals ("WallField")) {
				Debug.Log ("Push not wall");
				return;
			} else if (hit.transform.gameObject.tag.Equals ("WallField")) {
				createGhostWall = Instantiate (GhostWall, hit.transform.gameObject.transform.position, hit.transform.gameObject.transform.rotation, GroupGhostWall.transform);
		
				createGroupButtonYesNo = Instantiate (GroupButtonYesNo, hit.transform.gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);

				createGroupButtonYesNo.GetComponent<YesButtonScript> ().GhostWall = createGhostWall;
				createGroupButtonYesNo.GetComponent<YesButtonScript> ().Step = Step;
				if (Step)
					Box.GetComponent<BoxScript> ().tower = Tower2;
				else
					Box.GetComponent<BoxScript> ().tower = Tower1;

				createGroupButtonYesNo.GetComponent<NoButtonScript> ().GhostWall = createGhostWall;

				createGroupButtonYesNo.GetComponent<YesButtonScript> ().Box = Box;
		
				yes_no = true;
			}								
        }
		
	}
}
