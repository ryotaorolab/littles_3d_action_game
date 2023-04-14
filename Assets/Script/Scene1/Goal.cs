using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameObject ClearUI, StageProgressController;
    GameObject ChickPlayer;
    [SerializeField]
    int NowStageNum,NextStageNum;

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
            ChickPlayer.GetComponent<PlayerScript>().ClearStateMove = true;
            if(NowStageNum >= PlayerPrefs.GetInt("STAGEPROGRESS", 0))
            {
                StageProgressController.GetComponent<StageProgress>().OnNextStage(NextStageNum);
            }
        }
    }
}
