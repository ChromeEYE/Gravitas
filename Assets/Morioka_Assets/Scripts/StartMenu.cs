using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    GameObject panel;
    Image image;
    float alpha;
    float scene;
    float quit;
    float cont;
    float title;


    void Start()
    {
        panel = GameObject.Find("Panel");
        image = panel.GetComponent<Image>();
    }

    void Update()
    {
        alpha = (scene + quit + cont + title) / 50;
        image.color += new Color(0, 0, 0, alpha);
        if (image.color.a > 1.00f && scene == 1)
        {
            SceneManager.LoadScene("main");
        }
        else if (image.color.a > 1.00f && quit == 1) 
        {
            Application.Quit();
        }
        else if (image.color.a > 1.00f && cont == 1)
        {
            Debug.Log("コンティニュー");
            SceneManager.LoadScene("main");
        }
        else if (image.color.a > 1.00f && title == 1)
        {
            SceneManager.LoadScene("Start");
        }
        //Debug.Log(cont);
        //Debug.Log(image.color.a);
        //Debug.Log(scene);
    }

    public void StartPush()
    {
        scene++;
        image.raycastTarget = true;
    }

    public void ExitPush()
    {
        quit++;
        image.raycastTarget = true;
    }

    public void PushContinue()
    {
        cont++;
        image.raycastTarget = true;
    }

    public void PushTitle()
    {
        title++;
        image.raycastTarget = true;
    }
}
