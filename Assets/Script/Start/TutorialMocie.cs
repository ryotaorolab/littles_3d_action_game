using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMocie : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("StartAnimation", 4f);
    }

    void StartAnimation()
    {
        rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        Invoke("Animation2", 3f);
    }

    void Animation2()
    {
        rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        Invoke("Animation3", 3f);
    }
    void Animation3()
    {
        rb.AddForce(Vector3.up * 30, ForceMode.Impulse);
        Invoke("Animation4", 3f);
    }
    void Animation4()
    {
        rb.AddForce(Vector3.up * 40, ForceMode.Impulse);
        Invoke("JumpCurves", 3f);
    }
    GameObject StartObject;
    GameObject EndObject;
    void JumpCurves()
    {
        JumpCurvesSwitch = true;
        StartObject = GameObject.Find("Start");
        start = StartObject.GetComponent<Transform>();
        EndObject = GameObject.Find("End");
        end = EndObject.GetComponent<Transform>();
        // 重力を無効化
        rb.isKinematic = true;
    }

    // 開始位置
    Transform start;
    // 終了位置
    Transform end;
    // 秒単位の移動時間
    public float duration = 4f;
    // 0 から 1 への移動の進行状況
    private float t = 0f;

    bool JumpCurvesSwitch;

    void Update()
    {
        if(JumpCurvesSwitch == true)
        {
            // 進行状況を時間 / 期間で増やす
            t += Time.deltaTime / duration;
            // 進行状況を [0, 1] の範囲に固定する
            t = Mathf.Clamp01(t);
            // 開始位置と終了位置と方向を使用して、ベジエ曲線上の位置を計算します
            Vector3 position = GetPointOnBezierCurve(start.position, start.forward, end.position, -end.forward, t);
            // オブジェクトを計算された位置に移動
            transform.position = position;
            // 進行度が 1 になったら、移動を停止します
            if (t == 1f)
            {
                Invoke("ChangeScene", 1.5f);
                // enabled = false;
            }
        }

        // 2 つの位置と方向、およびパラメーター t を指定して、ベジエ曲線上の点を取得するヘルパー関数
        Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            float u = 1f - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;
            Vector3 result =
                uuu * p0 +
                3f * uu * t * (p0 + p1) +
                3f * u * tt * (p2 + p1) +
                ttt * p2;
            return result;
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Scene1");
    }
}
