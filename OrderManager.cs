using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{

    public MonoBehaviour[] obj;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] is IPlayMethod o)
            {
                o.Begin();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] is IPlayMethod o)
            {
                o.FixedUpdatee();
            }
        }
    }
}
