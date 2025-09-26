using UnityEngine;

public class RotateModel : MonoBehaviour
{
    public float rotationSpeed = 0.2f; // Adjust sensitivity

    private Vector2 previousTouchPos;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.deltaPosition;
                // Rotate around Y-axis
                transform.Rotate(0f, -delta.x * rotationSpeed, 0f, Space.World);
            }
        }
    }
}
