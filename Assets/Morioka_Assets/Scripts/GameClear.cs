using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    GameObject whitePanel;
    Image whiteImage;
    public Text Clear;
    public Text[] text = new Text[2];
    public Button[] button = new Button[2];

    // Use this for initialization
    void Start ()
    {
        whitePanel = GameObject.Find("Panel");
        whiteImage = whitePanel.GetComponent<Image>();
        whiteImage.color = new Color(1, 1, 1, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        whiteImage.color += new Color(0, 0, 0, 0.05f);
        Clear.color += new Color(0, 0, 0, 0.05f);
        if (whiteImage.color.a >= 0.9f)
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
