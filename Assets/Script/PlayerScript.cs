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
        // x,z 平面での移動
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 target_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = new Vector3(x, -1, z) * Speed; //歩く速度


        // animator.SetFloat("Walk", rb.velocity.magnitude); //歩くアニメーションに切り替える
        if(Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) {
            animator.SetBool("Walk", true);
        } else
        {
            animator.SetBool("Walk", false);
        }
        if(target_dir.magnitude > 0.1)
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

}
