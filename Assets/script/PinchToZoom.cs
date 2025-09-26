using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    public float zoomSpeed = 0.01f;   // Speed of scaling
    public float minScale = 0.2f;     // Minimum size
    public float maxScale = 3.0f;     // Maximum size

    void Update()
    {
        // Check if there are exactly 2 touches
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Get previous positions of the touches
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Compute the magnitude of the vector (distance) between touches
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            // Difference in distances between frames
            float difference = currentMagnitude - prevMagnitude;

            // Apply zoom (scale the object)
            Vector3 newScale = transform.localScale + Vector3.one * difference * zoomSpeed;

            // Clamp scale so it doesn’t get too small or too big
            newScale = Vector3.Max(newScale, Vector3.one * minScale);
            newScale = Vector3.Min(newScale, Vector3.one * maxScale);

            transform.localScale = newScale;
        }
    }
}
