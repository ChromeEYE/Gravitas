using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    //LineRendererオブジェクトを設定する。
    public GameObject lineObject;

    //射程
    public float range = 20;

    //線の太さ
    public float width = 2;

    //銃口
    public Transform muzzle;

    //LineRendererコンポーネントの参照を入手
    LineRenderer lineRenderer;

    //Raycastの衝突情報を取得する。
    RaycastHit hit;

    void Start()
    {
        //LineRendererオブジェクトを作成し、lineRendererを取得
        GameObject l = Instantiate(lineObject, muzzle.position, Quaternion.identity) as GameObject;

        lineRenderer = l.GetComponent<LineRenderer>();

        //LinRendererを設定する。
    }

    void Update()
    {
        SetLaser();
        HitRaycast();
    }

    //LineRendererの位置を更新する処理
    void SetLaser()
    {

        //始点
        Vector3 start;
        //始点を設定
        start = muzzle.position;

        lineRenderer.SetPosition(0, start);

        //終点
        Vector3 end;
        //終点を設定する（終点は始点からmuzzuleの前方向にrange分伸ばした先に設定される）
        end = start + (muzzle.forward * range);

        //終点を設定する
        lineRenderer.SetPosition(1, end);
    }


    //Raycastによるレーザーの衝突処理
    void HitRaycast()
    {

        //Raycastを銃口の位置から前方へrange分だけ飛ばす
        //out修飾子はC#の特別なもので、引数で渡すと、コチラの関数内でも利用できるようになります。(完全には理解してません…スミマセン)
        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, range))
        {

            //Raycastで何かヒットしたら実行される。
            if (hit.transform.tag == "Enemy")
            {

                //Enemyタグの時のみ実行される。
                //Enemyタグを持つオブジェクトにDamage関数を実行する。
                hit.transform.SendMessage("Damage");
            }
        }
    }
}
