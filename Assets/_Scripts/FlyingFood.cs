using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFood : MonoBehaviour
{

    public Material RedMaterial;
    public Material BlueMaterial;
    public Material GreenMaterial;

    private Rigidbody rbody;
    private static float maxSpeed = 7;// limit the speed of the plate falling down
    private FoodColorEnum tableColor;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rbody.velocity.y < 0 && rbody.velocity.magnitude > maxSpeed)
        {
            Debug.Log("lowering falling speed");
            rbody.velocity = rbody.velocity.normalized * maxSpeed;
        }
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
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        switch (tableColor)
        {
            case FoodColorEnum.red:
                renderer.material = RedMaterial;
                break;
            case FoodColorEnum.green:
                renderer.material = GreenMaterial;
                break;
            case FoodColorEnum.blue:
                renderer.material = BlueMaterial;
                break;
        }
    }


}
