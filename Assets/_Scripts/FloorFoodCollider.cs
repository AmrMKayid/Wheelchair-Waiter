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
            Debug.Log("detroy item");
            if (other.GetComponent<FlyingFood>() == null)
            {
                Debug.Log("other not root of food");
            }
            if (other.gameObject.GetComponent<FlyingFood>() == null)
            {
                Debug.Log("other.gameobject not root of food");
            }
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
