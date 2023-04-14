using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerate : MonoBehaviour
{
    [SerializeField]
    GameObject CarPrefab;
    [SerializeField]
    GameObject CarCreatePoint;
    [SerializeField]
    float span = 3f;

    //車のパラメーターはここで設定する。CarMoveでは設定しない
    [SerializeField]
    Vector3 Cardirection; //車の進行方向先
    [SerializeField] float speed; //車の速度
    [SerializeField] float DeleteObjectTime; //車が消えるまでの時間
    [SerializeField] int Damage;

    Vector3 CarCreatePosition;
    // Start is called before the first frame update
    void Start()
    {
        CarCreatePosition = CarCreatePoint.transform.position;
        StartCoroutine("CreateObject");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator CreateObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(span);
            GameObject CarPrefabObject = Instantiate(CarPrefab, CarCreatePosition, Quaternion.identity);
            CarPrefabObject.GetComponent<CarMove>().Cardirection = Cardirection;
            CarPrefabObject.GetComponent<CarMove>().speed = speed;
            CarPrefabObject.GetComponent<CarMove>().DeleteObjectTime = DeleteObjectTime;
            CarPrefabObject.GetComponent<CarMove>().Damage = Damage;
        }
    }
}
