using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

	public GameObject tower;
	public float speed;
	public float StartTime = 0;
	public float FinishTime = 0;

	private bool UpDown = false;
	private bool CreateTower = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameObject.transform.position.y > 0.5f && !UpDown) {
			transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
		} else if (transform.position.y > Camera.main.transform.position.y && UpDown) {
			Destroy (gameObject);
		} else {
			if(StartTime>FinishTime)
				transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
			StartTime += Time.deltaTime;
			
			if (!CreateTower) 
			{
				Instantiate (tower, transform.position, Quaternion.identity);
				CreateTower = !CreateTower;
				UpDown = !UpDown;
			}
			
		}
		
	}
}
