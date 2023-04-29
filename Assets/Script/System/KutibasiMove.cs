using UnityEngine;

public class KutibasiMove : MonoBehaviour
{

    // The speed of the object.
    public float speed = 10.0f;

    // The time after which the object should be deleted.
    public float deleteTime = 3.0f;

    // The timer for the delete event.
    float timer;

    void Start()
    {
        // Start the timer.
        timer = deleteTime;
    }

    void Update()
    {
        // Move the object in the direction it is facing.
        transform.Translate(transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime);

        // Decrement the timer.
        timer -= Time.deltaTime;

        // If the timer reaches zero, delete the object.
        if (timer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}

