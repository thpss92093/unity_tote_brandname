using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
    Rigidbody rb;
    public float pushForce;
    public bool isMoving;
    Vector3 prevLocation;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        prevLocation = transform.position;
    }

    // Update is called once per frame
    void Update() {

    }

    public void FixedUpdate()
    {
        if (prevLocation != transform.position)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        prevLocation = transform.position;
    }

    public void Push()
    {
        // can be improve by better way
        //Vector3 force = Random.insideUnitSphere * pushForce;

        Vector3 force = Random.insideUnitSphere * pushForce;
        force.y = transform.position.y;
        Debug.Log(force);
        rb.AddForce(force, ForceMode.Impulse);
        Debug.DrawLine(transform.position, transform.right, Color.red, 2f);

        //        Vector3 up = transform.up * Random.value - transform.up / 2;
        //        Vector3 forward = transform.forward * Random.value - transform.forward / 2;
        //        Vector3 right = transform.right * Random.value - transform.right / 2;
        //        Vector3 rndF = (up + forward + right) * pushForce;
        //Debug.DrawLine(transform.position, transform.position + rndF, Color.green, 2f);
        //rb.AddForce(rndF, ForceMode.Impulse);

        isMoving = true;
    }

    public void Place(int c, string o)
    {
        //cuboid 20 scene
        if (o == "milo" || o == "pocky" || o == "crayola" || o == "andes" || o == "macadamia")
        {
            //obj: face_2 rotation_5 position_1    cam: rotation_15 height_3 angle_3
            //position 1
            transform.position = new Vector3(0, 0.9f, 0);

            //face 2
            if ((c % 10) < 5)   //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);
            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 135, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 157.5f, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 202.5f, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 225, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "kotex" || o == "kleenex" || o == "raisins" || o == "swiss_miss" || o == "kellogg" || o == "mm" || o == "libava" || o == "ziploc")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.92f, 0);

            //face 2
            if ((c % 10) < 5) //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                   //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);

            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 135, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 157.5f, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 202.5f, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 225, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        //Cylinder 20 scene
        else if (o == "viva")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c == 4) 
                transform.position = new Vector3(0, 0.97f, 0);
            else
                transform.position = new Vector3(0, 0.89f, 0);

            //face 2 rotation 5
            if (c == 0)
                transform.eulerAngles = new Vector3(0, 135, 0);
            else if (c == 1)
                transform.eulerAngles = new Vector3(0, 157.5f, 0);
            else if (c == 2)
                transform.eulerAngles = new Vector3(0, 202.5f, 0);
            else if (c == 3) 
                transform.eulerAngles = new Vector3(0, 225, 0);
            else if (c == 4)
                transform.eulerAngles = new Vector3(270, 180, 0);
            else //5 ~ 9
                transform.eulerAngles = new Vector3(0, 180, (c - 7) * 40);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "3m" || o == "heineken" || o == "cocacola" || o == "stax")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c == 4)
                transform.position = new Vector3(0, 0.97f, 0);
            else               //11
                transform.position = new Vector3(0, 0.9f, 0);

            //face 2 rotation 5
            if (c == 0)
                transform.eulerAngles = new Vector3(0, 135, 0);
            else if (c == 1)
                transform.eulerAngles = new Vector3(0, 157.5f, 0);
            else if (c == 2)
                transform.eulerAngles = new Vector3(0, 202.5f, 0);
            else if (c == 3)
                transform.eulerAngles = new Vector3(0, 225, 0);
            else if (c == 4)
                transform.eulerAngles = new Vector3(270, 180, 0);
            else //5 ~ 9
                transform.eulerAngles = new Vector3(0, 180, (c - 7) * 40);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "folgers" || o == "hunts" || o == "vanish")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c == 4) //5
                transform.position = new Vector3(0, 0.91f, 0);
            else
                transform.position = new Vector3(0, 0.9f, 0);

            //face 2 rotation 5
            if (c == 0)
                transform.eulerAngles = new Vector3(0, 135, 0);
            else if (c == 1)
                transform.eulerAngles = new Vector3(0, 157.5f, 0);
            else if (c == 2)
                transform.eulerAngles = new Vector3(0, 202.5f, 0);
            else if (c == 3)
                transform.eulerAngles = new Vector3(0, 225, 0);
            else if (c == 4)
                transform.eulerAngles = new Vector3(270, 180, 0);
            else //5 ~ 9
                transform.eulerAngles = new Vector3(0, 180, (c - 7) * 40);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
    }
    public void Place_2(int c, string o)
    {
        //cuboid 20 scene
        if (o == "milo" || o == "pocky")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.9f, 0);
            else        //10 ~ 19
                transform.position = new Vector3(-0.08f, 0.9f, 0.1f);
            //face 2
            if ((c % 10) < 5)   //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);
            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 150, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 240, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "crayola" || o == "andes")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.88f, 0);
            else        //10 ~ 19
                transform.position = new Vector3(-0.11f, 0.9f, 0.11f);

            //face 2
            if ((c % 10) < 5) //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                   //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(270, transform.eulerAngles.y, 0);

            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 150, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 240, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "kotex" || o == "kleenex" || o == "raisins")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.92f, 0);
            else        //10 ~ 19
                transform.position = new Vector3(-0.11f, 0.94f, 0.11f);

            //face 2
            if ((c % 10) < 5) //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                   //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);

            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 150, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 240, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "macadamia")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.9f, 0);
            else        //10 ~ 19
                transform.position = new Vector3(-0.08f, 0.91f, 0.12f);

            //face 2
            if ((c % 10) < 5) //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                   //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);

            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 150, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 240, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "swiss_miss")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.93f, 0);
            else        //10 ~ 19
                transform.position = new Vector3(-0.05f, 0.93f, 0.08f);

            //face 2
            if ((c % 10) < 5) //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                   //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);

            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 150, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 240, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "kellogg")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.9f, 0);
            else        //10 ~ 19
                transform.position = new Vector3(-0.033f, 0.9f, 0.033f);

            //face 2
            if ((c % 10) < 5) //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                   //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);

            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 150, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 240, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "ziploc")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.93f, 0);
            else        //10 ~ 19
                transform.position = new Vector3(-0.05f, 0.93f, 0.08f);

            //face 2
            if ((c % 10) < 5) //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                   //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);

            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 150, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 240, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "mm" || o == "libava")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 10) //0 ~ 9
                transform.position = new Vector3(0, 0.92f, 0);
            else        //10 ~ 19
                transform.position = new Vector3(-0.09f, 0.9f, 0.1f);

            //face 2
            if ((c % 10) < 5) //0 ~ 4    10 ~ 14 
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            else                   //5 ~ 9    15 ~ 19
                transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);

            //rotation 5
            if (c % 5 == 0)      //0  5  10  15
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120, transform.eulerAngles.z);
            else if (c % 5 == 1) //1  6  11  16
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 150, transform.eulerAngles.z);
            else if (c % 5 == 2) //2  7  12  17
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            else if (c % 5 == 3) //3  8  13  18
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z);
            else                 //4  9  14  19
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 240, transform.eulerAngles.z);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        //Cylinder 20 scene
        else if (o == "viva")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 5 || c > 11) //0 ~ 4
                transform.position = new Vector3(0, 0.89f, 0);
            else if (c == 5) //5
                transform.position = new Vector3(0, 0.97f, 0);
            else if (c >= 6 && c < 11) //6 ~ 10
                transform.position = new Vector3(0.033f, 0.9f, 0.033f);
            else               //11
                transform.position = new Vector3(0.1f, 0.97f, 0.1f);

            //face 2 rotation 5
            if ((c % 6) < 5 && c < 11)  //0 ~ 4    6 ~ 10
            {
                if (c % 5 == 0)      //0  6
                    transform.eulerAngles = new Vector3(0, 120, 0);
                else if (c % 5 == 1) //1  7
                    transform.eulerAngles = new Vector3(0, 150, 0);
                else if (c % 5 == 2) //2  8
                    transform.eulerAngles = new Vector3(0, 180, 0);
                else if (c % 5 == 3) //3  9
                    transform.eulerAngles = new Vector3(0, 210, 0);
                else                 //4  10
                    transform.eulerAngles = new Vector3(0, 240, 0);
            }
            else if (c == 5 || c == 11)             //5 11
                transform.eulerAngles = new Vector3(270, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, (c - 11) * 40);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "3m" || o == "heineken" || o == "cocacola" || o == "stax")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 5 || c > 11) //0 ~ 4
                transform.position = new Vector3(0, 0.9f, 0);
            else if (c == 5) //5
                transform.position = new Vector3(0, 0.97f, 0);
            else if (c >= 6 && c < 11) //6 ~ 10
                transform.position = new Vector3(0.033f, 0.9f, 0.033f);
            else               //11
                transform.position = new Vector3(0.1f, 0.97f, 0.1f);

            //face 2 rotation 5
            if ((c % 6) < 5 && c < 11)  //0 ~ 4    6 ~ 10
            {
                if (c % 5 == 0)      //0  6
                    transform.eulerAngles = new Vector3(0, 120, 0);
                else if (c % 5 == 1) //1  7
                    transform.eulerAngles = new Vector3(0, 150, 0);
                else if (c % 5 == 2) //2  8
                    transform.eulerAngles = new Vector3(0, 180, 0);
                else if (c % 5 == 3) //3  9
                    transform.eulerAngles = new Vector3(0, 210, 0);
                else                 //4  10
                    transform.eulerAngles = new Vector3(0, 240, 0);
            }
            else if (c == 5 || c == 11)             //5 11
                transform.eulerAngles = new Vector3(270, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, (c - 11) * 40);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
        else if (o == "folgers" || o == "hunts" || o == "vanish")
        {
            //obj: face_2 rotation_5 position_2    cam: rotation_15 height_3 angle_3
            //position 2
            if (c < 5 || c > 11) //0 ~ 4
                transform.position = new Vector3(0, 0.9f, 0);
            else if (c == 5) //5
                transform.position = new Vector3(0, 0.91f, 0);
            else if (c >= 6 && c < 11) //6 ~ 10
                transform.position = new Vector3(0.1f, 0.91f, 0.1f);
            else               //11
                transform.position = new Vector3(0.1f, 0.91f, 0.11f);

            //face 2 rotation 5
            if ((c % 6) < 5 && c < 11)  //0 ~ 4    6 ~ 10
            {
                if (c % 5 == 0)      //0  6
                    transform.eulerAngles = new Vector3(0, 120, 0);
                else if (c % 5 == 1) //1  7
                    transform.eulerAngles = new Vector3(0, 150, 0);
                else if (c % 5 == 2) //2  8
                    transform.eulerAngles = new Vector3(0, 180, 0);
                else if (c % 5 == 3) //3  9
                    transform.eulerAngles = new Vector3(0, 210, 0);
                else                 //4  10
                    transform.eulerAngles = new Vector3(0, 240, 0);
            }
            else if (c == 5 || c == 11)             //5 11
                transform.eulerAngles = new Vector3(270, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, (c - 11) * 40);

            Debug.Log("eulerAngles = " + transform.eulerAngles);
            isMoving = true;
        }
    }

    public void Reset()
	{
		//transform.position = new Vector3 (0, 0.9f, 0);
        isMoving = true;
        //Debug.Log("transform.position = " + transform.position);
    }
}
