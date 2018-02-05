using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyuBossHP : MonoBehaviour
 {
    public GameObject explosionPrefab;
    public GameObject Pos;
    public int life = 10;

    void Start () {
		
	}
    public void CHP()
    {
        life--;
        if (life == 0)
        {
            Instantiate(explosionPrefab, Pos.transform.position, Quaternion.identity);
            Destroy(Pos);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
