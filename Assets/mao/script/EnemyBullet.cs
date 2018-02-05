using UnityEngine;
using System.Collections;


public class EnemyBullet : MonoBehaviour
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
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        startpos = transform.position;//new
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
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

    private void OnCollisionEnter(Collision collision)
    {
        /*
        Vector3 contactPoint = collision.contacts[0].point;

        if (collision.rigidbody != null)
        {
            collision.rigidbody.AddForce(transform.forward * force);
        }
        if (collision.gameObject.tag != "Bullet")
        {
            Instantiate(explosionPrefab, contactPoint, Quaternion.identity);
            Destroy(gameObject);
        }
        */
    }
}
