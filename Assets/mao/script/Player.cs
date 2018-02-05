using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    ////パーティクル発生装置への参照.
    public JetParticlePoint jetFront;
    public JetParticlePoint jetBack;
   
    
    //オーディオソースのコンポーネントを取得
    public AudioSource sound;
    //オーディオファイルを代入

    //ご存じrigidbody
    Rigidbody rb;

    //移動速度やらジャンプの力やら
    public float speed;
    float Vsp;
    float Hsp;
    public float jPower;

    //Axisの入力用変数
    float V;
    float H;

    //マウスの入力用変数
    float x;
    float y;
    public float mouseSpeed;
    float nowY;

    //衝突点の法線用変数
    public Vector3 nomale;

    //銃と弾
    public GameObject gun;
    public GameObject bullet;

    //ProjectOnPlane用変数
    Vector3 direction;

    //重力とかその他
    Vector3 heading;
    float distance;
    Vector3 gDirection;

    //脱出速度
    public float vesc;

    //接地用フラグ
    int groundedFlg;

    //体力と推進剤
    public float hp = 100;
    public float fuel = 100;
    public float damage;
    public float useFuel;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 0)
        {
            if (Time.timeScale == 1)
            {
                Cursor.lockState = CursorLockMode.Locked;
                //ＶとＨに仮想軸の入力を保存
                V = Input.GetAxis("Vertical");
                H = Input.GetAxis("Horizontal");

                //xとyにマウスの入力を保存　yはMathf.Clampで制限
                x = Input.GetAxis("Mouse X") * mouseSpeed;
                y -= Input.GetAxis("Mouse Y") * mouseSpeed;
                y = Mathf.Clamp(y, -90, 60);
                //Playerをマウスのx軸に合わせて回転
                transform.Rotate(0, x, 0);
                gun.transform.localRotation = Quaternion.Euler(new Vector3(y, 0, 0));

                if (groundedFlg == 0)
                {
                    //無重力下で上限値以上の上下回転をした場合ブースターを使用して変更できる
                    if (y >= 60 && fuel > 0)
                    {
                        fuel -= useFuel;
                        transform.Rotate(1, 0, 0);
                    }
                    else if (y <= -90 && fuel > 0)
                    {
                        fuel -= useFuel;
                        transform.Rotate(-1, 0, 0);
                    }

                    //ブースターで回転制動
                    if (Input.GetKey(KeyCode.F) && fuel > 0)
                    {
                        fuel -= useFuel;
                        rb.angularDrag = 1;
                    }
                }

                //左クリックで弾を生成
                if (Input.GetMouseButton(0))
                {
                    Instantiate(bullet);
                    sound.PlayOneShot(sound.clip);
                    if (groundedFlg == 0)
                        rb.AddForce(transform.forward * -1000);
                }

                if (Input.GetKey(KeyCode.F12))
                {
                    SceneManager.LoadScene("Start");
                }
                //ブースター噴射
                if (Input.GetKey(KeyCode.Q) && fuel > 0)//new
                {
                    if (fuel > 0)
                    {
                        jetBack.On();
                        fuel -= useFuel;
                        rb.AddForce(Camera.main.transform.forward * vesc * Time.deltaTime);
                    }
                    else
                    {
                        jetBack.Off();
                    }
                }
                else
                {
                    jetBack.Off();
                }
                //ブースター逆噴射
                if (Input.GetKey(KeyCode.E) && fuel > 0)//new
                {
                    //if (fuel > 0 && rb.velocity.magnitude >= 0.1f)
                    if (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0 || Mathf.Abs(rb.velocity.z) > 0)//new
                    {
                        jetFront.On();
                        fuel -= useFuel;
                        rb.AddForce(rb.velocity.normalized * -vesc * Time.deltaTime);

                    }
                    else
                    {
                        jetFront.Off();
                    }
                }
                else
                {
                    jetFront.Off();
                }
            }
        }
    }


    void OnCollisionStay(Collision other)//new
    {
        if (other.gameObject.tag == "planet")
        {
            groundedFlg = 1;
            //接地している場合は回転を制御する
            rb.freezeRotation = true;
            //衝突点の情報をcontactに保存する
            foreach (ContactPoint contact in other.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal * 100);

                //法線を取得
                nomale = contact.normal;

                //ProjectOnPlaneで球面に立つベクトルを演算、LookRotationで適用
                direction = Vector3.ProjectOnPlane(transform.forward, nomale);
                transform.rotation = Quaternion.LookRotation(direction, nomale);


                //仮想軸の入力から方向を指定して移動
                if (V > 0)
                {
                    Vsp = V * speed;
                }
                else if (V < 0)
                {
                    Vsp = V * speed;
                }

                if (H > 0)
                {
                    Hsp = H * speed;
                }
                else if (H < 0)
                {
                    Hsp = H * speed;
                }
                transform.Translate(Hsp, 0, Vsp, Space.Self);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= damage;
        }
    }

    public void TimeOver()
    {
        hp = 0;
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Bullet")
    //    {
    //        hp -= damage;

    //    }
    //}


    void OnCollisionExit(Collision other)
    {
        groundedFlg = 0;
        rb.freezeRotation = false;
    }
}
