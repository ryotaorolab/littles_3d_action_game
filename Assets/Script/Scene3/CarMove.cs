using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public Vector3 Cardirection; //車の進行方向先
    public float speed; //車の速度
    public float DeleteObjectTime; //車が消えるまでの時間
    public int Damage;

    GameObject HPController;
    HPController hpController;

    // Start is called before the first frame update
    void Start()
    {
        HPController = GameObject.Find("HPController");
        hpController = HPController.GetComponent<HPController>();

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Chick")
        {
            hpController.HPreduce(Damage);
        }
    }
}
