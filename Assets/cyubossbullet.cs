using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyubossbullet : MonoBehaviour
{
    public ParticleSystem explosionPrefab;
    public Transform player;    //プレイヤーを代入
    public float speed = 50f;
    private float force = 500f;
    Vector3 startpos;//new
    GameObject world;//new

    private void Start()
    {
        world = GameObject.Find("Pausable");//new
        //this.transform.parent = world.transform;//new
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startpos = transform.position;//new

    }

    void Update()
    {
        Vector3 playerPos = player.position;    //プレイヤーの位置
        Vector3 direction = playerPos - transform.position; //方向
        direction = direction.normalized;
        transform.position = transform.position + (direction * speed * Time.deltaTime);
        transform.LookAt(player);   //プレイヤーの方を向く
    }

    IEnumerator DDC()
    {
        yield return new WaitForSeconds(3f);

        enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bullet" && other.tag != "Zone")
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            //Debug.Log(other.tag);
        }
    }
}