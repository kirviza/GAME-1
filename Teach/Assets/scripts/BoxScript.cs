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
			int angle = Random.Range (0, 360);
			Debug.Log (angle);
			tower.transform.Rotate(0, angle, 0);
			Instantiate (tower, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.5f, gameObject.transform.position.z), tower.transform.rotation, GameObject.Find("GroupTower").transform);
			CreateTower = !CreateTower;
		}

		if (StartTime > FinishTime) 
		{
			Destroy (gameObject);
		}
	}
}
