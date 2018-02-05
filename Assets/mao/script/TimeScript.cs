using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScript : MonoBehaviour
{
    public float time = 11;
    public float MaxTime = 11;
    public GameObject cyuiImageObject;
    Player playerscript;

    void Start()
    {
        playerscript = FindObjectOfType<Player>();
        //float型からint型へ、String型に変換して表示
        GetComponent<Text>().text = ((int)time).ToString();
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            playerscript.TimeOver();
            time = 0;
            cyuiImageObject.SetActive(false);
        }
        GetComponent<Text>().text = ((int)time).ToString();

    }

    public void CountDown()
    {
        time = MaxTime;
    }
}