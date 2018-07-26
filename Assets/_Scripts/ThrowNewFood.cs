using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ThrowNewFood : MonoBehaviour
{

    public GameObject foodGameObject;
    private AudioSource dingSound;

    public float forceScale = 10;
    public float rotationY = 0;

    bool throwNewFood = true;

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, -10, 0);
        dingSound = GetComponentInChildren<AudioSource>();
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
            GameObject newFood = Instantiate(foodGameObject, transform.position, Quaternion.identity);
            newFood.SetActive(true);
            FlyingFood flyingFood = newFood.GetComponent<FlyingFood>();
            flyingFood.ApplyForce(CalculateFixedForceVector());
            flyingFood.SetTableColor(CalculateTableColor());
            dingSound.Play();

            yield return new WaitForSeconds(2);
        }
    }

    private Vector3 CalculateFixedForceVector()
    {
        float right = 2 * forceScale;
        float up = 10 * forceScale;
        float forward = 2 * forceScale;
        Vector3 forceVector = new Vector3(right, up, forward);
        return Quaternion.AngleAxis(rotationY, Vector3.up) * forceVector;
    }


    private Vector3 CalculateForceVector()
    {
        float right = Random.Range(1.5f * forceScale, 4 * forceScale) + 0;
        float up = Random.Range(10 * forceScale, 12 * forceScale) + 0;
        float forward = Random.Range(-6 * forceScale, -5 * forceScale) + 0;
        Vector3 forceVector = new Vector3(right, up, forward);
        return Quaternion.AngleAxis(rotationY, Vector3.up) * forceVector;

    }

    private FoodColorEnum CalculateTableColor()
    {
        return (FoodColorEnum)Random.Range(0, 3);
    }

}
