using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Per : MonoBehaviour
{

    //プレイヤーシステム
    Player mainSystem;

    int HP;
    int Fuel;

    //数字スプライト配列.
    public Sprite[] numbers;
    //hpスプライト表示部分配列.
    public SpriteRenderer[] hpRend = new SpriteRenderer[3];
    //推進剤スプライト表示部分配列
    public SpriteRenderer[] fuelRend = new SpriteRenderer[3];
    //カラー保存
    Color hpColor;
    Color fuelColor;


	// Use this for initialization
	void Start ()
    {
        mainSystem = FindObjectOfType<Player>();
        hpColor = hpRend[0].color;
        fuelColor = fuelRend[0].color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        HP = (int)mainSystem.hp;
        Fuel = (int)mainSystem.fuel;

        //体力を表記
        if (HP == 100)  
        {
            hpRend[0].color = hpColor;
            hpRend[0].sprite = numbers[1];
            hpRend[1].sprite = numbers[0];
            hpRend[2].sprite = numbers[0];
        }
        else
        {
            hpRend[0].color = new Color(hpColor.r, hpColor.g, hpColor.b, 0);
            hpRend[1].sprite = numbers[(HP / 10) % 10];
            hpRend[2].sprite = numbers[(HP / 1) % 10];
        }

        //燃料を表記
        if (Fuel == 100) 
        {
            fuelRend[0].color = fuelColor;
            fuelRend[0].sprite = numbers[1];
            fuelRend[1].sprite = numbers[0];
            fuelRend[2].sprite = numbers[0];
        }
        else
        {
            fuelRend[0].color = new Color(fuelColor.r, fuelColor.g, fuelColor.b, 0);
            fuelRend[1].sprite = numbers[(Fuel / 10) % 10];
            fuelRend[2].sprite = numbers[(Fuel / 1) % 10];
        }
    }
}
