using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bCameraScript : MonoBehaviour {
    public static bool isSwitchDown;
    public static bool isSwitchUp;
    // Use this for initialization
    void Start () {
        isSwitchDown = false;
        isSwitchUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick()
    {
        Quaternion pos = GameObject.Find("Sphere").transform.rotation;
        if (pos == CameraController.originRotation) {
            isSwitchDown = true;
            isSwitchUp = false;
        }
        else {
            isSwitchDown = false;
            isSwitchUp = true;
        }
    }
}
