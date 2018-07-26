using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlateController : MonoBehaviour {
    private float nextActionTime = 0.0f;
    public float period = 2.0f;
    public GameObject gameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            Instantiate(gameObject, new Vector3(0.218f, 1.231f, 2.629f), Quaternion.identity);
            nextActionTime += period;
            // execute block of code here
        }
    }
    

}
