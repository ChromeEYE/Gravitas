using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform turret;
    public Transform muzzle;
    public GameObject bulletPrefab;

    private float attackInterval = 0.5f;//間隔
    private float lastAttackTime;


    //ターゲットとそのrigidbody
    public GameObject target;
    Rigidbody targetRb;

    //弾のスクリプト
    EnemyBullet script;

    //ターゲットの距離と方向
    Vector3 heading;

    //Speed per Second（距離までの時間）
    float SpD;

    //色々（投げやり）
    Vector3 Rock;
    Vector3 RockOnPos;
    Transform muzzul;

    private void Start()
    {
        target = GameObject.Find("Player");
        targetRb = target.GetComponent<Rigidbody>();
    }



    private void Update()
    {
        // 砲台をプレイヤーの方向に向け

        //距離と方向をpositionの差で求め、弾速を距離で割り、ターゲットの移動速度をSpDで割ってその値をターゲットのpositionに足す
        heading = target.transform.position - transform.position;
        SpD = 250 / heading.magnitude;
        Rock = targetRb.velocity / SpD;
        RockOnPos = target.transform.position + Rock;

        transform.LookAt(RockOnPos);

        // 一定間隔で弾丸を発射する
        if (Time.time > lastAttackTime + attackInterval)
        {
            Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            lastAttackTime = Time.time;
        }
    }

}