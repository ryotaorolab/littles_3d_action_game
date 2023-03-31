using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private float x;
    private float z;
    [SerializeField]
    int upForce;
    public float Speed = 1.0f;
    float smooth = 10f;
    private Rigidbody rb;
    private Animator animator;
    [SerializeField]
    private bool isGround;
    [SerializeField]
    float gravityPower; //調整必要　例 - 1000
    private Animator anim;  //Animatorをanimという変数で定義する
    public bool StateMove = false; // プレイヤーをtrueのときに一時的に動けなくする


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        isGround = false;
        // 変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!StateMove)
        {
            // x,z 平面での移動
            
            // PC対応のときはこれをコメントアウト解除する
            // スマホ対応のときはこれをコメントアウトするように。
            x = Input.GetAxisRaw("Horizontal");

            // z = Input.GetAxisRaw("Vertical");

            Vector3 target_dir = new Vector3(x, 0, Input.GetAxis("Vertical"));
            rb.velocity = new Vector3(x, -1, z) * Speed; //歩く速度

            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            if (target_dir.magnitude > 0.1)
            {
                //キーを押し方向転換
                Quaternion rotation = Quaternion.LookRotation(target_dir);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smooth);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                rb.AddForce(transform.up * upForce, ForceMode.Impulse);
                Debug.Log("ジャンプした。");
            }

            bool LRPush = false; // 右左のボタンが押されているとき、前に進むのをやめるフラグ

            // 前進し続ける。左右キーが押されるまで
            if (!LRPush)
            {
                Quaternion rotation = Quaternion.LookRotation(target_dir);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smooth);
                animator.SetBool("Walk", true);
                z = 1;
            }

            // 左右のキーが押されているとき
            if (!(x == 0))
            {
                LRPush = true;
                z = 0;
            }

            // スマホ操作用のボタン向けコード
            // Lボタンが押されたとき右に移動する
            if (OnLbutton)
            {
                x = -1;
            }
            if (OnRbutton)
            {
                x = 1;
            }
            // 離したとき
            if (!OnLbutton && !OnRbutton)
            {
                x = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        Gravity();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Plain")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Plain")
        {
            isGround = false;
        }
    }
    void Gravity()
    {
        if (isGround == false)
        {
            rb.AddForce(new Vector3(0, gravityPower, 0));
        }
    }

    // スマホのボタン操作用関数
    bool OnLbutton = false;
    // Lボタンを押したとき(右に行くようにする)
    public void OnPushButtonL()
    {
        OnLbutton = true;
    }
    // Lボタンを離したとき
    public void OndisengageButtonL()
    {
        OnLbutton = false;
    }
    bool OnRbutton = false;
    // Rボタンを押したとき(左に行くようにする)
    public void OnPushButtonR()
    {
        OnRbutton = true;
    }
    // Rボタンを離したとき
    public void OndisengageButtonR()
    {
        OnRbutton = false;
    }
}
