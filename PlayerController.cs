using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayMethod
{
    public float speed;

    public void Begin()
    {
        Debug.Log("Day la xe con");
    }

    //private void Update()
    //{
    //    Debug.Log("Day la xe con");    
    //}

    string roed = "u";

    public void FixedUpdatee()
    {
        Vector3 curPos = transform.position;

        if (curPos.x == 96 && roed == "u")
        {
            if (curPos.z < 107)
            {
                curPos.z += speed * 0.02f;
                transform.position = curPos;
            }
            else
            {
                transform.Rotate(0, -90, 0);
                roed = "l";
            }
        }
        if (curPos.z >= 107 && roed == "l")
        {
            if (curPos.x > -11)
            {
                curPos.x -= speed * 0.02f;
                transform.position = curPos;
            }
            else
            {
                transform.Rotate(0, -90, 0);
                roed = "d";
            }
        }
        if (curPos.x <= -11 && roed == "d")
        {
            if (curPos.z > -11)
            {
                curPos.z -= speed * 0.02f;
                transform.position = curPos;
            }
            else
            {
                transform.Rotate(0, -90, 0);
                roed = "r";
            }
        }
        if (curPos.z <= -11 && roed == "r")
        {
            if (curPos.x < 96)
            {
                curPos.x += speed * 0.02f;
                transform.position = curPos;
            }
            else
            {
                transform.Rotate(0, -90, 0);
                roed = "u";
            }
        }
    }
}
