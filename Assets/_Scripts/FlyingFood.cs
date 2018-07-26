using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFood : MonoBehaviour
{
    public GameObject redObject;
    public GameObject greenObject;
    public GameObject blueObject;

    private FoodColorEnum tableColor;

    private void Start()
    {
        if (redObject == null || blueObject == null || greenObject == null)
        {
            Debug.Log("Set red/blue/green Object in FlyingFood Script in Unity Editor");
        }
    }

    private void Update()
    {
        if (transform.position.y < 0)
        {
            OnCollisionWithFloor();
        }
    }

    private void OnCollisionWithFloor()
    {
        // play sound
        AudioSource plateCrashSound = gameObject.GetComponentInChildren<AudioSource>();
        plateCrashSound.Play();

        // decrease life left

        // remove plate
        Destroy(gameObject);
    }

    public void ApplyForce(Vector3 forceVector)
    {
        GetComponent<Rigidbody>().AddForce(forceVector);
    }

    public void SetTableColor(FoodColorEnum tableColor)
    {
        this.tableColor = tableColor;
        switch (tableColor)
        {
            case FoodColorEnum.red:
                redObject.tag = "FoodObj";
                greenObject.SetActive(false);
                blueObject.SetActive(false);
                break;
            case FoodColorEnum.green:
                redObject.SetActive(false);
                greenObject.tag = "FoodObj";
                blueObject.SetActive(false);
                break;
            case FoodColorEnum.blue:
                redObject.SetActive(false);
                greenObject.SetActive(false);
                blueObject.tag = "FoodObj";
                break;
        }
    }


}
