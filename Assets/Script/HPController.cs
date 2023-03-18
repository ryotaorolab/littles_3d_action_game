using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    int MaxHP;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // HPを減らす処理
    public void HPreduce(int hpvalue)
    {
        slider.value -= hpvalue;
    }
}
