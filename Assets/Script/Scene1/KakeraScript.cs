using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakeraScript : MonoBehaviour
{
    [SerializeField]
    float Rotatospeed = 20f;
    [SerializeField]
    float UpDownSpeed = 1f;
    [SerializeField]
    float UpDownRange = 1f;
    float nowPosi;

    bool isGet; // 獲得済みフラグ
    [SerializeField]
    Vector3 startScale; // もとの大きさ
    [SerializeField]
    Vector3 endScale; //最終的な大きさ
    [SerializeField]
    float SizeDuration = 3f; // 変化にかかる時間

    // 目的地の座標
    [SerializeField]
    Vector3 targetPosition;
    // 移動時間（秒）
    [SerializeField]
    float moveTime;
    // 移動中かどうか
    private bool moving = false;
    // 移動開始時の座標
    [SerializeField]
    private Vector3 startPosition;
    // 移動開始時の時間
    private float startTime;
    // 会話メッセージ
    [SerializeField]
    string[] sentences;

    GameObject TalkObject;
    GameObject ChickPlayer;

    // Start is called before the first frame update
    void Start()
    {
        nowPosi = this.transform.position.y;
        TalkObject = GameObject.Find("TalkController");
        ChickPlayer = GameObject.Find("Chick");
    }

    // Update is called once per frame
    void Update()
    {
        // 回転させる
        transform.Rotate(Vector3.up * Rotatospeed * Time.deltaTime, Space.World);

        // PingPong関数で往復した値を計算する
        float y = Mathf.PingPong(Time.time * UpDownSpeed, UpDownRange);
        // オブジェクトの y座標に反映させる
        transform.position = new Vector3(transform.position.x, nowPosi + y, transform.position.z);

        // 獲得後
        if (isGet)
        {
            StartCoroutine(ScaleUpAndDown());
        }

        // 移動中なら
        if (moving)
        {
            // 経過時間の割合を計算
            float ratio = (Time.time - startTime) / moveTime;
            // 割合が1以上なら
            if (ratio >= 1f)
            {
                // 目的地に到着
                transform.position = targetPosition;
                // 移動中フラグを下ろす
                moving = false;
            }
            else
            {
                // 目的地に向かって移動
                transform.position = Vector3.Lerp(startPosition, targetPosition, ratio);
            }
        }
}
    IEnumerator ScaleUpAndDown()
    {
        while (true)
        {
            yield return ScaleObjectTo(startScale, endScale, SizeDuration); // 徐々に大きくする
        }
    }

    IEnumerator ScaleObjectTo(Vector3 fromScale, Vector3 toScale, float time)
    {
        float timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(fromScale, toScale, timer / time); //線形補間でスケールを変化させる。
            yield return null;
        }
        Destroy(this.gameObject);
        transform.localScale = toScale; //最終的なスケールに設定する。
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーが接触で獲得判定
        if (!isGet && other.CompareTag("Player"))
        {
            isGet = true;
            // かけらを上にホイップさせる
            transform.position += Vector3.up * 1.5f;
            bool getScore = false;
            if (getScore == false)
            {
                // かけらの数を増やす処理を記載
            }

            // 移動中でなければ
            if (!moving)
            {
                // 移動開始時の座標と時間を記録
                startPosition = transform.position;
                startTime = Time.time;
                // 移動中フラグを立てる
                moving = true;
            }

            TalkObject.GetComponent<TalkScript>().TalkStart(sentences);
        }
    }
}
