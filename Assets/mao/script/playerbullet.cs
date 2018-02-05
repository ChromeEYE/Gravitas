using UnityEngine;
using System.Collections;

public class playerbullet : MonoBehaviour
{
    GameObject muzzle;
    GameObject player;//new
    Rigidbody bulletrb;
    public float bulletpower;
    Vector3 direction;
    GameObject world;//new

	// Use this for initialization
	void Start ()
    {
        muzzle = GameObject.Find("muzzle");
        player = GameObject.Find("Player");//new
        world = GameObject.Find("Pausable");//new
        //this.gameObject.transform.parent = world.transform;//new
        transform.position = muzzle.transform.position;transform.forward = muzzle.transform.forward;        
        bulletrb = GetComponent<Rigidbody>();
        bulletrb.AddForce(player.GetComponent<Rigidbody>().velocity + transform.forward * bulletpower);//new
    }
	
	// Update is called once per frame
	void Update ()
    {
        float range = Vector3.Distance(transform.position, muzzle.transform.position);
        if(range>=10000)
        {
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "LastBoss")
        {
            other.gameObject.GetComponent<BossHP>().BHP();

        }
        if(other.gameObject.tag == "cyuBoss")
        {
            other.gameObject.GetComponent<cyuBossHP>().CHP();
        }
        Destroy(this.gameObject);
    }

    void OnTrrigerStay(Collider other)
    {
        direction = other.transform.position - transform.position;
        direction.Normalize();
        bulletrb.AddForce(direction * bulletrb.mass * 9.81f);
    }
}
