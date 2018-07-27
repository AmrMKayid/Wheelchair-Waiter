using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carMoving : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("ASDFGADSG");
		SceneManager.LoadScene("FinalWithTables");
	}
}
