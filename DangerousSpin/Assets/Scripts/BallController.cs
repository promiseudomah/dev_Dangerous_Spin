using UnityEngine;

public class BallController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed modifier 
    protected bool isClockwise = true; // Flag to track the ball's movement direction

    protected void Update()
    {   

        if (Input.GetMouseButtonDown(0)) // Check for tap/click input
        {
            isClockwise = !isClockwise; // Toggle the movement direction
        }

        Movement();
    }

    protected virtual void Movement(){

        // Calculate the rotation angle based on the speed modifier and the elapsed time
        float rotationAngle = rotationSpeed * Time.deltaTime;

        // Rotate the ball around the center of the screen
        if (isClockwise)
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, rotationAngle);
        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.back, rotationAngle);
        }

        // Restrict movement in the x and y axes
        Vector3 restrictedPosition = transform.position;
        restrictedPosition.x = 0f;
        restrictedPosition.y = 0f;
        transform.position = restrictedPosition;
    }
}
