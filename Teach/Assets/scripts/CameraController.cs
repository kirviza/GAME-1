using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SwipeController
{
    public bool isHorizontal;   //Является ли свайп горизонтальным
    public bool isVerticat;     //Является ли свайп вертикальным
    public float smooth;        //Пригодится при размытии движения
    public float maxSpeed;      //Пригодится при размытии движения
    public float deltaX;        //Перемещение пальца по X
    public float deltaY;        //Перемещение пальца по Y
    public int touchCount;      //Количество касаний


    public void Swipe()
    {
        touchCount = Input.touchCount;
        if (touchCount != 0)
        {
            Vector2 swipe_direction = Input.GetTouch(0).deltaPosition;
            if (Mathf.Abs(swipe_direction.x) >= Mathf.Abs(swipe_direction.y))
            {
                isHorizontal = true;
                isVerticat = false;
                deltaX = swipe_direction.x;
                Debug.Log("HorizontalSwipe");
            }
            else
            {
                isHorizontal = false;
                isVerticat = true;
                deltaY = swipe_direction.y;
                Debug.Log("VerticalSwipe");
            }
        }
        
        else
        {
            isHorizontal = false;
            isVerticat = false;
            deltaX = 0f;
            deltaY = 0f;
        }

    }

}
public class CameraController : MonoBehaviour {
    public SwipeController _swipeC;
	public float r;                         //радиус (расстояние) до центра сферы вращения
	public float angle;
    public Vector3 endRotEuler;
    public float smooth;
    public Vector3 cRot;                    //CurrentRotaion - текущее врещение в углах Эйлера
    public float maxSpeed;                  //Для функции размытия
    public float time;                      //Для функции размытия
    public bool stop = true;                

    private float speedX;
    private float speedY;
    private Vector3 originRotEuler;
    private Vector3 firstRot;
    private Vector3 secondRot;
    // Use this for initialization
    void Start () {
        originRotEuler = transform.eulerAngles;
        secondRot = endRotEuler;
        angle = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        _swipeC.Swipe();
        cRot = transform.eulerAngles;
        if (!stop)
        {
            float newXangle = Mathf.SmoothDampAngle(cRot.x, endRotEuler.x, ref speedX, time, maxSpeed);
            float newYangle = Mathf.SmoothDampAngle(cRot.y, endRotEuler.y, ref speedY, time, maxSpeed);
            transform.eulerAngles = new Vector3(newXangle, newYangle, transform.eulerAngles.z);
            if ( Mathf.Abs(speedX) < 0.001f) stop = true;
        }
        
        if (_swipeC.isHorizontal)
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, _swipeC.deltaX*3.5f * Time.deltaTime);
        }
    }
    

    public void CameraGo()
    {

        if (Mathf.Abs(cRot.x)>1e-3) endRotEuler = originRotEuler; else endRotEuler = secondRot;
        if (stop) stop = false;
    }
}
