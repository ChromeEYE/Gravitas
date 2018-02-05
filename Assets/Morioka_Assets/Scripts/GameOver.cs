using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{ 
    GameObject DeathPanel;
    Image DeathImage;
    public Text Over;
    public Text[] text = new Text[2];
    public Button[] button = new Button[4];

    // Use this for initialization
    void Start ()
    {
        DeathPanel = GameObject.Find("Panel");
        DeathImage = DeathPanel.GetComponent<Image>();
        DeathImage.color = new Color(0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        DeathImage.color += new Color(0, 0, 0, 0.05f);
        Over.color += new Color(0, 0, 0, 0.05f);
        if (DeathImage.color.a >= 0.9f)
        {
            for (int i = 0; i < button.Length; i++)
            {
                button[i].enabled = true;
            }
            for (int i = 0; i < text.Length; i++)
            {
                text[i].color += new Color(0, 0, 0, 0.05f);
            }
        }
    }
}
