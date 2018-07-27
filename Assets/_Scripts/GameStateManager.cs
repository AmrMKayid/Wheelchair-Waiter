using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{

    public GameObject textField;
    public GameObject redTableSnapZone;
    public GameObject greenTableSnapZone;
    public static int score = 0;
    public static int lifes = 10;

    public void RedSnapHandler()
    {
        StartCoroutine(SnapHandler(redTableSnapZone));
    }

    public void GreenSnapHandler()
    {
        StartCoroutine(SnapHandler(greenTableSnapZone));
    }

    private IEnumerator SnapHandler(GameObject snapZone)
    {
        // play sound
        score += 1;
        textField.GetComponent<Text>().text = GetScoreText(score, lifes);
        Debug.Log("Scored " + score);
        yield return new WaitForSeconds(1);
        if (snapZone != null)
            Destroy(snapZone.GetComponentInChildren<FlyingFood>().gameObject);
    }

    public void LooseALife()
    {
        lifes -= 1;
        textField.GetComponent<Text>().text = GetScoreText(score, lifes);
        Debug.Log("Life lost " + lifes);
        if (lifes <= 0)
        {
            OnNoLifesLeft();
        }
    }

    private void OnNoLifesLeft()
    {
        Debug.Log("Game Over - Start Accident");
        //Get ready for next scene
        lifes = 10;
    }


    private string GetScoreText(int score, int lifes)
    {
        return "Score: " + score + "    " + "Lives: " + lifes;
    }

    private void Start()
    {
        textField.GetComponent<Text>().text = GetScoreText(score, lifes);
    }

}
