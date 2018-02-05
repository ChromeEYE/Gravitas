using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //プレイヤーを引きよせる
    public string activeTag;
    public string activeEnemy;
    public string activeU;
    public string activeBullet;

    Vector3 mydirection;

    void OnTriggerStay(Collider other)
    {
        //コライダに触れているオブジェクトをrigitbodyコンポーネントで取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールがどの方向にあるかを計算する
        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

        //タグに応じてプレイヤーに力を加える
        if (other.gameObject.tag == activeTag)
        {
            r.velocity *= 0.985f;
            r.AddForce(direction * r.mass * 9.81f);
        }
        if(other.gameObject.tag == activeU)
        {
            r.AddForce(-direction * r.mass * 80.0f);
        }
        if (other.gameObject.tag == activeEnemy)
        {
            r.velocity *= 0.9f;
            r.AddForce(direction * r.mass * 50.0f);
        }
        if(other.gameObject.tag == activeBullet)
        {
            r.AddForce(direction * r.mass * 10.0f);
        }

    }
}