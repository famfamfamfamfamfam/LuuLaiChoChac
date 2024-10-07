using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IPlayMethod
{
    public float speed;

    public GameObject[] cornerObjs;

    public void Begin()
    {
        Debug.Log("Day la o to tai");
    }

    string dir = "l";
    //int rota = 10;
    //int count = 1;
    public Transform[] transformIns;
    int index = 0;
    void Turn()
    {
        Vector3 toThis = transformIns[index].position - transform.position;
        Quaternion faceIt = Quaternion.LookRotation(toThis);
        transform.rotation = Quaternion.Slerp(transform.rotation, faceIt, speed * 0.02f);
        index = index < transformIns.Length ? index + 1 : index;
        //transform.Rotate(0, 90, 0);
        //if (count < 9)
        //{
        //    count++;
        //    return;
        //}
        //count = 1;
        switch (dir)
        {
            case "l": dir = "u"; break;
            case "u": dir = "r"; break;
            case "r": dir = "d"; break;
            case "d": dir = "l"; break;
        }
    }

    void getTheLimits(GameObject[] arr, out float a, out float b, out float c, out float d)
    {
        float x = arr[0].transform.position.x;
        float z = arr[0].transform.position.z;
        a = 0;
        b = 0;
        c = 0;
        d = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].transform.position.x > x)
            {
                b = arr[i].transform.position.x;
                a = x;
            }
            else if (arr[i].transform.position.x < x)
            {
                a = arr[i].transform.position.x;
                b = x;
            }

            if (arr[i].transform.position.z > z)
            {
                d = arr[i].transform.position.z;
                c = z;
            }
            else if (arr[i].transform.position.z < z)
            {
                c = arr[i].transform.position.z;
                d = z;
            }
        }
    }

    //float a = -12;
    //float b = 96;
    //float c = -13;
    //float d = 108;
    //int i = 0;

    bool/*[]*/ isInTheArea(ref Vector3 curPos)
    {
        //bool[] rt = { curPos.x > a, curPos.z < d, curPos.x < b, curPos.z > c };
        //return rt;

        float a, b, c, d;

        getTheLimits(cornerObjs, out a, out b, out c, out d);

        switch (dir)
        {
            case "l": return curPos.x > a;
            case "u": return curPos.z < d;
            case "r": return curPos.x < b;
            case "d": return curPos.z > c;
            default: return false;
        }
    }

    void Run(ref Vector3 curPos)
    {
        //bool isInTheArea = curPos.x > a && curPos.x < b && curPos.z > c && curPos.z < d;

        if (isInTheArea(ref curPos)/*[i]*/)
        {
            switch (dir)
            {
                case "l": curPos.x -= speed * 0.02f; break;
                case "u": curPos.z += speed * 0.02f; break;
                case "r": curPos.x += speed * 0.02f; break;
                case "d": curPos.z -= speed * 0.02f; break;
            }
        }
        else
        {
            Turn();
            //if (i < 3) i++; else i = 0;
            //a--;
            //b++;
            //c--;
            //d++;
        }
    }
    public void FixedUpdatee()
    {
        Vector3 xeTai = transform.position;
        Run(ref xeTai);
        transform.position = xeTai;
    }
}
