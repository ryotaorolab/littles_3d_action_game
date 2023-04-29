using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingPlate : MonoBehaviour
{
    [SerializeField]
    Vector3 ForceVer;
    GameObject Player;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Chick");
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Chick")
        {
            Debug.Log("JumpDai");
            rb.AddForce(ForceVer, ForceMode.Impulse);
        }
    }
}
