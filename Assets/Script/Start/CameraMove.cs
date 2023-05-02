using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 1f;
    public float duration = 5f;

    private float timer = 0f;

    public float Rotatespeed = 0.1f; // 回転速度
    public float Rotateduration = 4f; // 回転時間
    public Transform Rotatetarget;
    private float Rotatetimer = 0f; // タイマー

    // Start is called before the first frame update
    void Start()
    {
        // 目標の回転を初期化する
        // targetRot = transform.rotation;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (timer < duration)
        {
            transform.position -= transform.forward * speed * Time.deltaTime; // カメラを前方向に逆に移動させる
            timer += Time.deltaTime; // タイマーを更新する
        }

        if (Rotatetimer < duration) // 回転時間内なら
        {
            Quaternion currentRot = transform.rotation; // 現在の回転
            Quaternion targetRot = Quaternion.LookRotation(Rotatetarget.position - transform.position); // 目標の回転
            transform.rotation = Quaternion.Slerp(currentRot, targetRot, Rotatespeed); // 現在の回転と目標の回転の間を球面線形補間する
            Rotatetimer += Time.deltaTime; // タイマーを更新する
        }
    }

}
