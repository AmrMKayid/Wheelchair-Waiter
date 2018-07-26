using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFoodCollider : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag.Equals("FoodObj"))
        {
            Destroy(other);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
