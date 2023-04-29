using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    Rigidbody rigidbody;
    [SerializeField, Min(0)]
    float jumpPower = 5f;
    [SerializeField]
    AnimationCurve jumpCurve = new();
    [SerializeField, Min(0)]
    float maxJumpTime = 1f;
    [SerializeField]
    float groundCheckRadius = 0.4f;
    [SerializeField]
    float groundCheckOffsetY = 0.45f;
    [SerializeField]
    float groundCheckDistance = 0.2f;
    [SerializeField]
    LayerMask groundLayers = 0;
    [SerializeField]
    string JumpButtonName = "Jump";

    bool isGrounded = false;
    bool jumping = false;
    float jumpTime = 0;
    RaycastHit hit;
    Transform thisTransform;

    void Start()
    {
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckGroundStatus();

        // ジャンプの開始判定
        if (isGrounded && Input.GetButton(JumpButtonName))
        {
            jumping = true;
        }

        // ジャンプ中の処理
        if (jumping)
        {
            //if (Input.GetButtonUp(JumpButtonName) || jumpTime >= maxJumpTime)
            //{
            //    jumping = false;
            //    jumpTime = 0;
            //}
            //else if (Input.GetButton(JumpButtonName))
            //{
            //    jumpTime += Time.deltaTime;
            //}
            if (jumpTime >= maxJumpTime)
            {
                jumping = false;
                jumpTime = 0;
            }
            jumpTime += Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if (!jumping)
        {
            return;
        }

        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);

        // ジャンプの速度をアニメーションカーブから取得
        float t = jumpTime / maxJumpTime;
        float power = jumpPower * jumpCurve.Evaluate(t);

        if (t >= 1)
        {
            jumping = false;
            jumpTime = 0;
        }

        rigidbody.AddForce(power * Vector3.up, ForceMode.Impulse);
    }

    // 接地判定
    bool CheckGroundStatus()
    {
        return Physics.SphereCast(thisTransform.position + groundCheckOffsetY * Vector3.up, groundCheckRadius, Vector3.down, out hit, groundCheckDistance, groundLayers, QueryTriggerInteraction.Ignore);
    }
    public void OnJumpButton()
    {
        if(isGrounded)
        {
            jumping = true;
        }
    }
}
