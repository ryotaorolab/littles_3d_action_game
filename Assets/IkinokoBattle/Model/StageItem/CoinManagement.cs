using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagement : MonoBehaviour
{
    // コイン獲得枚数を管理する変数
    private int coinCount = 0;

    // コインの枚数を表示するText
    public Text coinText;

    private void Start()
    {
        coinText.text = "Coins: " + coinCount;
    }
    public void AddCoin()
    {
        // コイン獲得枚数を1増やす
        coinCount++;

        // コインの枚数を表示するTextにコイン獲得枚数を反映させる
        coinText.text = "Coins: " + coinCount;
    }
}
