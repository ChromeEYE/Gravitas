using UnityEngine;
using System.Collections;

public class JakutenAxis : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(10*Time.time, Vector3.up);
    }
}
