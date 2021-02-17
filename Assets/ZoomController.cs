﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CubeInteractive : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}

using NRKernal;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        //get controller rotation, and set the value to the cube transform
        // transform.rotation = NRInput.GetRotation();

        Vector2 vec = NRInput.GetDeltaTouch();
        //Debug.Log(vec.x);
        if (Mathf.Abs(vec.x) >= Mathf.Abs(vec.y))
        {
            // TODO Implement
        }
        else
        {
            if (vec.y <= 0)  // swipe down in emu; swipe up on real device
            {
                // => zoom out
                // Linear method
                Vector3 newVal = transform.localScale * 0.985f;
                if (newVal.x >= 0.0005) {  // set a minimum value
                    transform.localScale = newVal;
                }

                // alternative: Addition
                //transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            }
            else  // swipe up in emu; swipe up on real device
            {
                // => zoom in
                // Linear method
                transform.localScale *= 1.015f;

                // alternative: Addition
                //transform.localScale += new Vector3(0.075f, 0.075f, 0.075f);
            }
        }
    }
}
