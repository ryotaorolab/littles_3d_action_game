using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stageselect : MonoBehaviour
{
    public GameObject SelectCam;
    public string SelectScene;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera main = SelectCam.GetComponent<Camera>();

        //メインカメラ内のタッチ処理
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D col = Physics2D.OverlapPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            if (col == this.GetComponent<Collider2D>())
            {

                Application.LoadLevel(SelectScene);

            }
        }
    }
}
