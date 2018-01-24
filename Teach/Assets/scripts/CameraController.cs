using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float r; //радиус (расстояние) до центра сферы вращения
	public float angle;
	bool isRotate = false;
    public Quaternion current;
    public static Quaternion originRotation;
    public static Quaternion endRotation;
    public float deltaX;
    public bool SwapRight = false;
    public bool SwapLeft = false;
    public bool SwapUp = false;
    public bool SwapDown = false;
    public int tC;
    // Use this for initialization
    void Start () {
        originRotation = transform.rotation;
        endRotation = new Quaternion(-0.4619398f, -0.3314136f, -0.1913417f, 0.8001032f);
        angle = 0;
        deltaX = 0;
	}
	
	// Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate() {
        tC = Input.touchCount;
        Quaternion cPos = transform.rotation;
        if (tC == 0)
        {
            SwapDown = false;
            SwapLeft = false;
            SwapRight = false;
            SwapUp = false;
        }
        current = transform.rotation;
        if (bCameraScript.isSwitchDown)
        {
            angle++;
            transform.rotation = Quaternion.Slerp(originRotation, endRotation, Time.deltaTime * angle);
            if (current.x == endRotation.x) {
                bCameraScript.isSwitchDown = false;
                angle = 0;
            }
        }
        if (bCameraScript.isSwitchUp)
        {
            angle++;
            transform.rotation = Quaternion.Slerp(cPos, originRotation, Time.deltaTime * angle);
            if (current.x == originRotation.x) {
                bCameraScript.isSwitchUp = false;
                angle = 0;
            }
        }
        if ((bCameraScript.isSwitchDown == false) && (bCameraScript.isSwitchUp == false))
        {
            if (tC > 0 && (cPos!=originRotation)) Swipe();
        }
        if (SwapRight||SwapLeft)
        {

            transform.RotateAround(Vector3.up, deltaX * Time.deltaTime);
        }
      
    }
    public void Swipe()
    {

        Vector2 swipe_direction = Input.GetTouch(0).deltaPosition;
        if (Mathf.Abs(swipe_direction.x) < Mathf.Abs(swipe_direction.y)) {
            if (swipe_direction.y < 0) { SwapDown = true; Debug.Log("Down"); }
            else { SwapUp = true; Debug.Log("Up"); }
            }
        if (Mathf.Abs(swipe_direction.x) > Mathf.Abs(swipe_direction.y))
        {
            if (swipe_direction.x < 0) { SwapLeft = true; Debug.Log("Left"); deltaX = swipe_direction.x; }
            else { SwapRight = true; Debug.Log("Right"); deltaX = swipe_direction.x; }
            }
        
        
    }
}
