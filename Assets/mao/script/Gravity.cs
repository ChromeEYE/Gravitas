using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float gravity;

    Rigidbody rb;

    Vector3 direction;

    void OnTriggerStay(Collider other)
    {
        rb = other.gameObject.GetComponent<Rigidbody>();
        direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();
        rb.AddForce(direction * rb.mass * gravity);
    }
}
