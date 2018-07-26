using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using VRTK;
public class plate : MonoBehaviour {

    float direction;
    public float maxLimit, lowerLimit, xChange;
    private bool first = true, finished=false;
    void start()
    {
        
    }

    void Update()
    {
        if(!finished)
        {
            if (first)
        {
            GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
                maxLimit = transform.position.y + 20;// you set this to your desired height
            lowerLimit = transform.position.y;//this can be whatever you want as well
            direction = 0.05f;// you can put this as any number you want, the larger the number the more it will look like teleporting, the smaller the number the more smooth but the less distance it will travel per frame/time
            float rand = Random.Range(0f, 0.9f);
            Debug.Log(rand);
            Console.WriteLine("Hello");
            xChange = rand;
            first = false;
        }
        transform.position = transform.position + new Vector3(Time.fixedDeltaTime*xChange, direction, -Time.fixedDeltaTime * 0.7f);
        //Debug.Log(xChange);
        if (transform.position.y <= maxLimit)
        {
            //Debug.Log(Time.fixedDeltaTime);
            direction = Time.fixedDeltaTime * 0.001f;
        }
        }
    }
    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)

    {

        finished = true;

    }
}
