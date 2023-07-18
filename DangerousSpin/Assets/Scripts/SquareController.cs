using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : BallController
{
    [NonSerialized] protected new float rotationSpeed = 100f; // Speed modifier for rotation

    [NonSerialized]
    protected new bool isClockwise = true; // Flag to track the ball's movement direction

    private void Update()
    {   
        
        if (Input.GetKeyDown(KeyCode.Space)) // Check for tap/click input
        {
            isClockwise = !isClockwise; // Toggle the movement direction
        }
        
        Movement();
    }
}
