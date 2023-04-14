using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageIndication : MonoBehaviour
{
    [SerializeField]
    int StagePhotoNo;
    int StageStatus;
    // Start is called before the first frame update
    void Start()
    {
        StageStatus = PlayerPrefs.GetInt("STAGEPROGRESS", 0);
        if (StageStatus >= StagePhotoNo)
        {
            this.gameObject.SetActive(true);
        } else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
