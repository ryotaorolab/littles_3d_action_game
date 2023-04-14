using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField]
    Vector3 Cardirection; //車の進行方向先
    [SerializeField] float speed; //車の速度
    [SerializeField] float DeleteObjectTime; //車が消えるまでの時間

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestoroyCar");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Cardirection * Time.deltaTime;
    }
    
    IEnumerator DestoroyCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(DeleteObjectTime);
            Destroy(this.gameObject);
        }
    }
}
