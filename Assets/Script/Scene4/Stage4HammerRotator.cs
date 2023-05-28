using UnityEngine;

public class Stage4HammerRotator : MonoBehaviour
{
    public float rotationSpeed = 10f;

    public float duration = 1f;
    public float currentRotation = -153f;
    private float elapsedTime = 0f;
    [SerializeField]
    Vector3 DefaultRotation;

    float DefaultCurrentRotation;
    bool LRSwitch = false;
    float afterrotation;

    private void Start()
    {
        DefaultCurrentRotation = currentRotation;
    }
    void Update()
    {
        
        if (!LRSwitch)
        {
            if (elapsedTime < duration)
            {
                currentRotation += rotationSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(currentRotation + DefaultRotation.x, DefaultRotation.y, DefaultRotation.z);
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime = 0f;
                afterrotation = this.gameObject.transform.eulerAngles.x;
                LRSwitch = true;
                currentRotation = afterrotation;
            }
        }

        if (LRSwitch)
        {
            if (elapsedTime < duration)
            {
                afterrotation -= rotationSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(afterrotation + DefaultRotation.x, DefaultRotation.y, DefaultRotation.z);
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime = 0f;
                afterrotation = this.gameObject.transform.eulerAngles.x;
                LRSwitch = false;
                currentRotation = DefaultCurrentRotation;
            }
        }
    }
}