using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ThrowNewFood : MonoBehaviour
{

    public GameObject foodGameObject;

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
            GameObject newFood = Instantiate(foodGameObject, transform.position , Quaternion.identity);
            FlyingFood flyingFood = newFood.GetComponent<FlyingFood>();
            flyingFood.ApplyForce(CalculateForceVector());
            flyingFood.SetTableColor(CalculateTableColor());

            yield return new WaitForSeconds(2);
        }
    }

    private Vector3 CalculateForceVector()
    {
        float right = Random.Range(150, 400) + 0;
        float up = Random.Range(600, 800) + 0;
        float forward = Random.Range(-600, -500) + 0;
        return new Vector3(right, up, forward);
    }

    private FoodColorEnum CalculateTableColor()
    {
        return (FoodColorEnum)Random.Range(0, 3);
    }

}
