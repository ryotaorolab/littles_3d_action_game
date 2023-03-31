using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameObject ClearUI;
    GameObject ChickPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // クリア表示を非表示にする。
        ClearUI.SetActive(false);
        ChickPlayer = GameObject.Find("Chick");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Chick")
        {
            ClearUI.SetActive(true);
            // プレイヤーの動きを一時的に止める
            ChickPlayer.GetComponent<PlayerScript>().StateMove = true;
        }
    }
}
