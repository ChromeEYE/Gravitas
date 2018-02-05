using UnityEngine;
using System.Collections;

public class JetParticlePoint : MonoBehaviour
{
    public GameObject particlePrefab;
    public GameObject p;

    /// <summary>
    /// パーティクルを生成する.
    /// </summary>
    public void On()
    {
        //パーティクルが生成されていなかったら生成.
        if (!p)
        {
            //ジェットパーティクルを生成する.
            p = Instantiate(particlePrefab, transform.position, transform.rotation);
            //ジェットパーティクルを自身の子供にする.
            p.transform.parent = this.transform;
        }
    }

    /// <summary>
    /// パーティクルを削除する.
    /// </summary>
    public void Off()
    {
        Destroy(p.gameObject);
    }
}
