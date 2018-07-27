using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{

    public GameObject textField;
    public GameObject redTableSnapZone;
    public GameObject greenTableSnapZone;
    private int score = 0;

    public void RedSnapHandler()
    {
        StartCoroutine(SnapHandler(redTableSnapZone));
    }

    public void GreenSnapHandler()
    {
        StartCoroutine(SnapHandler(greenTableSnapZone));
    }

    public IEnumerator SnapHandler(GameObject snapZone)
    {
        score++;
        textField.GetComponent<Text>().text = "Score : " + score;
        Debug.Log("Snapped");

        yield return new WaitForSeconds(1);
        Destroy(snapZone.GetComponentInChildren<FlyingFood>().gameObject);


    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
