using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIs : MonoBehaviour
{
    //スクリプト類
    Player main;
    GameClear clear;
    GameOver death;
    Pauser pose;
    BossHP boss;

    int cursor;

    int HP;
    int Fuel;

    //数字スプライト配列.
    public Sprite[] numbers=new Sprite[10];
    //hpスプライト表示部分配列.
    public SpriteRenderer[] hpRend = new SpriteRenderer[3];
    //推進剤スプライト表示部分配列
    public SpriteRenderer[] fuelRend = new SpriteRenderer[3];
    //レティクルその他
    public SpriteRenderer[] retical = new SpriteRenderer[5];
    //α値操作用変数
    Color color = new Color(0, 0, 0, 1);

    //リザルト画面の表示
    public Image panel;//new
    public Text[] ClearOver = new Text[2];
    public Text[] resultTx = new Text[4];
    public Button[] resultBt = new Button[4];

    float time;

    // Use this for initialization
    void Start()
    {
        //スクリプトの読み込み
        main = FindObjectOfType<Player>();
        clear = GetComponent<GameClear>();
        death = GetComponent<GameOver>();
        pose = GetComponent<Pauser>();
        boss = FindObjectOfType<BossHP>();

        cursor = 0;
        Time.timeScale = 1;//new

        //ボタン類の透明化
        for (int i = 0; i < ClearOver.Length; i++)
        {
            ClearOver[i].color -= new Color(0, 0, 0, 1);
        }
        for (int i = 0; i < resultTx.Length; i++)
        {
            resultTx[i].color -= new Color(0, 0, 0, 1);
        }
        for (int i = 0; i < resultTx.Length; i++) 
        {
            resultBt[i].enabled = false;
        }

        //UIの初期化
        for (int i = 0; i < hpRend.Length; i++)
        {
            hpRend[i].color = new Color(1, 1, 1, 1);
        }
        for (int i = 0; i < fuelRend.Length; i++)
        {
            fuelRend[i].color = new Color(1, 1, 1, 1);
        }
        for (int i = 0; i < retical.Length; i++)
        {
            retical[i].color = new Color(1, 1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HP = (int)main.hp;
        Fuel = (int)main.fuel;

        if (cursor == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (cursor == 1)  
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (HP > 0)
        {
            //体力を表記
            hpRend[0].sprite = numbers[HP / 100 % 10];
            /*if (hpRend[0].sprite == numbers[0])
            {
                hpRend[0].color -= color;
            }
            else
            {
                hpRend[0].color += color;
            }*/
            hpRend[1].sprite = numbers[HP / 10 % 10];
            hpRend[2].sprite = numbers[HP / 1 % 10];

            //推進剤を表記
            fuelRend[0].sprite = numbers[Fuel / 100 % 10];
            /*if (fuelRend[0].sprite == numbers[0])
            {
                fuelRend[0].color -= color;
            }
            else
            {
                fuelRend[0].color += color;
            }*/
            fuelRend[1].sprite = numbers[(Fuel / 10) % 10];
            fuelRend[2].sprite = numbers[(Fuel / 1) % 10];
        }
        else
        {
            cursor++;
            UIoff();
            if (time > 5)
            {
                death.enabled = true;
            }
        }

        if (boss.life <= 0)//new
        {
            cursor++;
            UIoff();
            if (time > 5)
            {
                clear.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && cursor == 0)
        {
            cursor++;
            Time.timeScale = 0;//new
            panel.color += new Color(-1, -1, -1, 0.5f);
            for (int i = 2; i < resultTx.Length; i++)
            {
                resultTx[i].color += new Color(0, 0, 0, 1);
            }
            for (int i = 2; i < resultBt.Length; i++)
            {
                resultBt[i].enabled = true;
            }
            pose.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && cursor == 1)
        {
            cursor--;
            Time.timeScale = 1;//new
            panel.color -= new Color(-1, -1, -1, 0.5f);
            for (int i = 2; i < resultTx.Length; i++)
            {
                resultTx[i].color -= new Color(0, 0, 0, 1);
            }
            for (int i = 4; i < resultBt.Length; i++)
            {
                resultBt[i].enabled = false;
            }
            pose.enabled = false;
        }

    }

    void UIoff()
    {
        time += Time.deltaTime;
        for (int i = 0; i < hpRend.Length; i++)
        {
            hpRend[i].color = new Color(0, 0, 0, 0);
        }
        for (int i = 0; i < fuelRend.Length; i++)
        {
            fuelRend[i].color = new Color(0, 0, 0, 0);
        }
        for (int i = 0; i < retical.Length; i++)
        {
            retical[i].color = new Color(0, 0, 0, 0);
        }
    }
}
