using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public SquareController squareController;
    public BallController ballController;
    public SquareBlockController squareBlockController;

    #region Singleton

    public static FlowManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion


    public void FLOW(int playerScore)
    {
        
        playerScore /= 10;

        squareController.SwitchRotation();

        // Modify rotation speed based on player score
        squareController.rotationSpeed = 150f + playerScore * 10f;
        ballController.rotationSpeed = 150f + playerScore * 10f;

        // Modify movement speed and spawn delay based on player score
        squareBlockController.movementSpeed = 2f + playerScore * 0.25f;
        squareBlockController.spawnDelay = 1f - playerScore * 0.025f;

        // Ensure spawn delay doesn't go below a certain value
        squareBlockController.spawnDelay = Mathf.Max(squareBlockController.spawnDelay, 0.2f);
    }


}
