using UnityEngine;

public class Circle2 : Circle
{
    [SerializeField] private float rotationOffset = 0f; 

    private void Update()
    {
        // 1. Get mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2. Calculate the difference vector
        Vector3 lookDirection = mousePosition - transform.position;

        // 3. Find the angle in degrees using Atan2
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // 4. Apply the rotation on the Z-axis
        transform.rotation = Quaternion.Euler(0f, 0f, angle + rotationOffset);
    }
}
