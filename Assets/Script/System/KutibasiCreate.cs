using UnityEngine;
using System.Collections;

public class KutibasiCreate : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;
    public float delayTime = 1.0f;
    private bool isClicked = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!isClicked)
            {
                OnKutibasiAttack();
                isClicked = true;
              
            }
        }
    }

    public void OnButtonAttack()
    {
        if (!isClicked)
        {
            OnKutibasiAttack();
            isClicked = true;

        }
    }

    public void OnKutibasiAttack()
    {
        // Create a new projectile GameObject.
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.name = "くちばし";
        // Set the projectile's velocity to be in the direction the player is facing.
        projectile.transform.Translate(transform.TransformDirection(Vector3.forward) * projectileSpeed * Time.deltaTime);
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(delayTime);
        isClicked = false;
    }
}
