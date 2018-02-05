using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockOn : MonoBehaviour
{
    //ターゲットとそのrigidbody
    public GameObject target;
    Rigidbody targetRb;

    //ターゲットの距離と方向
    Vector3 heading;

    //Speed per Second（距離までの時間）
    float SpD;

    //色々（投げやり）
    Vector3 Rock;
    Vector3 RockOnPos;
    Transform muzzul;
    public GameObject tama;

	// Use this for initialization
	void Start ()
    {
        //弾のスクリプトとターゲットのrigidbodyをインスタンス化
        //script=FindObjectOfType<Ebullet>();
        targetRb = target.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //距離と方向をpositionの差を求め、弾速を距離で割り、ターゲットの移動速度をSpDで割ってその値をターゲットのpositionに足す
        heading = target.transform.position - transform.position;
        SpD = 100 / heading.magnitude;
        Rock = targetRb.velocity / SpD;
        RockOnPos = target.transform.position + Rock;

        transform.LookAt(RockOnPos);

        //Instantiate(tama);
	}
}
