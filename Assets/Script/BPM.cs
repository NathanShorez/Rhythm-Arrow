using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPM : MonoBehaviour
{
    public float rate;

    public bool Started;
    void Start()
    {
        rate = rate / 60f;
    }

    // Update is per frame
    void Update()
    {
        if (!Started)
        {
            //if (Input.anyKeyDown)
            //{

            //  Started = true;
            //}
        }
        else
        {
            transform.position -= new Vector3(0f, rate * Time.deltaTime, 0f);
        }
        //Start at 7.95
        //Go up by increments of 2.65
    }

}
