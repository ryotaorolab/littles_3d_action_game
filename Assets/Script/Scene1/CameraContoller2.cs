using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller2 : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float Objectdistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.position, Vector3.down, out hit))
        {
            if (hit.distance <= Objectdistance)
            {
                transform.position = player.position + offset;
            } else
            {
                transform.position = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);
            }
        } 
    }
}
