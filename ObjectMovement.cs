using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Transform target;

    // This method allows setting the target from another script
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget(); // Call the method
        }
    }

    void MoveTowardsTarget()
    {
        // Move the object towards the target
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
