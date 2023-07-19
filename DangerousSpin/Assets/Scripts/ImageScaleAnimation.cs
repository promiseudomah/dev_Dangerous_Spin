using UnityEngine;

public class ImageScaleAnimation : MonoBehaviour
{
    public float scaleFactor = 1.2f; // Scale factor for the image
    public float rotationSpeed = 180f; // Speed of rotation in degrees per second
    public float animationDuration = 1f; // Duration of each scaling animation

    private Vector3 originalScale; // Original scale of the image
    private Quaternion originalRotation; // Original rotation of the image
    private bool isScalingUp = true; // Flag to track the current scaling direction
    private float timer; // Timer to track the animation duration

    private void Start()
    {
        originalScale = transform.localScale; // Store the original scale of the image
        originalRotation = transform.rotation; // Store the original rotation of the image
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isScalingUp)
        {
            // Scale up the image
            transform.localScale = Vector3.Lerp(originalScale, originalScale * scaleFactor, timer / animationDuration);
        }
        else
        {
            // Scale down the image
            transform.localScale = Vector3.Lerp(originalScale * scaleFactor, originalScale, timer / animationDuration);
        }

        // Rotate the image
        float rotationAngle = rotationSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.forward, rotationAngle);

        if (timer >= animationDuration)
        {
            timer = 0f;
            isScalingUp = !isScalingUp; // Toggle the scaling direction
        }
    }
}
