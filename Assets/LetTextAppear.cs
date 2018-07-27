using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetTextAppear : MonoBehaviour {

	private string str;
		
	// Update is called once per frame
	void Update () {

	}
	
	void Start(){
		
		//Debug.Log("Using TextMesh " + text.ToString());
		StartCoroutine(AnimateText("Going home after a long yet fruitful day at work, little did you know that your life is going to change forever!..."));
	}

	IEnumerator AnimateText(string strComplete){
    	Text text = GetComponent<Text>();
    	int i = 0;
    	str = "";
    	while( i < strComplete.Length ){
        	str += strComplete[i++];
        	Debug.Log("String: " + str);
        	text.text = str;
        	yield return new WaitForSeconds(0.05F);
   		}

		yield return new WaitForSeconds(0.05F);
		GetComponent<AudioSource>().Play();

		yield return new WaitForSeconds(3F);
		SceneManager.LoadScene("FinalWithTables");
	}
}