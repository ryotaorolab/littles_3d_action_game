using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Chick")
        {
            // 最初にボタンを連打して抜け出すシーンに用いるひよこの群れとダストボックスを削除する。
            GameObject ChickChildren;
            ChickChildren = GameObject.Find("ChickChildren");
            GameObject DuckBox;
            DuckBox = GameObject.Find("DuckBox");
            Destroy(ChickChildren);
            Destroy(DuckBox);

            // プレイヤーを削除する
            Destroy(collision.gameObject);

            // プレハブを読み込む
            GameObject DuckBox2 = Resources.Load("Prefabs/Start/DuckBox") as GameObject;
            GameObject ChickChildren2 = Resources.Load("Prefabs/Start/ChickChildren") as GameObject;
            // インスタンス化する
            GameObject DuckBox2Instance = Instantiate(DuckBox2);
            GameObject ChickChildren2Instance = Instantiate(ChickChildren2);

            // カメラを後ろ方向に移動させる
            GameObject Camera = GameObject.Find("Main Camera");
            CameraMove cameraMove = Camera.GetComponent<CameraMove>();
            // Camera Moveスクリプトを有効化する
            cameraMove.enabled = true;

            // アニメーションの鶏のスクリプトを有効化させる
            // ボスチック
            GameObject BossChick = GameObject.Find("BossChick");
            TutorialMocie tutorialMocie = BossChick.GetComponent<TutorialMocie>();
            tutorialMocie.enabled = true;
            // SceneManager.LoadScene("Scene1");
        }
    }
}
