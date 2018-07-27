using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using VRTK;
public class FlyingFood : MonoBehaviour
{

    public Material RedMaterial;
    public Material BlueMaterial;
    public Material GreenMaterial;

    private Rigidbody rbody;
    private static float maxSpeed = 7;// limit the speed of the plate falling down


    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (rbody.velocity.y < 0 && rbody.velocity.magnitude > maxSpeed)
        {
            rbody.velocity = rbody.velocity.normalized * maxSpeed;
        }
        if (transform.position.y < -25)
        {
            Debug.Log("Position destroy");
            OnCollisionWithFloor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("floorTag"))
        {
            //Debug.Log("Collision destroy");
            OnCollisionWithFloor();
        }
    }

    private void OnCollisionWithFloor()
    {
        // play sound
        GetComponent<AudioSource>().Play();
        GetComponent<VRTK.VRTK_InteractableObject>().isUsable = false;

        // decrease life left

        // remove plate
        //StartCoroutine(DeleteAfterSound());
    }


    private IEnumerator DeleteAfterSound()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    public delegate void SnapDropZoneEventHandler(Object o, SnapDropZoneEventArgs args);



    public void ApplyForce(Vector3 forceVector)
    {
        GetComponent<Rigidbody>().AddForce(forceVector);
    }

    public void SetTableColor(FoodColorEnum tableColor)
    {
        switch (tableColor)
        {
            case FoodColorEnum.red:
                gameObject.tag = "PlateRedTag";
                GetComponent<MeshRenderer>().material = RedMaterial;
                break;
            case FoodColorEnum.green:
                gameObject.tag = "PlateGreenTag";
                GetComponent<MeshRenderer>().material = GreenMaterial;
                break;
            case FoodColorEnum.blue:
                gameObject.tag = "PlateBlueTag";
                GetComponent<MeshRenderer>().material = BlueMaterial;
                break;
        }
    }


}
