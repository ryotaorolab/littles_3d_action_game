using UnityEngine;

public class CoinScript : MonoBehaviour
{
    float speed = 100f;

    bool isGet; //獲得済みフラグ
    float lifeTime = 0.5f; //獲得後の生存時間
    [SerializeField]
    GameObject CoinManagementObject;
    CoinManagement coinManagement;

    // Start is called before the first frame update
    void Start()
    {
        coinManagement = CoinManagementObject.GetComponent<CoinManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        //獲得後
        if (isGet)
        {
            //素早く回転
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

            //生存時間を減らす
            lifeTime -= Time.deltaTime;

            //生存時間が0以下になったら消滅
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            //獲得前
            //ゆっくり回転
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーが接触で獲得判定
        if (!isGet && other.CompareTag("Player"))
        {
            isGet = true;

            // コインを上にポップさせる
            transform.position += Vector3.up * 1.5f;
            bool getScore = false;
            if(getScore == false)
            {
                coinManagement.AddCoin();
                getScore = true;
            }
        }
    }
}
