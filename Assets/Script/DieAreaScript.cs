using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAreaScript : MonoBehaviour
{
    GameObject HPController;
    HPController hpController;
    // Start is called before the first frame update
    void Start()
    {
        HPController = GameObject.Find("HPController");
        hpController = HPController.GetComponent<HPController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Chick")
        {
            // 棘にあたったらダメージを与える
            hpController.HPreduce(1);
        }
    }
}
