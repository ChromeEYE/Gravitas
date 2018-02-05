using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camtarget : MonoBehaviour
{
    public Transform target;
    public Transform deathTarget;
    Player targetScript;

	// Use this for initialization
	void Start ()
    {
        targetScript = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (targetScript.hp > 0) 
        {
            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;
        }
        else
        {
            transform.position = transform.position;
            transform.LookAt(deathTarget);
        }
	}
}
