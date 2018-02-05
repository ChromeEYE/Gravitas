using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    Vector3 pos;

    //カメラとマウスのposition
    Vector3 nowpos;
    Vector2 mouse;
    float distance;

    //球の中心となるオブジェクト
    public Transform player;

    //カメラ移動のスピード
    public float speed;

    Player clas;

    RaycastHit hit;

    // Use this for initialization
    void Start ()
    {
        nowpos = transform.localPosition;
        distance = Vector3.Distance(player.position, transform.position);
        clas = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        pos = player.position - transform.position;
        //マウスの移動を取得 
        mouse -= new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * Time.deltaTime * speed;
        // マウスのY座標移動を制限
        mouse.y = Mathf.Clamp(mouse.y, -0.3f + 0.4f, 0.3f + 0.5f);

        // 球座標を演算
        pos.x = Mathf.Sin(mouse.y * Mathf.PI) * Mathf.Cos(mouse.x * Mathf.PI);
        pos.y = Mathf.Cos(mouse.y * Mathf.PI);
        pos.z = Mathf.Sin(mouse.y * Mathf.PI) * Mathf.Sin(mouse.x * Mathf.PI);
        // r and upper
        pos *= nowpos.z;

        pos.y += nowpos.y;
        //pos.x += nowPos.x; // if u need a formula,pls remove comment tag.

        transform.localPosition = pos;
        transform.LookAt(player.position, clas.nomale);
        // カメラの座標はワールドの始点を基準とする 

        Debug.Log(pos);
    }
}
