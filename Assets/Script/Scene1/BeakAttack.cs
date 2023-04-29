using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision.gameObject.name);
            collision.gameObject.GetComponent<EnemyController>().OnAttackPlayer();
            Destroy(gameObject);
        }

    }

    private void OnCollisionExit(Collision collision)
    {

    }
}
