using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseOut : MonoBehaviour {

    public GameObject cyuiImageObject;
    TimeScript script;

	// Use this for initialization
	void Start () {
        script = FindObjectOfType<TimeScript>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            script.CountDown();
            script.enabled = false;
            cyuiImageObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            cyuiImageObject.SetActive(true);
            script.enabled = true;
        }
    }
}
