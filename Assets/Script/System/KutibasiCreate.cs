using UnityEngine;

public class KutibasiCreate : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            OnKutibasiAttack();
        }
    }

    public void OnKutibasiAttack()
    {
        // Create a new projectile GameObject.
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.name = "くちばし";
        // Set the projectile's velocity to be in the direction the player is facing.
        projectile.transform.Translate(transform.TransformDirection(Vector3.forward) * projectileSpeed * Time.deltaTime);
    }
}
