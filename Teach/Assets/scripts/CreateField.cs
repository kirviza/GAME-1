using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateField : MonoBehaviour {

    public float Heigth_camera = 10.0f;
    public int Size_Field = 4;
    public GameObject cube;
    public GameObject wall;

    private bool helpVal;

	// Use this for initialization
	void Start () {
        int countCubes = 0;
        int x=0, z=0;
       
        //gameObject.transform.SetPositionAndRotation(new Vector3(0, Heigth_camera, 0), new Quaternion(Mathf.Sqrt(0.5f), 0, 0, Mathf.Sqrt(0.5f)));

        //Просчитываю количество кубиков на поле
        for (int i = Size_Field; i > 0; i -= 2)
        {
            countCubes += i;
        }
        countCubes *= 2;

        //Выставляю кубики выше оси Х
        for (int i = 0; i < Size_Field / 2; i++)
        {
            x = i;
            for (int j = 0; j < Size_Field-2*i; j++)
            {
                x++;

                if( j==0 || (j == Size_Field-2*i-1))
                {
                    cube.GetComponent<CubesScript>().countWall = 2;
                }else
                {
                    cube.GetComponent<CubesScript>().countWall = 0;
                }

                Instantiate(cube, new Vector3(-Size_Field/2 - 0.5f + x, 0, 0.5f+z), Quaternion.identity);
            }
            z++;
        }

        //Выставляю кубики ниже оси Х
        z = 0;
        x = 0;
        for (int i = 0; i < Size_Field / 2; i++)
        {
            x = i;
            for (int j = 0; j < Size_Field - 2 * i; j++)
            {
                x++;

                if( j==0 || (j == Size_Field-2*i-1))
                {
                    cube.GetComponent<CubesScript>().countWall = 2;
                }else
                {
                    cube.GetComponent<CubesScript>().countWall = 0;
                }


                Instantiate(cube, new Vector3(-Size_Field/2 - 0.5f + x, 0, -0.5f-z), Quaternion.identity);
            }
            z++;
        }

        //Выставляю вертикальные стенки выше оси X
        z = 0;
        x = 0;
        for (int i = 0; i < Size_Field / 2; i++)
        {
            x = i;
            for (int j = 0; j < Size_Field + 1 - 2 * i; j++)
            {
                x++;

				if( j==0 || (j == Size_Field-2*i))
				{
					wall.tag = "ConstWallField";
				}else
				{
					wall.tag = "WallField";
				}

				Instantiate(wall, new Vector3(-Size_Field / 2 - 1 + x, 0.501f, 0.5f + z), new Quaternion(0, Mathf.Sqrt(0.5f), 0, Mathf.Sqrt(0.5f)));
            }
            z++;
        }

        //Выставляю вертикальные стенки правее оси Z
        z = 0;
        x = 0;
        for (int i = 0; i < Size_Field / 2; i++)
        {
            x = i;
            for (int j = 0; j < Size_Field + 1 - 2 * i; j++)
            {
                x++;

				if( j==0 || (j == Size_Field-2*i))
				{
					wall.tag = "ConstWallField";
				}else
				{
					wall.tag = "WallField";
				}

				Instantiate(wall, new Vector3(-Size_Field / 2 - 1 + x, 0.501f,-0.5f - z), new Quaternion(0, Mathf.Sqrt(0.5f), 0, Mathf.Sqrt(0.5f)));
            }
            z++;
        }

        //Выставляю горизонтальные стенки правее оси Z
        z = 0;
        x = 0;
        for (int i = 0; i < Size_Field / 2; i++)
        {
            x = i;
            for (int j = 0; j < Size_Field + 1 - 2 * i; j++)
            {
                x++;

				if( j==0 || (j == Size_Field-2*i))
				{
					wall.tag = "ConstWallField";
				}else
				{
					wall.tag = "WallField";
				}

				Instantiate(wall, new Vector3(0.5f + z , 0.501f,  - Size_Field / 2 - 1 + x), Quaternion.identity);
            }
            z++;
        }

        
        //Выставляю горизонтальные стенки левее оси Z
        z = 0;
        x = 0;
        for (int i = 0; i < Size_Field / 2; i++)
        {
            x = i;
            for (int j = 0; j < Size_Field + 1 - 2 * i; j++)
            {
                x++;

				if( j==0 || (j == Size_Field-2*i))
				{
					wall.tag = "ConstWallField";
				}else
				{
					wall.tag = "WallField";
				}

                Instantiate(wall, new Vector3(-0.5f - z, 0.501f, - Size_Field / 2 - 1 + x), Quaternion.identity);
            }
            z++;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
