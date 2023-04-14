using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectCameraMove : MonoBehaviour
{
    public GameObject SelectCam;

    public GameObject[] right;
    public GameObject[] left;
    public GameObject[] down;
    public GameObject[] up;
    public GameObject[] back;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = SelectCam.GetComponent<Camera>();
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Collider2D col = Physics2D.OverlapPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            // 右に移動
            foreach (GameObject Right in right)
            {
                if (col == Right.GetComponent<Collider2D>())
                {
                    SelectCam.transform.position = new Vector3(this.transform.position.x + 40, this.transform.position.y, -10);
                }
            }
            // 左に移動
            foreach(GameObject Left in left)
            {
                if (col == Left.GetComponent<Collider2D>())
                {
                    SelectCam.transform.position = new Vector3(this.transform.position.x - 40, this.transform.position.y, -10);
                }
            }
            // 上に移動
            foreach(GameObject UP in up)
            {
                if (col == UP.GetComponent<Collider2D>())
                {
                    SelectCam.transform.position = new Vector3(0, 0, -10);
                }
            }
            // 下に移動
            foreach (GameObject Down in down)
            {
                if (col == Down.GetComponent<Collider2D>())
                {
                    SelectCam.transform.position = new Vector3(0, -20, -10);
                }
            }
            //　タイトルへ戻る
            foreach (GameObject Back in back)
            {
                if (col == Back.GetComponent<Collider2D>())
                {
                    Application.LoadLevel("0");
                }
            }
        }
    }
}
