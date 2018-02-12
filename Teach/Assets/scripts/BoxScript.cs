using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

	public GameObject tower;
	public float StartTime = 0;
	public float MidTime = 0;
	public float FinishTime = 0;

	private bool CreateTower = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		StartTime += Time.deltaTime;

		if (StartTime>MidTime && !CreateTower) 
		{
			Instantiate (tower, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.5f, gameObject.transform.position.z), Quaternion.identity, GameObject.Find("GroupTower").transform);
			CreateTower = !CreateTower;
		}

		if (StartTime > FinishTime) 
		{
			Destroy (gameObject);
		}
	}
}
