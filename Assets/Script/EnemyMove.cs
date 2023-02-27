using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    Vector3[] positions = new Vector3[1]; // 位置の配列の要素数

    [SerializeField]
    Vector3[] rotations = new Vector3[1]; // 回転の配列要素

    [SerializeField]
    float moveTime = 1.0f; // 移動にかかる時間を秒で設定
    float timer = 0.0f; // タイマーを初期化
    [SerializeField]
    int index = 0; // 配列のインデックスを初期化

    [SerializeField]
    bool LoopSwitch = false;

    void Start()
    {
        transform.position = positions[0]; // オブジェクトの位置を配列の最初の要素に設定
        transform.Rotate(rotations[0]); //オブジェクトの回転を配列の最初の要素に設定
        
        if (positions.Length != rotations.Length)
        {
            rotations = new Vector3[positions.Length]; // 要素数を配列positionsに合わせる
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index < positions.Length - 1) // 配列の最後の要素に到達するまで
        {
            timer += Time.deltaTime; // タイマーを更新
            float t = timer / moveTime; // 移動の割合を計算
            transform.position = Vector3.Lerp(positions[index], positions[index + 1], t); // オブジェクトの位置を補間
            if (t >= 1.0f) // 移動が完了したら
            {
                index++; // 配列のインデックスを増やす
                transform.Rotate(rotations[index], Space.World); // オブジェクトを配列に従って回転させる。
                timer = 0.0f; // タイマーをリセット
            }
        }

        if (index == positions.Length - 1) // 配列の要素が最後に達成した場合
        {
            if (LoopSwitch == true) // ループスイッチがオンの場合
            {
                transform.Rotate(rotations[index], Space.World); // オブジェクトを配列に従って回転させる。
                index = 0; // indexを0にしてループにする
            }
        }
    }
}
