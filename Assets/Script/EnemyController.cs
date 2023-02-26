using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyCube;
    [SerializeField]
    float timespeed;
    [SerializeField]
    float CurrentSize;

    [SerializeField]
    float Time_now = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool stopsize = false;
    bool stopsizesw = false;
    [SerializeField]
    float stilltime = 0; // 最大サイズ時の静止時間
    [SerializeField]
    float Time_maxsizestart = 0;
    // Update is called once per frame
    void Update()
    {
        if(stopsize == false)
        {
            //指定した時間の半分になるまで拡大する。
            if (Time_now <= timespeed / 2)
            {
                Time_now += Time.deltaTime;
                Vector3 coreSize = EnemyCube.transform.localScale;
                coreSize = new(coreSize.x += CurrentSize * Time.deltaTime, coreSize.y += CurrentSize * Time.deltaTime, coreSize.z += CurrentSize * Time.deltaTime);

                EnemyCube.transform.localScale = coreSize;
            }
            else if (Time_now <= timespeed)
            {
                if(stopsizesw == false)
                {
                    stopsize = true;
                }
                Time_now += Time.deltaTime;
                Vector3 coreSize = EnemyCube.transform.localScale;
                coreSize = new(coreSize.x -= CurrentSize * Time.deltaTime, coreSize.y -= CurrentSize * Time.deltaTime, coreSize.z -= CurrentSize * Time.deltaTime);

                EnemyCube.transform.localScale = coreSize;
            }
            else
            {
                Time_now = 0;
                stopsizesw = false;
                EnemyCube.transform.localScale = new Vector3(100, 100, 100);
            }
        } else
        {
            //最大サイズ時のしばらくそのままな時間
            Time_maxsizestart += Time.deltaTime;
            if(stilltime < Time_maxsizestart)
            {
                //時間をリセットしてサイズ静止フラグをオフにする。
                Time_maxsizestart = 0;
                stopsize = false;
                stopsizesw = true;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Chick")
        {
            // 当たった時に棘を隠している状況のときだったら
            if(stopsize == true)
            {
                Destroy(this.gameObject);
            } else
            { // 棘を出しているときに当たった時の処理
                Debug.Log("ダメージ");
            }
        }
    }
}
