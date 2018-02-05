using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    Player script;

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        script = FindObjectOfType<Player>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && script.hp > 0) 
        {
            //hpやfuelが100未満なら回復
            if (script.hp < 100) 
            script.hp += 0.5f;
            if (script.fuel < 100) 
            script.fuel += 0.5f;
        }
    }
}
