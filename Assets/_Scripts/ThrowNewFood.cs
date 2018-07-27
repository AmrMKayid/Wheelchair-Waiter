using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ThrowNewFood : MonoBehaviour
{

    public GameObject foodGameObject;

    public float forceScale = 10;
    public float rotationY = 0;

    bool throwNewFood = true;

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, -10, 0);
        StartCoroutine(CreateFoodLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if (!throwNewFood)
            return;

        // play sound *ding*


        // create prefab of food


        // set color & features

        // reset throwNewFood
    }

    public IEnumerator CreateFoodLoop()
    {
        while (true)
        {
            GetComponent<AudioSource>().Play();

            GameObject newFood = Instantiate(foodGameObject, transform.position + Vector3.up * 0.1f, Quaternion.identity);
            newFood.transform.rotation = Quaternion.Euler(-90, 0, 0);
            newFood.SetActive(true);
            newFood.GetComponent<Rigidbody>().useGravity = false;
            FlyingFood flyingFood = newFood.GetComponent<FlyingFood>();
            flyingFood.SetTableColor(CalculateTableColor());
            yield return new WaitForSeconds(1);

            newFood.GetComponent<Rigidbody>().useGravity = true;
            flyingFood.ApplyForce(CalculateFixedForceVector());
            yield return new WaitForSeconds(2);
        }
    }

    private Vector3 CalculateFixedForceVector()
    {
        float right = 2.5f * forceScale;
        float up = 11 * forceScale;
        float forward = 2.5f * forceScale;
        Vector3 forceVector = new Vector3(right, up, forward);
        return Quaternion.AngleAxis(rotationY, Vector3.up) * forceVector;
    }


    private Vector3 CalculateForceVector()
    {
        float right = Random.Range(2f * forceScale, 2.5f * forceScale);
        float up = Random.Range(10 * forceScale, 11 * forceScale);
        float forward = Random.Range(2 * forceScale, 2.5f * forceScale);
        Vector3 forceVector = new Vector3(right, up, forward);
        return Quaternion.AngleAxis(rotationY, Vector3.up) * forceVector;
    }

    private FoodColorEnum CalculateTableColor()
    {
        return (FoodColorEnum)Random.Range(0, 2);
    }

}
