using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    GameObject blackPanel;
    Image blackImg;
    float a = 0.05f;

	// Use this for initialization
	void Start ()
    {
        blackPanel = GameObject.Find("Panel");
        blackImg = blackPanel.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        blackImg.color -= new Color(0, 0, 0, a);
        if (blackImg.color.a <= 0)
        {
            this.enabled = false;
        }
	}
}
