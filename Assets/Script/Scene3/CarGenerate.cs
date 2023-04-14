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
        }
    }
}
