using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetTextAppear : MonoBehaviour
{


    public AudioClip message;
    public AudioClip carSmash;
    private  AudioSource audioSource;

    // Update is called once per frame
    private bool entered = false;
    void Update () {
        if(!audioSource.isPlaying && !entered)
        {
            entered = true;
            audioSource.clip = carSmash;
            audioSource.Play();
            SceneManager.LoadScene("Level 2");

        }
    }
	
	void Start()
	{
	    audioSource = gameObject.GetComponent<AudioSource>();
	    audioSource.clip = message;
        audioSource.Play();
	   
	    
    }
    
}